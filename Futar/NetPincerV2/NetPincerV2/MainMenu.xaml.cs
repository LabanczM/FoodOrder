using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace NetPincerV2
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Server_connection.GetInstance().SendMessageToServer("setactive;0;" + UserData.GetInstance().Database_ID, true);
                Server_connection.GetInstance().SendMessageToServer("closethisclient;" + UserData.GetInstance().Database_ID + ",C");

                UserData.GetInstance().SetDefault();
                Server_connection.SetDefault();
            }
            catch (Exception)
            {
            }            
        }
        
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List l = new List();
            l.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }
    }
}
