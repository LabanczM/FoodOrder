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

namespace SzoftFejlesztes
{
    /// <summary>
    /// Interaction logic for MyDialog.xaml
    /// </summary>
    public partial class MyDialog : Window
    {
        public MyDialog()
        {
            InitializeComponent();
        }
        static string etterem_nev = "";
        public void EtteremBe(string etterem_neve)
        {
            etterem_nev = etterem_neve;
        }
        public void Bejelentkezes()
        {
            MessageBox.Show(etterem_nev);
            string message_to_send = "loginrestaurante" + ";" + 1 + ";" + etterem_nev + ";" + Password.Text;
            MessageBox.Show(message_to_send);
            try
            {
                string response = Server_connection.GetInstance().SendMessageToServer(message_to_send, true);
                MessageBox.Show(response);
                if (response == "accepted")
                {
                    FoMenu fm = new FoMenu();
                    fm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong datas");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Failed");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bejelentkezes();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string response = Server_connection.GetInstance().SendMessageToServer("asd;asd");

            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
