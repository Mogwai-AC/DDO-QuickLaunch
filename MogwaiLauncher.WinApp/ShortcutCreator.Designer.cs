namespace MogwaiLauncher.WinApp
{
  partial class ShortcutCreator
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortcutCreator));
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.btnLogin = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cbSubs = new System.Windows.Forms.ComboBox();
      this.cbWorlds = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbLanguage = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnCreateShortcut = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.cbClients = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // txtPassword
      // 
      this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPassword.Enabled = false;
      this.txtPassword.Location = new System.Drawing.Point(91, 70);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(239, 20);
      this.txtPassword.TabIndex = 32;
      this.txtPassword.UseSystemPasswordChar = true;
      this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
      // 
      // txtUsername
      // 
      this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtUsername.Enabled = false;
      this.txtUsername.Location = new System.Drawing.Point(91, 43);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new System.Drawing.Size(239, 20);
      this.txtUsername.TabIndex = 31;
      this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(11, 73);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(53, 13);
      this.label3.TabIndex = 30;
      this.label3.Text = "Password";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(11, 46);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(55, 13);
      this.label4.TabIndex = 29;
      this.label4.Text = "Username";
      // 
      // btnLogin
      // 
      this.btnLogin.Enabled = false;
      this.btnLogin.Location = new System.Drawing.Point(133, 96);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(151, 23);
      this.btnLogin.TabIndex = 33;
      this.btnLogin.Text = "Get Subscriptions";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(11, 128);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 13);
      this.label1.TabIndex = 34;
      this.label1.Text = "Subscriptions";
      // 
      // cbSubs
      // 
      this.cbSubs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbSubs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSubs.Enabled = false;
      this.cbSubs.FormattingEnabled = true;
      this.cbSubs.Location = new System.Drawing.Point(91, 125);
      this.cbSubs.Name = "cbSubs";
      this.cbSubs.Size = new System.Drawing.Size(239, 21);
      this.cbSubs.TabIndex = 35;
      // 
      // cbWorlds
      // 
      this.cbWorlds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbWorlds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbWorlds.Enabled = false;
      this.cbWorlds.FormattingEnabled = true;
      this.cbWorlds.Location = new System.Drawing.Point(91, 152);
      this.cbWorlds.Name = "cbWorlds";
      this.cbWorlds.Size = new System.Drawing.Size(239, 21);
      this.cbWorlds.TabIndex = 36;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(11, 155);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(40, 13);
      this.label2.TabIndex = 37;
      this.label2.Text = "Worlds";
      // 
      // cbLanguage
      // 
      this.cbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbLanguage.FormattingEnabled = true;
      this.cbLanguage.Items.AddRange(new object[] {
            "English",
            "French",
            "German"});
      this.cbLanguage.Location = new System.Drawing.Point(91, 179);
      this.cbLanguage.Name = "cbLanguage";
      this.cbLanguage.Size = new System.Drawing.Size(239, 21);
      this.cbLanguage.TabIndex = 38;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(11, 182);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(55, 13);
      this.label5.TabIndex = 39;
      this.label5.Text = "Language";
      // 
      // btnCreateShortcut
      // 
      this.btnCreateShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCreateShortcut.Enabled = false;
      this.btnCreateShortcut.Location = new System.Drawing.Point(12, 205);
      this.btnCreateShortcut.Name = "btnCreateShortcut";
      this.btnCreateShortcut.Size = new System.Drawing.Size(318, 23);
      this.btnCreateShortcut.TabIndex = 40;
      this.btnCreateShortcut.Text = "Create Shortcut";
      this.btnCreateShortcut.UseVisualStyleBackColor = true;
      this.btnCreateShortcut.Click += new System.EventHandler(this.btnCreateShortcut_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(11, 15);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(33, 13);
      this.label6.TabIndex = 44;
      this.label6.Text = "Client";
      // 
      // cbClients
      // 
      this.cbClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbClients.FormattingEnabled = true;
      this.cbClients.Location = new System.Drawing.Point(91, 12);
      this.cbClients.Name = "cbClients";
      this.cbClients.Size = new System.Drawing.Size(239, 21);
      this.cbClients.TabIndex = 43;
      this.cbClients.SelectedIndexChanged += new System.EventHandler(this.cbClients_SelectedIndexChanged);
      // 
      // ShortcutCreator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(344, 240);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cbClients);
      this.Controls.Add(this.btnCreateShortcut);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cbLanguage);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbWorlds);
      this.Controls.Add(this.cbSubs);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.txtUsername);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label4);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "ShortcutCreator";
      this.Text = "Shortcut Creation";
      this.Load += new System.EventHandler(this.ShortcutCreator_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbSubs;
    private System.Windows.Forms.ComboBox cbWorlds;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbLanguage;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnCreateShortcut;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cbClients;
  }
}