using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Futarok.xaml
    /// </summary>
    
    
    class Futar
    {
        private string name;
        private string city;
        private string tel;
        private string driver_l;
        private int database_ID;
        private string email;

        public int Database_ID { get => database_ID; set => database_ID = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Email { get => email; set => email = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Driver_L { get => driver_l; set => driver_l = value; }

        public Futar()
        {

        }

        public Futar(int v1, string v2, string v3, string v4, string v5, string v6)
        {
            this.database_ID = v1;
            this.name = v2;
            this.city = v3;
            this.driver_l = v4;
            this.email = v5;
            this.tel = v6;
        }
    }
    public partial class Futarok : Window
    {
        public Futarok()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        //futáraok datagridbe
        public void KiListaz()
        {
            List<Futar> futarok = new List<Futar>();

            string message_to_send = "getfutar";
            string response = Server_connection.GetInstance().SendMessageToServer(message_to_send, true);

            response = response.Remove(response.Length - 1);
            if (response != "failed")
            {
                foreach (var item in response.Split('?'))
                {
                    string[] elemek = item.Split(';');
                    futarok.Add(new Futar(Convert.ToInt32(elemek[0]), elemek[1], elemek[2], elemek[3], elemek[4], elemek[5]));
                }
            }
            else
            {
                MessageBox.Show("Hiba");
            }

            fut_list.ItemsSource = futarok;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FoMenu fm = new FoMenu();
            fm.Show();
            this.Close();
        }
    }
}
