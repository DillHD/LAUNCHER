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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
            var launcherVersion2 = System.IO.File.ReadAllText("launcherversion.txt");
            launcherVersion.Text = launcherVersion2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Launcher.checkForLauncherUpdates();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
    }

}
