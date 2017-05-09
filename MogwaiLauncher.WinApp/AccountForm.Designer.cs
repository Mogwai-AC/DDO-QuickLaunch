namespace LocalLauncher.WinApp
{
  partial class AccountForm
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
      this.btnGetAccountSubs = new System.Windows.Forms.Button();
      this.lblAccountName = new System.Windows.Forms.Label();
      this.txtAccountName = new System.Windows.Forms.TextBox();
      this.lblPassword = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.btnAuthenticate = new System.Windows.Forms.Button();
      this.btnRegister = new System.Windows.Forms.Button();
      this.lbSubs = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // btnGetAccountSubs
      // 
      this.btnGetAccountSubs.Location = new System.Drawing.Point(201, 64);
      this.btnGetAccountSubs.Name = "btnGetAccountSubs";
      this.btnGetAccountSubs.Size = new System.Drawing.Size(75, 23);
      this.btnGetAccountSubs.TabIndex = 0;
      this.btnGetAccountSubs.Text = "Get Subs";
      this.btnGetAccountSubs.UseVisualStyleBackColor = true;
      this.btnGetAccountSubs.Click += new System.EventHandler(this.btnGetAccountSubs_Click);
      // 
      // lblAccountName
      // 
      this.lblAccountName.AutoSize = true;
      this.lblAccountName.Location = new System.Drawing.Point(33, 15);
      this.lblAccountName.Name = "lblAccountName";
      this.lblAccountName.Size = new System.Drawing.Size(78, 13);
      this.lblAccountName.TabIndex = 1;
      this.lblAccountName.Text = "Account Name";
      // 
      // txtAccountName
      // 
      this.txtAccountName.Location = new System.Drawing.Point(117, 12);
      this.txtAccountName.Name = "txtAccountName";
      this.txtAccountName.Size = new System.Drawing.Size(159, 20);
      this.txtAccountName.TabIndex = 2;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Location = new System.Drawing.Point(58, 41);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(53, 13);
      this.lblPassword.TabIndex = 3;
      this.lblPassword.Text = "Password";
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(117, 38);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(159, 20);
      this.txtPassword.TabIndex = 4;
      // 
      // btnAuthenticate
      // 
      this.btnAuthenticate.Location = new System.Drawing.Point(38, 63);
      this.btnAuthenticate.Name = "btnAuthenticate";
      this.btnAuthenticate.Size = new System.Drawing.Size(75, 23);
      this.btnAuthenticate.TabIndex = 5;
      this.btnAuthenticate.Text = "Authenticate";
      this.btnAuthenticate.UseVisualStyleBackColor = true;
      this.btnAuthenticate.Click += new System.EventHandler(this.btnAuthenticate_Click);
      // 
      // btnRegister
      // 
      this.btnRegister.Location = new System.Drawing.Point(120, 64);
      this.btnRegister.Name = "btnRegister";
      this.btnRegister.Size = new System.Drawing.Size(75, 23);
      this.btnRegister.TabIndex = 6;
      this.btnRegister.Text = "Register";
      this.btnRegister.UseVisualStyleBackColor = true;
      this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
      // 
      // lbSubs
      // 
      this.lbSubs.FormattingEnabled = true;
      this.lbSubs.Location = new System.Drawing.Point(12, 93);
      this.lbSubs.Name = "lbSubs";
      this.lbSubs.Size = new System.Drawing.Size(264, 95);
      this.lbSubs.TabIndex = 7;
      // 
      // AccountForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(296, 204);
      this.Controls.Add(this.lbSubs);
      this.Controls.Add(this.btnRegister);
      this.Controls.Add(this.btnAuthenticate);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.lblPassword);
      this.Controls.Add(this.txtAccountName);
      this.Controls.Add(this.lblAccountName);
      this.Controls.Add(this.btnGetAccountSubs);
      this.MaximizeBox = false;
      this.Name = "AccountForm";
      this.Text = "AccountForm";
      this.Load += new System.EventHandler(this.AccountForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnGetAccountSubs;
    private System.Windows.Forms.Label lblAccountName;
    private System.Windows.Forms.TextBox txtAccountName;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnAuthenticate;
    private System.Windows.Forms.Button btnRegister;
    private System.Windows.Forms.ListBox lbSubs;
  }
}