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
            diroutput.Text = enviromentPath;

            var gameVersion = System.IO.File.ReadAllText("gamevers.txt");
            DisplayGameVersion.Text = gameVersion;

            //Get Game Version Online
            var gameVersionURL = "http://megafieldgame.x10.mx/game/Win64/bin/GameVersion.txt";
            var OnlineGameVersion = (new WebClient()).DownloadString(gameVersionURL);

            DisplayOnlineGameVersion.Text = OnlineGameVersion;


            //get launcher version online
            var launcherVersionURL = "http://megafieldgame.x10.mx/launcher/LauncherVersion.txt";
            var textFromFile = (new WebClient()).DownloadString(launcherVersionURL);
            LatestLauncherVersionText.Text = textFromFile;

            //get local launcher version
            var launcherVersion = System.IO.File.ReadAllText("launcherversion.txt");
            LauncherVersion.Text = launcherVersion;

          
            



        



                //compare GAME online version and local version to decide if we need an update
                if (gameVersion != gameVersionURL)
            {
                playButton.Content = "PLAY";
            }
            else
            {
                playButton.Content = "UPDATEg";

            }
            
        }


      


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Launcher.PlayGame();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Info win2 = new Info();
            win2.Show();


        }
    }
 

}


