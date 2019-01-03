// using Microsoft.SqlServer.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MogwaiLauncher.WinApp
{
    public partial class LaunchForm : Form
    {
        private LauncherData launcherData;

        public LaunchForm()
        {
            InitializeComponent();
        }

        private LoginResults results = null;

        private void LaunchForm_Load(object sender, EventArgs e)
        {
            // change some control stuff
            pnlLogin.Dock = DockStyle.Fill;
            pnlPlay.Dock = DockStyle.Fill;
            pnlPlay.Visible = false;
            this.Size = new Size(325, 156);

            // load settings
            txtUsername.Text = Settings.Username;
            chkSaveUsername.Checked = Settings.SaveUsername;
            txtPassword.Text = Settings.Password;
            chkSavePassword.Checked = Settings.SavePassword;

            LoadClientsMenu();
        }

        void clientItem_Click(object sender, EventArgs e)
        {
            Settings.CurrentClient = (sender as ToolStripMenuItem).Text;
            System.IO.Directory.SetCurrentDirectory((sender as ToolStripMenuItem).Text);

            foreach (ToolStripMenuItem tsmi in clientsToolStripMenuItem.DropDownItems)
                if (tsmi.CheckOnClick && sender != tsmi)
                    tsmi.CheckState = CheckState.Unchecked;

            LoadLauncherData();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool fail = false;

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                fail = true;
                txtUsername.BackColor = Color.Yellow;
                txtUsername.Focus();
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                fail = true;
                txtPassword.BackColor = Color.Yellow;
                txtPassword.Focus();
            }

            if (fail)
                return;

            if (chkSaveUsername.Checked)
            {
                Settings.Username = txtUsername.Text;
                Settings.SaveUsername = true;
            }
            else
            {
                Settings.Username = "";
                Settings.SaveUsername = false;
            }

            if (chkSavePassword.Checked)
            {
                Settings.Password = txtPassword.Text;
                Settings.SavePassword = true;
            }
            else
            {
                Settings.Password = "";
                Settings.SavePassword = false;
            }

            try
            {
                results = new LoginResults(txtUsername.Text, txtPassword.Text, launcherData);
                cbWorlds.DataSource = launcherData.Worlds.Values.ToList();
                cbWorlds.DisplayMember = "Name";
                cbWorlds.ValueMember = "Name";
                cbSubscriptions.DataSource = results.Subscriptions.ToList();
                cbSubscriptions.DisplayMember = "Description";
                cbSubscriptions.ValueMember = "Name";

                if (!string.IsNullOrEmpty(Settings.DefaultWorld))
                    cbWorlds.SelectedValue = Settings.DefaultWorld;

                if (!string.IsNullOrEmpty(Settings.DefaultSubscription))
                    cbSubscriptions.SelectedValue = Settings.DefaultSubscription;

                pnlLogin.Visible = false;
                pnlPlay.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = true;
            pnlPlay.Visible = false;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.BackColor = Color.White;
            if (e.KeyChar == 13)
                btnLogin_Click(null, null);
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUsername.BackColor = Color.White;
            if (e.KeyChar == 13)
                btnLogin_Click(null, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bntPlay_Click(object sender, EventArgs e)
        {
            string sub = results.Subscriptions[cbSubscriptions.SelectedIndex].Name;
            Settings.DefaultWorld = cbWorlds.Text;
            Settings.DefaultSubscription = cbSubscriptions.SelectedValue as string;
            results.Launch(sub, cbWorlds.Text, "English");
        }

        private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FindClientForm()).ShowDialog();
            LoadClientsMenu();
        }

        private void LoadClientsMenu()
        {
            for (int i = clientsToolStripMenuItem.DropDownItems.Count - 1; i >= 0; i--)
            {
                if (clientsToolStripMenuItem.DropDownItems[i].Text != "Manage Clients")
                    clientsToolStripMenuItem.DropDownItems.RemoveAt(i);
            }

            // load clients, clean up game clients string.
            string[] clientArray = Settings.GameClients.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            Settings.GameClients = String.Join("|", clientArray);

            if (clientArray == null || clientArray.Length == 0)
            {
                MessageBox.Show("QuickLaunch has detected that you do not have any game client directories configured.  Please select any game client directories you wish to use with QuickLaunch by locating TurbineLauncher.exe.config.  You can use your main install folders, preview server folders, and private config clients for DDO.", "DDO QuickLaunch");
                (new FindClientForm()).ShowDialog();
                clientArray = Settings.GameClients.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Settings.GameClients = String.Join("|", clientArray);
            }

            // add them to the menu
            foreach (string client in clientArray)
            {
                if (!string.IsNullOrEmpty(client))
                {
                    if (!Directory.Exists(client))
                        continue;

                    if (clientArray.Length == 1)
                        Settings.CurrentClient = client;

                    ToolStripMenuItem clientItem = new ToolStripMenuItem(client);
                    clientItem.CheckOnClick = true;
                    if (client == Settings.CurrentClient)
                    {
                        clientItem.CheckState = CheckState.Checked;
                        Directory.SetCurrentDirectory(client);
                        LoadLauncherData();
                    }
                    clientItem.Click += new EventHandler(clientItem_Click);
                    clientsToolStripMenuItem.DropDownItems.Add(clientItem);
                }
            }
        }

        private void LoadLauncherData()
        {
            try
            {
                launcherData = new LauncherData();
            }
            catch (WebException webEx)
            {
                // downtime
                //ExceptionMessageBox foo = new ExceptionMessageBox(webEx);
                //foo.Caption = "Unable to get necessary data from DDO Servers.  DDO Quicklaunch will close.";
                //foo.Show(this);
                Application.Exit();
            }
        }

        private void getHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discordapp.com/invite/RCBDR");

        }

        private void btnCreateShortcut_Click(object sender, EventArgs e)
        {
            (new ShortcutCreator()).ShowDialog();
        }

        private void createShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ShortcutCreator()).ShowDialog();
        }
    }
}
