using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Web;
using MogwaiLauncher.WinApp.Turbine.GLS;
using MogwaiLauncher.WinApp.Turbine.GLS.Auth;

namespace MogwaiLauncher.WinApp
{
    internal sealed class LoginResults
    {
        private string loginTicket = null;
        private LauncherData launcherData;

        public LoginResults(string username, string password, LauncherData launcherData)
        {
            this.launcherData = launcherData;

            GlobalLoginSystemAuthenticationService authSvc = new GlobalLoginSystemAuthenticationService();
            authSvc.Url = launcherData.DataCenter.AuthServer;
            UserProfile profile = authSvc.LoginAccount(username, password, null);
            subscriptions = profile.Subscriptions.Where(s => s.Game == launcherData.GameName).ToList();
            this.loginTicket = profile.Ticket;
        }

        private List<GameSubscription> subscriptions = new List<GameSubscription>();
        public List<GameSubscription> Subscriptions
        {
            get { return subscriptions; }
            set { subscriptions = value; }
        }

        public void Launch(string world)
        {
            string language = System.Globalization.CultureInfo.CurrentCulture.EnglishName;
            Launch(subscriptions[0].Name, launcherData.Worlds[world], language);
        }

        public void Launch(string world, string language)
        {
            Launch(subscriptions[0].Name, launcherData.Worlds[world], language);
        }

        public void Launch(string subscriptionName, string world, string language)
        {
            Launch(subscriptionName, launcherData.Worlds[world], language);
        }

        public void Launch(string subscriptionName, World world, string language)
        {
            Launch(subscriptionName, world, Util.GetWorldStatus(world), language);
        }

        public void Launch(string subscriptionName, World world)
        {
            string language = System.Globalization.CultureInfo.CurrentCulture.EnglishName;
            Launch(subscriptionName, world, Util.GetWorldStatus(world), language);
        }

        public void Launch(string subscriptionName, World world, XmlDocument worldStatus)
        {
            string language = System.Globalization.CultureInfo.CurrentCulture.EnglishName;
            Launch(subscriptionName, world, worldStatus, language);
        }

        public void Launch(string subscriptionName, World world, XmlDocument worldStatus, string language)
        {
            // get a login ticket
            string loginTicketUrl = launcherData.GetDataCenterSetting("WorldQueue.LoginQueue.URL");
            string loginTicketParams = launcherData.GetDataCenterSetting("WorldQueue.TakeANumber.Parameters");
            XmlElement status = worldStatus["Status"];
            XmlElement queueUrls = status["queueurls"];
            string queueUrlsContent = queueUrls.InnerText;
            loginTicketParams = string.Format(loginTicketParams,
                                    subscriptionName,
                                    HttpUtility.UrlEncode(loginTicket),
                                    queueUrlsContent.Substring(0, queueUrlsContent.IndexOf(";")));

            if (!string.IsNullOrEmpty(queueUrlsContent) && queueUrlsContent != ";")
            {
                string loginTicketResult;
                try
                {
                    loginTicketResult = Util.HttpPost(loginTicketUrl, loginTicketParams);
                }
                catch (Exception ex)
                {
                    Exception newEx = new Exception("Error getting login ticket.", ex);
                    throw newEx;
                }

                XmlDocument loginTicketDoc = new XmlDocument();
                loginTicketDoc.LoadXml(loginTicketResult);

                long queueNumber = Convert.ToInt64(loginTicketDoc["Result"]["QueueNumber"].InnerText.Substring(2), 16);
                long nowServing = Convert.ToInt64(loginTicketDoc["Result"]["NowServingNumber"].InnerText.Substring(2), 16);

                while (nowServing < queueNumber)
                {
                    Thread.Sleep(1000);
                    nowServing = Util.GetNowServingNumber(world);
                }
            }

            string loginServers = worldStatus["Status"]["loginservers"].InnerText;

            string template = launcherData.GetDataCenterSetting("GameClient.WIN32.ArgTemplate");
            string authServerUrl = launcherData.GetDataCenterSetting("GameClient.Arg.authserverurl"); 
            string supportUrl = launcherData.GetDataCenterSetting("GameClient.Arg.supporturl");
            string bugUrl = launcherData.GetDataCenterSetting("GameClient.Arg.bugurl");
            string ticketLifetime = launcherData.GetDataCenterSetting("GameClient.Arg.glsticketlifetime");
            string serviceUrl = launcherData.GetDataCenterSetting("GameClient.Arg.supportserviceurl");

            string clientParams = template.Replace("{SUBSCRIPTION}", subscriptionName);
            clientParams = clientParams.Replace("{GLS}", loginTicket);
            clientParams = clientParams.Replace("{CHAT}", world.ChatServerUrl);
            clientParams = clientParams.Replace("{LANG}", language);
            clientParams = clientParams.Replace("{AUTHSERVERURL}", authServerUrl);
            clientParams = clientParams.Replace("{GLSTICKETLIFETIME}", ticketLifetime);
            clientParams = clientParams.Replace("{SUPPORTURL}", supportUrl);
            clientParams = clientParams.Replace("{SUPPORTSERVICEURL}", serviceUrl);
            clientParams = clientParams.Replace("{BUGURL}", bugUrl);
            
            string clientFilename = launcherData.GetDataCenterSetting("GameClient.WIN32.Filename");

            Process client = new Process();
            client.StartInfo.FileName = clientFilename;
            client.StartInfo.Arguments = clientParams;
            client.Start();
        }
    }
}
