namespace LocalLauncher.WinApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.btnLogin = new System.Windows.Forms.Button();
          this.lblUsername = new System.Windows.Forms.Label();
          this.lblPassword = new System.Windows.Forms.Label();
          this.txtUsername = new System.Windows.Forms.TextBox();
          this.txtPassword = new System.Windows.Forms.TextBox();
          this.lblSub = new System.Windows.Forms.Label();
          this.lblServer = new System.Windows.Forms.Label();
          this.cbServer = new System.Windows.Forms.ComboBox();
          this.btnPlay = new System.Windows.Forms.Button();
          this.cbSub = new System.Windows.Forms.ComboBox();
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
          this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.accountManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.menuStrip1.SuspendLayout();
          this.SuspendLayout();
          // 
          // btnLogin
          // 
          this.btnLogin.Location = new System.Drawing.Point(16, 91);
          this.btnLogin.Name = "btnLogin";
          this.btnLogin.Size = new System.Drawing.Size(177, 23);
          this.btnLogin.TabIndex = 0;
          this.btnLogin.Text = "Login";
          this.btnLogin.UseVisualStyleBackColor = true;
          this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
          // 
          // lblUsername
          // 
          this.lblUsername.AutoSize = true;
          this.lblUsername.Location = new System.Drawing.Point(13, 41);
          this.lblUsername.Name = "lblUsername";
          this.lblUsername.Size = new System.Drawing.Size(55, 13);
          this.lblUsername.TabIndex = 1;
          this.lblUsername.Text = "Username";
          // 
          // lblPassword
          // 
          this.lblPassword.AutoSize = true;
          this.lblPassword.Location = new System.Drawing.Point(13, 68);
          this.lblPassword.Name = "lblPassword";
          this.lblPassword.Size = new System.Drawing.Size(53, 13);
          this.lblPassword.TabIndex = 2;
          this.lblPassword.Text = "Password";
          // 
          // txtUsername
          // 
          this.txtUsername.Location = new System.Drawing.Point(93, 38);
          this.txtUsername.Name = "txtUsername";
          this.txtUsername.Size = new System.Drawing.Size(100, 20);
          this.txtUsername.TabIndex = 3;
          this.txtUsername.Text = "GolDDO";
          // 
          // txtPassword
          // 
          this.txtPassword.Location = new System.Drawing.Point(93, 65);
          this.txtPassword.Name = "txtPassword";
          this.txtPassword.Size = new System.Drawing.Size(100, 20);
          this.txtPassword.TabIndex = 4;
          this.txtPassword.Text = "yhsfqyj";
          this.txtPassword.UseSystemPasswordChar = true;
          // 
          // lblSub
          // 
          this.lblSub.AutoSize = true;
          this.lblSub.Location = new System.Drawing.Point(13, 127);
          this.lblSub.Name = "lblSub";
          this.lblSub.Size = new System.Drawing.Size(65, 13);
          this.lblSub.TabIndex = 6;
          this.lblSub.Text = "Subscription";
          // 
          // lblServer
          // 
          this.lblServer.AutoSize = true;
          this.lblServer.Location = new System.Drawing.Point(13, 176);
          this.lblServer.Name = "lblServer";
          this.lblServer.Size = new System.Drawing.Size(38, 13);
          this.lblServer.TabIndex = 7;
          this.lblServer.Text = "Server";
          // 
          // cbServer
          // 
          this.cbServer.DisplayMember = "Name";
          this.cbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbServer.FormattingEnabled = true;
          this.cbServer.Location = new System.Drawing.Point(16, 192);
          this.cbServer.Name = "cbServer";
          this.cbServer.Size = new System.Drawing.Size(177, 21);
          this.cbServer.TabIndex = 8;
          // 
          // btnPlay
          // 
          this.btnPlay.Location = new System.Drawing.Point(16, 231);
          this.btnPlay.Name = "btnPlay";
          this.btnPlay.Size = new System.Drawing.Size(177, 23);
          this.btnPlay.TabIndex = 9;
          this.btnPlay.Text = "Play";
          this.btnPlay.UseVisualStyleBackColor = true;
          this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
          // 
          // cbSub
          // 
          this.cbSub.DisplayMember = "Description";
          this.cbSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cbSub.FormattingEnabled = true;
          this.cbSub.Location = new System.Drawing.Point(16, 143);
          this.cbSub.Name = "cbSub";
          this.cbSub.Size = new System.Drawing.Size(177, 21);
          this.cbSub.TabIndex = 10;
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings});
          this.menuStrip1.Location = new System.Drawing.Point(0, 0);
          this.menuStrip1.Name = "menuStrip1";
          this.menuStrip1.Size = new System.Drawing.Size(205, 24);
          this.menuStrip1.TabIndex = 13;
          this.menuStrip1.Text = "menuStrip1";
          // 
          // mnuSettings
          // 
          this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.accountManagementToolStripMenuItem});
          this.mnuSettings.Name = "mnuSettings";
          this.mnuSettings.Size = new System.Drawing.Size(61, 20);
          this.mnuSettings.Text = "Settings";
          // 
          // configurationToolStripMenuItem
          // 
          this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
          this.configurationToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
          this.configurationToolStripMenuItem.Text = "Configuration";
          this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(205, 266);
          this.Controls.Add(this.cbSub);
          this.Controls.Add(this.btnPlay);
          this.Controls.Add(this.cbServer);
          this.Controls.Add(this.lblServer);
          this.Controls.Add(this.lblSub);
          this.Controls.Add(this.txtPassword);
          this.Controls.Add(this.txtUsername);
          this.Controls.Add(this.lblPassword);
          this.Controls.Add(this.lblUsername);
          this.Controls.Add(this.btnLogin);
          this.Controls.Add(this.menuStrip1);
          this.MainMenuStrip = this.menuStrip1;
          this.MaximizeBox = false;
          this.Name = "Form1";
          this.Text = "My Launcher";
          this.Load += new System.EventHandler(this.Form1_Load);
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ComboBox cbSub;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountManagementToolStripMenuItem;
    }
}

