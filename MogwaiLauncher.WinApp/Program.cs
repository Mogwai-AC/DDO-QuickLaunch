using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace MogwaiLauncher.WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string worldName = "";
            string subscriptionName = "";
            string language = System.Globalization.CultureInfo.CurrentCulture.Parent.EnglishName;
            string username = Settings.Username;
            string password = Settings.Password;
            string clientDir = null;
            string character = null;

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg.Length > 3 && arg[0] == '/' && arg[2] == ':')
                    {
                        switch (arg[1])
                        {
                            case 'w':
                                worldName = arg.Substring(3);
                                break;
                            case 's':
                                subscriptionName = arg.Substring(3);
                                break;
                            case 'l':
                                language = arg.Substring(3);
                                break;
                            case 'u':
                                username = Util.DecryptString(arg.Substring(3));
                                break;
                            case 'p':
                                password = Util.DecryptString(arg.Substring(3));
                                break;
                            case 'd':
                                clientDir = arg.Substring(3).Replace("\"", "");
                                break;
                            case 'c':
                                character = arg.Substring(3);
                                break;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(clientDir) && System.IO.Directory.Exists(clientDir))
                System.IO.Directory.SetCurrentDirectory(clientDir);

            // validate the config file is found
            if (System.IO.File.Exists("TurbineLauncher.exe.config"))
            {
                // load launcher configuration
                LauncherData launcherData = new LauncherData();

                if (string.IsNullOrEmpty(worldName))
                    worldName = Settings.DefaultWorld;

                if (string.IsNullOrEmpty(subscriptionName))
                    subscriptionName = Settings.DefaultSubscription;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    LoginResults lr = new LoginResults(username, password, launcherData);

                    if (!string.IsNullOrEmpty(worldName) && lr.Subscriptions.Count > 0)
                    {
                        if (lr.Subscriptions.Count == 1)
                        {
                            lr.Launch(lr.Subscriptions[0].Name, worldName, language, character);
                            return;
                        }
                        else if (!string.IsNullOrEmpty(subscriptionName))
                        {
                            lr.Launch(subscriptionName, worldName, language, character);
                            return;
                        }
                    }
                }
            }

            // if we made it this far, we didn't launch yet
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LaunchForm());
        }
    }
}
