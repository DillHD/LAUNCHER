using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.IO.Compression;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();
            
            var enviromentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var exePath = enviromentPath + "\\megafield.exe";
            

            var gameVersion = System.IO.File.ReadAllText(enviromentPath + "\\bin\\gamevers.txt");
            DisplayGameVersion.Text = gameVersion;

            //Get Game Version Online
            var gameVersionURL = "http://megafieldgame.x10.mx/game/Win64/bin/GameVersion.txt";
            var OnlineGameVersion = (new WebClient()).DownloadString(gameVersionURL);

            DisplayOnlineGameVersion.Text = OnlineGameVersion;


            //get launcher version online
            var launcherVersionURL = "http://megafieldgame.x10.mx/launcher/LauncherVersion.txt";
            var textFromFile = (new WebClient()).DownloadString(launcherVersionURL);
            

            //get local launcher version
            var launcherVersion = System.IO.File.ReadAllText("launcherversion.txt");
            LauncherVersion.Text = launcherVersion;


            // Ping's the local machine.
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send("www.megafieldgsssame.x10.mx");

            if (reply.Status == IPStatus.Success)
            {
                serverStatus.Text = "ONLINE";
                serverStatus.Foreground = Brushes.Green;
            }
            else {
                serverStatus.Text = "OFFLINE";
                serverStatus.Foreground = Brushes.Red;
            }

            
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
                {
                    playButton.Content = "UPDATE";
                }
                else if (result < 0)
                    playButton.Content = "UPDATE";
                else
                    playButton.Content = "PLAY";
                return;

            }
            else
            {
                playButton.Content = "INSTALL";
            }
        }
            
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Launcher.PlayGame();
            updateGame();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Info win2 = new Info();
            win2.Show();


        }
        bool isDownloadActive = false;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(isDownloadActive){
                MessageBox.Show("A download is a progress, are you sure you want to exit?", "Download in progress");
            }
            isDownloadActive = !isDownloadActive;
            if (!isDownloadActive)
            {
                this.Close();
            }
            
        }

        //IF AN UPDAATE IS AAVAILBLE THIS WILL EXECUTE
        private static string getFilename(string hreflink)
        {
            Uri uri = new Uri(hreflink);

            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            return filename;
        }
        /// <summary>
        /// //////////
        /// </summary>
        public void updateGame()
        {

            var enviromentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var downloadPath = enviromentPath + "\\temp";
            var extractPath = enviromentPath;
            string url = "http://megafieldgame.x10.mx/game/Win64/blunder.txt";
            string filename = getFilename(url);

            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += (s, e) =>
            {
                playButton.Content = "UPDATING...";
                loadingBar.Value = e.ProgressPercentage;
            };
            webClient.DownloadFileCompleted += (s, e) =>
            {
                // any other code to process the file
                MessageBox.Show("Download done");
                playButton.Content = "PLAY";

            };
            webClient.DownloadFileAsync(new Uri(url),
                downloadPath + "/" + filename);

           


        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void ProgressBar_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
 

}


