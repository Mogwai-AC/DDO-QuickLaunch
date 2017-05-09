using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace MogwaiLauncher.WinApp
{
  internal static class Settings
  {
    public static bool SaveUsername
    {
      get
      {
        bool b;
        if (bool.TryParse(ConfigurationManager.AppSettings["SaveUsername"], out b))
          return b;
        else
          return false;
      }
      set { UpdateAppSetting("SaveUsername", value.ToString()); }
    }

    public static bool SavePassword
    {
      get
      {
        bool b;
        if (bool.TryParse(ConfigurationManager.AppSettings["SavePassword"], out b))
          return b;
        else
          return false;
      }
      set { UpdateAppSetting("SavePassword", value.ToString()); }
    }

    public static string GameClients
    {
      get { return ConfigurationManager.AppSettings["GameClients"]; }
      set { UpdateAppSetting("GameClients", value); }
    }

    public static string CurrentClient
    {
      get { return ConfigurationManager.AppSettings["CurrentClient"]; }
      set { UpdateAppSetting("CurrentClient", value); }
    }

    public static string DefaultWorld
    {
      get { return ConfigurationManager.AppSettings["DefaultWorld"]; }
      set { UpdateAppSetting("DefaultWorld", value); }
    }

    public static string DefaultSubscription
    {
      get { return ConfigurationManager.AppSettings["DefaultSubscription"]; }
      set { UpdateAppSetting("DefaultSubscription", value); }
    }

    public static string Username
    {
      get
      {
        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Username"]))
          return Util.DecryptString(ConfigurationManager.AppSettings["Username"]);
        else
          return string.Empty;
      }
      set { UpdateAppSetting("Username", Util.EncryptString(value)); }
    }

    public static string Password
    {
      get
      {
        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Password"]))
          return Util.DecryptString(ConfigurationManager.AppSettings["Password"]);
        else
          return string.Empty;
      }
      set { UpdateAppSetting("Password", Util.EncryptString(value)); }
    }

    private static void UpdateAppSetting(string key, string value)
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

  }
}
