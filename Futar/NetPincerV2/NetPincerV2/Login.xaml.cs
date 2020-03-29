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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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
            // ask server to save this ip adress
            // send datas to server and wait for response
            // if login failed notify user else:

            string message_to_send = "logincourier" + ";" +UserData.GetInstance().Database_ID+";" + name.Text + ";" + pwd.Text;
            try
            {
                string response = Server_connection.GetInstance().SendMessageToServer(message_to_send, true);

                if (response == "accepted")
                {
                    MainMenu mm = new MainMenu();
                    mm.Show();
                    this.Close();
                }
                else
                {
                    if (response == "failed")
                    {
                        MessageBox.Show("Rosz adatok");
                    }
                    else
                    { MessageBox.Show("Adatbázis hiba"); }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hiba");
            }
        }
    }
}
