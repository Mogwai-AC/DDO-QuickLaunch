using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using LocalLauncher.WinApp.Turbine.GLS;
using LocalLauncher.WinApp.Turbine.GLS.Auth;

namespace LocalLauncher.WinApp
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private List<World> worlds;
    private List<XmlDocument> worldStatuses;
    private List<GameSubscription> subs;
    private Dictionary<string, string> dataCenterSettings;
    private string ticket;

    #region app settings

    #endregion

    private void btnLogin_Click(object sender, EventArgs e)
    {
      Login();
    }

    private bool Login()
    {
      if (Settings.RememberMe)
      {
        Settings.Username = txtUsername.Text;
        Settings.Password = txtPassword.Text;
      }
      else
      {
        Settings.Username = "";
        Settings.Password = "";
      }

      try
      {
        GlobalLoginSystemAuthenticationService authSvc = new GlobalLoginSystemAuthenticationService();
        UserProfile profile = authSvc.LoginAccount(txtUsername.Text, txtPassword.Text, null);
        subs = profile.Subscriptions.Where(s => s.Game == Settings.Game).ToList();
        cbSub.DataSource = subs;
        ticket = profile.Ticket;

        if (!string.IsNullOrEmpty(Settings.DefaultSubscription))
          cbSub.SelectedIndex = cbSub.FindStringExact(Settings.DefaultSubscription);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        return false;
      }

      btnPlay.Enabled = true;
      return true;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      if (Settings.RememberMe)
      {
        txtUsername.Text = Settings.Username;
        txtPassword.Text = Settings.Password;
      }
      else
      {
        txtUsername.Text = "";
        txtPassword.Text = "";
      }

      btnPlay.Enabled = false;

      if (string.IsNullOrEmpty(Settings.Game))
      {
        new SettingsForm().ShowDialog();
      }

      LoadWorlds();

      if (Settings.AutoLogin && Login() && Settings.AutoLaunch && Launch())
        return; // worthless statement, but better than 4 separate if blocks
    }

    private void LoadWorlds()
    {
      try
      {
        GLSDatacenterInfoServer svc = new GLSDatacenterInfoServer();
        Datacenter[] dc = svc.GetDatacenters(Settings.Game);
        List<Datacenter> dataCenters = dc.ToList();
        worlds = dataCenters[0].Worlds.ToList();
        cbServer.DataSource = worlds;

        if (!string.IsNullOrEmpty(Settings.DefaultServer))
          cbServer.SelectedIndex = cbServer.FindStringExact(Settings.DefaultServer);

        ConfigXmlDocument cxd = new ConfigXmlDocument();
        cxd.Load(dataCenters[0].LauncherConfigurationServer);
        dataCenterSettings = new Dictionary<string, string>();
        foreach (XmlNode node in cxd["configuration"]["appSettings"].ChildNodes)
          if (node.Attributes != null)
            dataCenterSettings.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error getting datacenters\n" + ex.Message);
      }

      GetServerStatuses();
    }

    private void btnPlay_Click(object sender, EventArgs e)
    {
      Launch();
    }

    private bool Launch()
    {
      Settings.DefaultSubscription = cbSub.Text;
      Settings.DefaultServer = cbServer.Text;

      try
      {
        // get a login ticket
        string loginTicketUrl = dataCenterSettings["WorldQueue.LoginQueue.URL"];
        string loginTicketParams = dataCenterSettings["WorldQueue.TakeANumber.Parameters"];
        XmlDocument doc = worldStatuses[cbServer.SelectedIndex];
        XmlElement status = doc["Status"];
        XmlElement queueUrls = status["queueurls"];
        string queueUrlsContent = queueUrls.InnerText;
        loginTicketParams = string.Format(loginTicketParams,
                                subs[cbSub.SelectedIndex].Name,
                                HttpUtility.UrlEncode(ticket),
                                queueUrlsContent.Substring(0, queueUrlsContent.IndexOf(";")));

        if (!string.IsNullOrEmpty(queueUrlsContent) && queueUrlsContent != ";")
        {
          string loginTicketResult = HttpPost(loginTicketUrl, loginTicketParams);
          XmlDocument loginTicketDoc = new XmlDocument();
          loginTicketDoc.LoadXml(loginTicketResult);

          long queueNumber = Convert.ToInt64(loginTicketDoc["Result"]["QueueNumber"].InnerText.Substring(2), 16);
          long nowServing = Convert.ToInt64(loginTicketDoc["Result"]["NowServingNumber"].InnerText.Substring(2), 16);

          while (nowServing < queueNumber)
          {
            Thread.Sleep(1000);
            nowServing = GetNowServingNumber(cbServer.SelectedIndex);
          }
        }

        string loginServers = worldStatuses[cbServer.SelectedIndex]["Status"]["loginservers"].InnerText;

        string template = dataCenterSettings["GameClient.ArgTemplate"];
        string clientParams = string.Format(template,
            subs[cbSub.SelectedIndex].Name, // -a
            loginServers.Substring(0, loginServers.IndexOf(";")), // -h
            ticket, // --glsticketdirect 
            worlds[cbServer.SelectedIndex].ChatServerUrl, // --chatserver 
            "English"); // --language

        string clientFilename = dataCenterSettings["GameClient.Filename"];

        Process client = new Process();
        client.StartInfo.FileName = clientFilename;
        client.StartInfo.Arguments = clientParams;
        client.Start();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        return false;
      }

      return true;
    }

    private void GetServerStatuses()
    {
      worldStatuses = new List<XmlDocument>();
      foreach (World world in worlds)
      {
        XmlDocument serverStatus = new XmlDocument();
        serverStatus.Load(world.StatusServerUrl);
        worldStatuses.Add(serverStatus);
      }
    }

    private long GetNowServingNumber(int worldIndex)
    {
      worldStatuses[worldIndex] = new XmlDocument();
      worldStatuses[worldIndex].Load(worlds[worldIndex].StatusServerUrl);
      return Convert.ToInt64(worldStatuses[worldIndex]["Status"]["nowservingqueuenumber"].InnerText.Substring(2), 16);
    }

    private void UpdateAppConfig(string key, string value)
    {
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

      foreach (XmlElement node in xmlDoc["configuration"]["appSettings"].ChildNodes)
      {
        if (node.Attributes["key"].Value == key)
        {
          node.Attributes["value"].Value = value;
          break;
        }
      }

      xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
      ConfigurationManager.RefreshSection("appSettings");
    }

    private string HttpPost(string uri, string parameters)
    {
      WebRequest webRequest = WebRequest.Create(uri);
      webRequest.ContentType = "application/x-www-form-urlencoded";
      webRequest.Method = "POST";
      byte[] bytes = Encoding.ASCII.GetBytes(parameters);
      Stream os = null;
      try
      { // send the Post
        webRequest.ContentLength = bytes.Length;   //Count bytes to send
        os = webRequest.GetRequestStream();
        os.Write(bytes, 0, bytes.Length);         //Send it
      }
      catch (WebException ex)
      {
        MessageBox.Show(ex.Message, "HttpPost: Request error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      { if (os != null) os.Close(); }

      try
      { // get the response
        WebResponse webResponse = webRequest.GetResponse();
        if (webResponse == null)
          return null;
        StreamReader sr = new StreamReader(webResponse.GetResponseStream());
        return sr.ReadToEnd().Trim();
      }
      catch (WebException ex)
      {
        MessageBox.Show(ex.Message, "HttpPost: Response error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return null;
    } // end HttpPost 

    private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      new SettingsForm().ShowDialog();
    }

  }
}
