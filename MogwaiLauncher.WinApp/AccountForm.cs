using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LocalLauncher.WinApp.Turbine.GLS.Auth;
using LocalLauncher.WinApp.AmsAccountManagement;
using LocalLauncher.WinApp.AmsSubscriptionManagement;

namespace LocalLauncher.WinApp
{
  public partial class AccountForm : Form
  {
    private string amsAdminTicket;
    private string amsTicket;

    public AccountForm()
    {
      InitializeComponent();
    }

    private void btnAuthenticate_Click(object sender, EventArgs e)
    {
      AmsAuthentication.AmsAuthentication client = new LocalLauncher.WinApp.AmsAuthentication.AmsAuthentication();
      try
      {
        AmsAuthentication.Credential cred = new LocalLauncher.WinApp.AmsAuthentication.Credential();
        cred.UserName = txtAccountName.Text;
        cred.Secret = txtPassword.Text;
        amsTicket = client.Authenticate(cred);
        if (string.IsNullOrEmpty(amsTicket))
          MessageBox.Show("Authentication Fail!");
        else
        {
          btnGetAccountSubs.Enabled = true;
          MessageBox.Show("Authentication Success!");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Authentication Fail!\n" + ex.Message);
      }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
      AmsAccountManagement.AmsAccountManagement client = new AmsAccountManagement.AmsAccountManagement();
      NewAccountInformation info = new NewAccountInformation();
      info.Name = txtAccountName.Text;
      info.Secret = txtPassword.Text;
      AccountInformation account = client.CreateAccount(amsAdminTicket, info);

      if (account != null && account.AccountId != Guid.Empty)
        MessageBox.Show("Account Creation Success!");
      else
        MessageBox.Show("Account Creation Fail!");
    }

    private void AccountForm_Load(object sender, EventArgs e)
    {
      btnGetAccountSubs.Enabled = false;
      AmsAuthentication.AmsAuthentication client = new LocalLauncher.WinApp.AmsAuthentication.AmsAuthentication();
      try
      {
        AmsAuthentication.Credential cred = new LocalLauncher.WinApp.AmsAuthentication.Credential();
        cred.UserName = Settings.AmsAdminUsername;
        cred.Secret = Settings.AmsAdminPassword;
        amsAdminTicket = client.Authenticate(cred);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Admin Authentication Failure!  Please check your admin username and password settings.\n" + ex.Message);
        this.Close();
      }
    }

    private void btnGetAccountSubs_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(amsTicket))
      {
        MessageBox.Show("Please Log in first");
        return;
      }

      AmsSubscriptionManagement.AmsSubscriptionManagement client = new LocalLauncher.WinApp.AmsSubscriptionManagement.AmsSubscriptionManagement();
      SubscriptionInformation[] subs = client.EnumerateSubscriptionsByAccount(amsTicket, txtAccountName.Text);
      lbSubs.DataSource = subs;
      lbSubs.DisplayMember = "Name";
      
    }

  }
}
