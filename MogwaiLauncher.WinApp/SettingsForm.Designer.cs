namespace LocalLauncher.WinApp
{
  partial class SettingsForm
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
      this.lblGame = new System.Windows.Forms.Label();
      this.cbGame = new System.Windows.Forms.ComboBox();
      this.lblDdoExe = new System.Windows.Forms.Label();
      this.txtDdoExe = new System.Windows.Forms.TextBox();
      this.btnFindDdoExe = new System.Windows.Forms.Button();
      this.ofdDdoExe = new System.Windows.Forms.OpenFileDialog();
      this.btnFindLotroExe = new System.Windows.Forms.Button();
      this.txtLotroExe = new System.Windows.Forms.TextBox();
      this.lblLotroExe = new System.Windows.Forms.Label();
      this.ofdLotroExe = new System.Windows.Forms.OpenFileDialog();
      this.cbDatacenter = new System.Windows.Forms.ComboBox();
      this.lblDatacenter = new System.Windows.Forms.Label();
      this.cbAuth = new System.Windows.Forms.ComboBox();
      this.lblAuth = new System.Windows.Forms.Label();
      this.ofdLocalLotroExe = new System.Windows.Forms.OpenFileDialog();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.chkAutoLogin = new System.Windows.Forms.CheckBox();
      this.chkAutoLaunch = new System.Windows.Forms.CheckBox();
      this.chkRememberPassword = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // lblGame
      // 
      this.lblGame.AutoSize = true;
      this.lblGame.Location = new System.Drawing.Point(83, 15);
      this.lblGame.Name = "lblGame";
      this.lblGame.Size = new System.Drawing.Size(35, 13);
      this.lblGame.TabIndex = 0;
      this.lblGame.Text = "Game";
      // 
      // cbGame
      // 
      this.cbGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbGame.FormattingEnabled = true;
      this.cbGame.Items.AddRange(new object[] {
            "LOTRO",
            "DDO"});
      this.cbGame.Location = new System.Drawing.Point(124, 12);
      this.cbGame.Name = "cbGame";
      this.cbGame.Size = new System.Drawing.Size(121, 21);
      this.cbGame.TabIndex = 1;
      // 
      // lblDdoExe
      // 
      this.lblDdoExe.AutoSize = true;
      this.lblDdoExe.Location = new System.Drawing.Point(66, 47);
      this.lblDdoExe.Name = "lblDdoExe";
      this.lblDdoExe.Size = new System.Drawing.Size(52, 13);
      this.lblDdoExe.TabIndex = 2;
      this.lblDdoExe.Text = "DDO Exe";
      // 
      // txtDdoExe
      // 
      this.txtDdoExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDdoExe.Enabled = false;
      this.txtDdoExe.Location = new System.Drawing.Point(124, 44);
      this.txtDdoExe.Name = "txtDdoExe";
      this.txtDdoExe.Size = new System.Drawing.Size(344, 20);
      this.txtDdoExe.TabIndex = 3;
      // 
      // btnFindDdoExe
      // 
      this.btnFindDdoExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindDdoExe.Location = new System.Drawing.Point(474, 42);
      this.btnFindDdoExe.Name = "btnFindDdoExe";
      this.btnFindDdoExe.Size = new System.Drawing.Size(28, 23);
      this.btnFindDdoExe.TabIndex = 4;
      this.btnFindDdoExe.Text = "...";
      this.btnFindDdoExe.UseVisualStyleBackColor = true;
      this.btnFindDdoExe.Click += new System.EventHandler(this.btnFindDdoExe_Click);
      // 
      // ofdDdoExe
      // 
      this.ofdDdoExe.FileName = "dndclient.exe";
      this.ofdDdoExe.InitialDirectory = "c:\\Program Files (x86)\\Turbine\\DDO Unlimited";
      // 
      // btnFindLotroExe
      // 
      this.btnFindLotroExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindLotroExe.Location = new System.Drawing.Point(474, 68);
      this.btnFindLotroExe.Name = "btnFindLotroExe";
      this.btnFindLotroExe.Size = new System.Drawing.Size(28, 23);
      this.btnFindLotroExe.TabIndex = 7;
      this.btnFindLotroExe.Text = "...";
      this.btnFindLotroExe.UseVisualStyleBackColor = true;
      this.btnFindLotroExe.Click += new System.EventHandler(this.btnFindLotroExe_Click);
      // 
      // txtLotroExe
      // 
      this.txtLotroExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtLotroExe.Enabled = false;
      this.txtLotroExe.Location = new System.Drawing.Point(124, 70);
      this.txtLotroExe.Name = "txtLotroExe";
      this.txtLotroExe.Size = new System.Drawing.Size(344, 20);
      this.txtLotroExe.TabIndex = 6;
      // 
      // lblLotroExe
      // 
      this.lblLotroExe.AutoSize = true;
      this.lblLotroExe.Location = new System.Drawing.Point(53, 73);
      this.lblLotroExe.Name = "lblLotroExe";
      this.lblLotroExe.Size = new System.Drawing.Size(65, 13);
      this.lblLotroExe.TabIndex = 5;
      this.lblLotroExe.Text = "LOTRO Exe";
      // 
      // ofdLotroExe
      // 
      this.ofdLotroExe.FileName = "lotroclient.exe";
      this.ofdLotroExe.InitialDirectory = "C:\\Program Files (x86)\\Turbine\\The Lord of the Rings Online";
      // 
      // cbDatacenter
      // 
      this.cbDatacenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDatacenter.FormattingEnabled = true;
      this.cbDatacenter.Items.AddRange(new object[] {
            "LOTRO",
            "DDO"});
      this.cbDatacenter.Location = new System.Drawing.Point(124, 123);
      this.cbDatacenter.Name = "cbDatacenter";
      this.cbDatacenter.Size = new System.Drawing.Size(121, 21);
      this.cbDatacenter.TabIndex = 12;
      // 
      // lblDatacenter
      // 
      this.lblDatacenter.AutoSize = true;
      this.lblDatacenter.Location = new System.Drawing.Point(58, 126);
      this.lblDatacenter.Name = "lblDatacenter";
      this.lblDatacenter.Size = new System.Drawing.Size(60, 13);
      this.lblDatacenter.TabIndex = 11;
      this.lblDatacenter.Text = "Datacenter";
      // 
      // cbAuth
      // 
      this.cbAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbAuth.FormattingEnabled = true;
      this.cbAuth.Items.AddRange(new object[] {
            "LOTRO",
            "DDO"});
      this.cbAuth.Location = new System.Drawing.Point(124, 150);
      this.cbAuth.Name = "cbAuth";
      this.cbAuth.Size = new System.Drawing.Size(121, 21);
      this.cbAuth.TabIndex = 14;
      // 
      // lblAuth
      // 
      this.lblAuth.AutoSize = true;
      this.lblAuth.Location = new System.Drawing.Point(89, 153);
      this.lblAuth.Name = "lblAuth";
      this.lblAuth.Size = new System.Drawing.Size(29, 13);
      this.lblAuth.TabIndex = 13;
      this.lblAuth.Text = "Auth";
      // 
      // ofdLocalLotroExe
      // 
      this.ofdLocalLotroExe.FileName = "lotroclient.exe";
      this.ofdLocalLotroExe.InitialDirectory = "c:";
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSave.Location = new System.Drawing.Point(427, 356);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 15;
      this.btnSave.Text = "&Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(346, 356);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 16;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // chkAutoLogin
      // 
      this.chkAutoLogin.AutoSize = true;
      this.chkAutoLogin.Location = new System.Drawing.Point(61, 177);
      this.chkAutoLogin.Name = "chkAutoLogin";
      this.chkAutoLogin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.chkAutoLogin.Size = new System.Drawing.Size(77, 17);
      this.chkAutoLogin.TabIndex = 17;
      this.chkAutoLogin.Text = "Auto Login";
      this.chkAutoLogin.UseVisualStyleBackColor = true;
      // 
      // chkAutoLaunch
      // 
      this.chkAutoLaunch.AutoSize = true;
      this.chkAutoLaunch.Location = new System.Drawing.Point(51, 200);
      this.chkAutoLaunch.Name = "chkAutoLaunch";
      this.chkAutoLaunch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.chkAutoLaunch.Size = new System.Drawing.Size(87, 17);
      this.chkAutoLaunch.TabIndex = 18;
      this.chkAutoLaunch.Text = "Auto Launch";
      this.chkAutoLaunch.UseVisualStyleBackColor = true;
      // 
      // chkRememberPassword
      // 
      this.chkRememberPassword.AutoSize = true;
      this.chkRememberPassword.Location = new System.Drawing.Point(12, 223);
      this.chkRememberPassword.Name = "chkRememberPassword";
      this.chkRememberPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.chkRememberPassword.Size = new System.Drawing.Size(126, 17);
      this.chkRememberPassword.TabIndex = 19;
      this.chkRememberPassword.Text = "Remember Password";
      this.chkRememberPassword.UseVisualStyleBackColor = true;
      // 
      // SettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(514, 391);
      this.Controls.Add(this.chkRememberPassword);
      this.Controls.Add(this.chkAutoLaunch);
      this.Controls.Add(this.chkAutoLogin);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.cbAuth);
      this.Controls.Add(this.lblAuth);
      this.Controls.Add(this.cbDatacenter);
      this.Controls.Add(this.lblDatacenter);
      this.Controls.Add(this.btnFindLotroExe);
      this.Controls.Add(this.txtLotroExe);
      this.Controls.Add(this.lblLotroExe);
      this.Controls.Add(this.btnFindDdoExe);
      this.Controls.Add(this.txtDdoExe);
      this.Controls.Add(this.lblDdoExe);
      this.Controls.Add(this.cbGame);
      this.Controls.Add(this.lblGame);
      this.Name = "SettingsForm";
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.SettingsForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblGame;
    private System.Windows.Forms.ComboBox cbGame;
    private System.Windows.Forms.Label lblDdoExe;
    private System.Windows.Forms.TextBox txtDdoExe;
    private System.Windows.Forms.Button btnFindDdoExe;
    private System.Windows.Forms.OpenFileDialog ofdDdoExe;
    private System.Windows.Forms.Button btnFindLotroExe;
    private System.Windows.Forms.TextBox txtLotroExe;
    private System.Windows.Forms.Label lblLotroExe;
    private System.Windows.Forms.OpenFileDialog ofdLotroExe;
    private System.Windows.Forms.ComboBox cbDatacenter;
    private System.Windows.Forms.Label lblDatacenter;
    private System.Windows.Forms.ComboBox cbAuth;
    private System.Windows.Forms.Label lblAuth;
    private System.Windows.Forms.OpenFileDialog ofdLocalLotroExe;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox chkAutoLogin;
    private System.Windows.Forms.CheckBox chkAutoLaunch;
    private System.Windows.Forms.CheckBox chkRememberPassword;
  }
}