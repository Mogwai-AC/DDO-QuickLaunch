using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using MogwaiLauncher.WinApp.Turbine.GLS;
using MogwaiLauncher.WinApp.Turbine.GLS.Auth;
using System.Xml;

namespace MogwaiLauncher.WinApp
{
    internal class Util
    {
        private static byte[] entropicData = { 152, 81, 248, 49, 24, 55, 146, 133 };

        public static string HttpPost(string uri, string parameters)
        {
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            webRequest.ContentLength = bytes.Length;

            using (Stream os = webRequest.GetRequestStream())
                os.Write(bytes, 0, bytes.Length);

            WebResponse webResponse = webRequest.GetResponse();
            if (webResponse == null)
                return null;
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();

        } // end HttpPost 

        public static Dictionary<string, XmlDocument> GetWorldStatuses(List<World> worlds)
        {
            Dictionary<string, XmlDocument> worldStatuses = new Dictionary<string, XmlDocument>();
            foreach (World world in worlds)
                worldStatuses.Add(world.Name, GetWorldStatus(world));
            return worldStatuses;
        }

        public static XmlDocument GetWorldStatus(World world)
        {
            XmlDocument serverStatus = new XmlDocument();
            serverStatus.Load(world.StatusServerUrl);
            return serverStatus;
        }

        public static long GetNowServingNumber(World world)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(world.StatusServerUrl);
            return Convert.ToInt64(doc["Status"]["nowservingqueuenumber"].InnerText.Substring(2), 16);
        }

        public static string EncryptString(string clearText)
        {
            byte[] decryptedTextBytes = ASCIIEncoding.ASCII.GetBytes(clearText);
            byte[] encryptedTextBytes = ProtectedData.Protect(decryptedTextBytes, entropicData, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedTextBytes);
        }

        public static string DecryptString(string encryptedText)
        {
            try
            {
                byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
                byte[] decryptedTextBytes = ProtectedData.Unprotect(encryptedTextBytes, entropicData, DataProtectionScope.CurrentUser);
                return ASCIIEncoding.ASCII.GetString(decryptedTextBytes);
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
