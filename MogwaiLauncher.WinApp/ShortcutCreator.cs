using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Net;
using System.ServiceModel;
using MogwaiLauncher.WinApp.Turbine.GLS.Auth;
using MogwaiLauncher.WinApp.TurbineTransferService;

// using Microsoft.SqlServer.MessageBox;

namespace MogwaiLauncher.WinApp
{
    public partial class ShortcutCreator : Form
    {
        private LauncherData launcherData;

        private Dictionary<string, List<Character>> characterData = new Dictionary<string, List<Character>>();
        private bool suppressFetching = true;
        private bool suppressFiltering = true;

        public ShortcutCreator()
        {
            InitializeComponent();
        }

        private void ShortcutCreator_Load(object sender, EventArgs e)
        {
            // load clients
            string clients = ConfigurationManager.AppSettings["GameClients"];
            string[] clientArray = clients.Split('|');
            foreach (string client in clientArray)
                if (!string.IsNullOrEmpty(client))
                    cbClients.Items.Add(client);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUsername.BackColor = Color.White;
            if (e.KeyChar == 13)
                btnLogin_Click(null, null);
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUsername.BackColor = Color.White;
            if (e.KeyChar == 13)
                btnLogin_Click(null, null);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                suppressFetching = true;
                LoginResults results = new LoginResults(txtUsername.Text, txtPassword.Text, launcherData);
                cbWorlds.DataSource = launcherData.Worlds.Values.ToList();
                cbWorlds.DisplayMember = "Name";
                cbWorlds.Enabled = true;
                cbSubs.DataSource = results.Subscriptions.ToList();
                cbSubs.DisplayMember = "Description";
                cbSubs.ValueMember = "Name";
                cbSubs.Enabled = true;
                btnCreateShortcut.Enabled = true;

                if (!string.IsNullOrEmpty(Settings.DefaultWorld))
                    cbWorlds.FindStringExact(Settings.DefaultWorld);

                if (!string.IsNullOrEmpty(Settings.DefaultSubscription))
                    cbSubs.FindStringExact(Settings.DefaultSubscription);

                suppressFetching = false;
                PopulateCharacters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCreateShortcut_Click(object sender, EventArgs e)
        {
            bool includeCharacter = !string.IsNullOrWhiteSpace(cbCharacters.Text);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = ".lnk";
            sfd.FileName = cbSubs.Text + " - " + cbWorlds.Text + (includeCharacter? " - " + cbCharacters.Text : "");

            sfd.Filter = "Shortcut files|*.lnk";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string gameFolder = cbClients.Text;
                string launcherFolder = Application.StartupPath;

                // build shortcut
                string arguments = "/u:{0} /p:{1} /s:{2} /w:{3} /l:{4} /d:\"{5}\"";

                if (includeCharacter)
                    arguments += " /u:{6}";

                arguments = string.Format(arguments, Util.EncryptString(txtUsername.Text),
                                                     Util.EncryptString(txtPassword.Text),
                                                     cbSubs.SelectedValue,
                                                     cbWorlds.Text,
                                                     cbLanguage.Text,
                                                     gameFolder,
                                                     cbCharacters.Text);

                // write out the batch file
                string batchFileName = launcherFolder + "\\" + sfd.FileName.Substring(sfd.FileName.LastIndexOf("\\") + 1).Replace(".lnk", ".bat");
                string batchContents = "\"" + Application.ExecutablePath + "\" " + arguments;
                System.IO.File.WriteAllText(batchFileName, batchContents);

                CreateShortcut(batchFileName, Application.ExecutablePath, sfd.FileName, null, null, gameFolder);
            }
        }

        /// <summary>
        /// Create Windows Shorcut
        /// </summary>
        /// <param name="sourceFile">A file you want to make shortcut to</param>
        /// <param name="iconFile">icon file for the shortcut</param>
        /// <param name="ShortcutFile">Path and shorcut file name including file extension (.lnk)</param>
        /// <param name="description">Shortcut description</param>
        /// <param name="arguments">Command line arguments</param>
        /// <param name="workingDirectory">"Start in" shorcut parameter</param>
        public void CreateShortcut(string sourceFile, string iconFile, string shortcutFile, string description, string arguments, string workingDirectory)
        {
            // Create WshShellClass instance:
            WshShell wshShell = new WshShell();

            // Create shortcut object:
            IWshShortcut shorcut = (IWshShortcut)wshShell.CreateShortcut(shortcutFile);

            // Assign shortcut properties:
            shorcut.TargetPath = sourceFile;
            shorcut.Description = description;
            shorcut.IconLocation = iconFile;
            if (!String.IsNullOrEmpty(arguments))
                shorcut.Arguments = arguments;
            if (!String.IsNullOrEmpty(workingDirectory))
                shorcut.WorkingDirectory = workingDirectory;

            // Save the shortcut:
            shorcut.Save();
        }

        private void cbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                launcherData = new LauncherData(cbClients.Text);
            }
            catch (WebException webEx)
            {
                // downtime
                // ExceptionMessageBox foo = new ExceptionMessageBox(webEx);
                // foo.Show(this);
                this.Close();
            }

            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnLogin.Enabled = true;
        }

        private void cbWorlds_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCharacters();
        }

        private void PopulateCharacters()
        {
            if (suppressFetching)
                return;

            try
            {
                cbCharacters.Items.Clear();
                characterData = new Dictionary<string, List<Character>>();

                if (string.IsNullOrWhiteSpace(launcherData.TransferServiceUrl))
                    return;
                
                if (string.IsNullOrWhiteSpace(cbSubs.SelectedText) && cbSubs.SelectedItem == null)
                    return;

                GetAllCharactersRequest request = new GetAllCharactersRequest();
                request.Subscription = (cbSubs.SelectedItem as GameSubscription).Name;
                
                // try to pull a list of characters
                TurbineTransferServiceClient client = new TurbineTransferServiceClient(new BasicHttpBinding(), new EndpointAddress(launcherData.TransferServiceUrl));
                var response = client.GetAllCharacters(request);

                if (response == null || response.HasError)
                    return;

                suppressFiltering = true;

                foreach (var shard in response.Shards)
                    if (shard != null && !string.IsNullOrWhiteSpace(shard.Shard?.Name) && shard.Characters != null && shard.Characters.Length > 0)
                        characterData.Add(shard.Shard.Name, shard.Characters.ToList());

                suppressFiltering = false;
                cbCharacters.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void FilterCharacters()
        {
            if (suppressFiltering)
                return;

            cbCharacters.Items.Clear();

            if (string.IsNullOrWhiteSpace(cbWorlds.Text))
                return;

            if (!characterData.ContainsKey(cbWorlds.Text))
                return;

            var characters = characterData[cbWorlds.Text].Where(c => c.Deleted == false);

            cbCharacters.Items.Add("");

            foreach (var character in characters)
                cbCharacters.Items.Add(character.Name);
        }

        private void cbSubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCharacters();
            FilterCharacters();
        }
    }
}
