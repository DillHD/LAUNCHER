using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Net;
using System.Windows;


namespace WpfApp1

{
    
    class Launcher
    {
        public static void PlayGame()
        {
            Launcher.downloadFile();
        }
        public static void downloadFile()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var enviromentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var downloadPath = enviromentPath + "\\Bin";

            // Change the url by the value you want (a textbox or something else)
            string url = "http://megafieldgame.x10.mx/game/test/";
            // Get filename from URL
            string filename = getFilename(url);

            using (var client = new WebClient())
            {
                client.DownloadFile(url, downloadPath + "/" + filename);
            }

            MessageBox.Show("Download ready");
            
        }
        public static void updateLauncher()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var enviromentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var downloadPath = enviromentPath;

            // Change the url by the value you want (a textbox or something else)
            string url = "http://megafieldgame.x10.mx/launcher/";
            // Get filename from URL
            string filename = getFilename(url);

            using (var client = new WebClient())
            {
                client.DownloadFile(url, downloadPath + "/" + filename);
            }

            MessageBox.Show("Download ready");

        }

        /// <summary>
        /// Get the filename from a web url : 
        /// 
        /// www.google.com/image.png -> returns : image.png
        /// 
        /// </summary>
        /// <param name="hreflink"></param>
        /// <returns></returns>
        private static string getFilename(string hreflink)
        {
            Uri uri = new Uri(hreflink);

            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            return filename;
        }


        public static void checkForLauncherUpdates()
        {
            var LatestLauncherVersionURL = "http://megafieldgame.x10.mx/launcher/LauncherVersion.txt";
            var LatestLauncherVersion = (new WebClient()).DownloadString(LatestLauncherVersionURL);

            string v1 = LatestLauncherVersion;
            string v2 =  System.IO.File.ReadAllText("launcherversion.txt");

            var version1 = new Version(v1);
            var version2 = new Version(v2);

            var result = version1.CompareTo(version2);
            if (result > 0)
                MessageBox.Show("Version is lower",
            "Launcher Update");
            else if (result < 0)
                MessageBox.Show("Version is higher",
            "Launcher Update");
            else
                MessageBox.Show("Launcher is up to date!",
            "Launcher Update");
            return;

        }
    }
    
        
    


}

    