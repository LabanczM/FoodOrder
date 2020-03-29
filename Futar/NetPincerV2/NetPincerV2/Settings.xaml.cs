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

namespace NetPincerV2
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            if (UserData.GetInstance().Availability)
            {
                elerhetoseg.Background = Brushes.Green;
            }
            else
            {
                elerhetoseg.Background = Brushes.Red;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reg r = new Reg();
            r.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string message_back = "";
            if (UserData.GetInstance().Availability)
            {
                message_back = Server_connection.GetInstance().SendMessageToServer("setactive;0;" + UserData.GetInstance().Database_ID, true);
            }
            else
            {
                message_back = Server_connection.GetInstance().SendMessageToServer("setactive;1;" + UserData.GetInstance().Database_ID, true);
            }

            if (message_back == "OK" && UserData.GetInstance().Availability)
            {
                elerhetoseg.Background = Brushes.Red;
                UserData.GetInstance().Availability = false;
                return;
            }
            if (message_back == "OK" && !UserData.GetInstance().Availability)
            {
                elerhetoseg.Background = Brushes.Green;
                UserData.GetInstance().Availability = true;
                return;
            }

            MessageBox.Show("Hiba");
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
