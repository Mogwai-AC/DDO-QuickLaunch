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

namespace MogwaiLauncher.WinApp
{
    public partial class ShortcutCreator : Form
    {
        private LauncherData launcherData;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCreateShortcut_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = ".lnk";
            sfd.FileName = cbSubs.Text + " - " + cbWorlds.Text;
            sfd.Filter = "Shortcut files|*.lnk";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string gameFolder = cbClients.Text;
                string launcherFolder = Application.StartupPath;

                // build shortcut
                string arguments = "/u:{0} /p:{1} /s:{2} /w:{3} /l:{4} /d:\"{5}\"";
                arguments = string.Format(arguments, Util.EncryptString(txtUsername.Text),
                                                     Util.EncryptString(txtPassword.Text),
                                                     cbSubs.SelectedValue,
                                                     cbWorlds.Text,
                                                     cbLanguage.Text,
                                                     gameFolder);

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
            launcherData = new LauncherData(cbClients.Text);
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnLogin.Enabled = true;
        }
    }
}
