using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using MogwaiLauncher.WinApp.Turbine.GLS;
using MogwaiLauncher.WinApp.Turbine.GLS.Auth;

namespace MogwaiLauncher.WinApp
{
    public class LauncherData
    {
        private string gameName;
        public string GameName
        { get { return gameName; } }

        private string dataCenterServer;
        public string DataCenterServer
        { get { return dataCenterServer; } }

        private static ConfigXmlDocument dataCenterConfig;

        public LauncherData()
          : this(System.IO.Directory.GetCurrentDirectory())
        {
        }

        public LauncherData(string workingDir)
        {
            dataCenterConfig = new ConfigXmlDocument();
            dataCenterConfig.Load(System.IO.Path.Combine(workingDir, "TurbineLauncher.exe.config"));
            gameName = GetAppSetting(dataCenterConfig, "DataCenter.GameName");
            dataCenterServer = GetAppSetting(dataCenterConfig, "Launcher.DataCenterService.GLS");

            GLSDatacenterInfoServer svc = new GLSDatacenterInfoServer();
            svc.Url = dataCenterServer;
            Datacenter[] dc = svc.GetDatacenters(gameName);
            dataCenter = dc[0];

            dataCenterConfig = new ConfigXmlDocument();
            dataCenterConfig.Load(dataCenter.LauncherConfigurationServer);
            dataCenterSettings = new Dictionary<string, string>();
            foreach (XmlNode node in dataCenterConfig["configuration"]["appSettings"].ChildNodes)
                if (node.Attributes != null)
                    dataCenterSettings.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);

            worlds = dataCenter.Worlds.ToDictionary(w => w.Name, w => w);
        }

        private Datacenter dataCenter = null;
        public Datacenter DataCenter
        {
            get { return dataCenter; }
        }

        private Dictionary<string, World> worlds = new Dictionary<string, World>();
        public Dictionary<string, World> Worlds
        {
            get { return worlds; }
        }

        private Dictionary<string, string> dataCenterSettings = new Dictionary<string, string>();
        internal string GetDataCenterSetting(string key)
        {
            return dataCenterSettings[key];
        }

        private string GetAppSetting(ConfigXmlDocument doc, string key)
        {
            IEnumerable<XmlNode> nodes = doc["configuration"]["appSettings"].ChildNodes.Cast<XmlNode>().Where(x => x.Attributes["key"].Value == key);
            return nodes.ToList()[0].Attributes["value"].Value;
        }

    }
}
