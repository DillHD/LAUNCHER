using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Net;
using System.Windows;
using System.Net.NetworkInformation;
using System.IO;
using System.IO.Compression;

namespace WpfApp1

{

    public static class Launcher
    {
        private static ZipArchive ZipArchive;

        public static void PlayGame()
        {
            var enviromentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            //iS THE GAME INSTALLED? IF SO CHECK FOR UPDATES
            if (File.Exists(enviromentPath + "\\Bin\\MEGAFIELD.exe"))
            {
                var LatestLauncherVersionURL = "http://megafieldgame.x10.mx/game/Win64/bin/GameVersion.txt";
                var LatestLauncherVersion = (new WebClient()).DownloadString(LatestLauncherVersionURL);

                string v1 = LatestLauncherVersion;
                string v2 = System.IO.File.ReadAllText(enviromentPath + "//bin//gamevers.txt");

                var version1 = new Version(v1);
                var version2 = new Version(v2);

                var result = version1.CompareTo(version2);
                if (result > 0)
                    updateGame();
                else if (result < 0)
                    updateGame();
                else
                    Process.Start("//bin//MEGAFIELD.exe");

                return;
            }
            else
            {
                installGame();
            }
        }
               public static void installGame()
        {
            var enviromentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var downloadPath = enviromentPath + "\\temp";
            var extractPath = enviromentPath;
            string url = "http://megafieldgame.x10.mx/game/Win64/Win64.zip";
            string filename = getFilename(url);

            using (var client = new WebClient())
            {
                client.DownloadFile(url, downloadPath + "/" + filename);

            }

            if (Directory.Exists(enviromentPath + "\\Bin"))
            {
                Directory.Delete(enviromentPath + "\\Bin", false);
                ZipFile.ExtractToDirectory(downloadPath + "\\Win64.zip", extractPath);
            }
            else
            {

                ZipFile.ExtractToDirectory(downloadPath + "\\Win64.zip", extractPath);
            }
        }
        //IF AN UPDAATE IS AAVAILBLE THIS WILL EXECUTE
        public static void updateGame()
        {
            var enviromentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var downloadPath = enviromentPath + "\\temp";
            var extractPath = enviromentPath;
            string url = "http://megafieldgame.x10.mx/game/Win64/Win64.zip";
            string filename = getFilename(url);

            using (var client = new WebClient())
            {
                client.DownloadFile(url, downloadPath + "/" + filename);

            }

            if (Directory.Exists(enviromentPath + "\\Bin\\MEGAFIELD\\Content\\Paks")){
                Directory.Delete(enviromentPath + "\\Bin\\MEGAFIELD\\Content\\Paks", false);
                ZipFile.ExtractToDirectory(downloadPath + "\\Win64.zip", extractPath);
            }
            else
            {
                
                ZipFile.ExtractToDirectory(downloadPath + "\\Win64.zip", extractPath);
            }
            
            
        }
       

            //IF A LAUNCHER UPDATE IS AVAIALBLE THIS WILL EXECUTE
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
            string v2 = System.IO.File.ReadAllText("launcherversion.txt");

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


    