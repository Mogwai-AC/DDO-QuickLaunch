using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LocalLauncher.WinApp
{
  public partial class SettingsForm : Form
  {
    public SettingsForm()
    {
      InitializeComponent();
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
      cbDatacenter.DataSource = Settings.DatacenterEndpoints;
      cbDatacenter.DisplayMember = "Key";
      cbDatacenter.ValueMember = "Value";

      cbAuth.DataSource = Settings.AuthEndpoints;
      cbAuth.DisplayMember = "Key";
      cbAuth.ValueMember = "Value";

      LoadSettings();
    }

    private void LoadSettings()
    {
      if (!string.IsNullOrEmpty(Settings.AuthEndpoint))
        cbAuth.SelectedValue = Settings.AuthEndpoint;
      if (!string.IsNullOrEmpty(Settings.DatacenterEndpoint))
        cbDatacenter.SelectedValue = Settings.DatacenterEndpoint;
      if (!string.IsNullOrEmpty(Settings.Game))
        cbGame.SelectedIndex = cbGame.FindStringExact(Settings.Game);
      txtDdoExe.Text = Settings.DdoExe;
      txtLotroExe.Text = Settings.LotroExe;
      chkAutoLaunch.Checked = Settings.AutoLaunch;
      chkAutoLogin.Checked = Settings.AutoLogin;
      chkRememberPassword.Checked = Settings.RememberMe;
    }

    private void SaveSettings()
    {
      Settings.AuthEndpoint = (string)cbAuth.SelectedValue;
      Settings.DatacenterEndpoint = (string)cbDatacenter.SelectedValue;
      Settings.Game = cbGame.Text;
      Settings.LotroExe = txtLotroExe.Text;
      Settings.DdoExe = txtDdoExe.Text;
      Settings.AutoLaunch = chkAutoLaunch.Checked;
      Settings.AutoLogin = chkAutoLogin.Checked;
      Settings.RememberMe = chkRememberPassword.Checked;
    }

    private void btnFindDdoExe_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(txtDdoExe.Text))
        ofdDdoExe.FileName = txtDdoExe.Text;
      ofdDdoExe.ShowDialog();
      txtDdoExe.Text = ofdDdoExe.FileName;
    }

    private void btnFindLotroExe_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(txtLotroExe.Text))
        ofdLotroExe.FileName = txtLotroExe.Text;
      ofdLotroExe.ShowDialog();
      txtLotroExe.Text = ofdLotroExe.FileName;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      LoadSettings();

      if (ValidateData())
        this.Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (ValidateData())
      {
        SaveSettings();
        this.Close();
      }
    }

    private bool ValidateData()
    {
      if (string.IsNullOrEmpty(cbGame.Text))
      {
        MessageBox.Show("Please select a Game");
        return false;
      }

      if (string.IsNullOrEmpty((string)cbDatacenter.SelectedValue))
      {
        MessageBox.Show("Please select a Datacenter");
        return false;
      }

      if (string.IsNullOrEmpty((string)cbAuth.SelectedValue))
      {
        MessageBox.Show("Please select an Auth");
        return false;
      }
      return true;
    }
  }
}
