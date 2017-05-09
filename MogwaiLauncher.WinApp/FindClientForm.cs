using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MogwaiLauncher.WinApp
{
  public partial class FindClientForm : Form
  {
    public FindClientForm()
    {
      InitializeComponent();
    }

    private void FindClientForm_Load(object sender, EventArgs e)
    {
      string clients = Settings.GameClients;
      string[] clientArray = clients.Split('|');
      foreach (string client in clientArray)
        if (!string.IsNullOrEmpty(client))
          lbClients.Items.Add(client);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "Turbine Game Clients|TurbineLauncher.exe.config";
      if (ofd.ShowDialog() == DialogResult.OK)
        lbClients.Items.Add(System.IO.Path.GetDirectoryName(ofd.FileName));
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (lbClients.SelectedIndex > -1)
        lbClients.Items.RemoveAt(lbClients.SelectedIndex);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      string clients = null;
      foreach (string client in lbClients.Items)
        clients = (clients + "|" ?? "") + client;
      Settings.GameClients = clients;
      this.Close();
    }
  }
}
