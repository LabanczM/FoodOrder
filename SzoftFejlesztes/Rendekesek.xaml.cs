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
    /// Interaction logic for Rendekesek.xaml
    /// </summary>
    /// 
    class Rendeles
    {
        private int id;
        private string datum;
        private string vasarlo;
        private string vasarlo_cim;
        private double ar;
        private string etel;

        public int Id { get => id; set => id = value; }
        public string Datum { get => datum; set => datum = value; }
        public string Vasarlo { get => vasarlo; set => vasarlo = value; }
        public string Vasarlo_Cim { get => vasarlo_cim; set => vasarlo_cim = value; }
        public double Ar { get => ar; set => ar = value; }
        public string Etel { get => etel; set => etel = value; }
        public Rendeles(int v1, string v2, string v3, string v4, double v5, string v6)
        {
            this.id = v1;
            this.datum = v2;
            this.vasarlo = v3;
            this.vasarlo_cim = v4;
            this.ar = v5;
            this.etel = v6;
        }
    }
    public partial class Rendekesek : Window
    {
        public Rendekesek()
        {
            InitializeComponent();
        }
        public void KiListaz()
        {
            List<Rendeles> rendelesek = new List<Rendeles>();

            string message_to_send = "getordersR;" + UserData.GetInstance().Database_ID;
            string response = Server_connection.GetInstance().SendMessageToServer(message_to_send, true);

            response = response.Remove(response.Length - 1);
            if (response == "NoDat")
                MessageBox.Show("Nincs beérkező rendelés");
            else if (response != "failed")
            {
                foreach (var item in response.Split('?'))
                {
                    string[] elemek = item.Split(';');
                    rendelesek.Add(new Rendeles(Convert.ToInt32(elemek[0]), elemek[1], elemek[2], elemek[3], Convert.ToDouble(elemek[4]), elemek[5]));
                }
            }
            else
            {
                MessageBox.Show("Hiba");
            }

            /*message_to_send = "getfutar";
            response = Server_connection.GetInstance().SendMessageToServer(message_to_send, true);

            response = response.Remove(response.Length - 1);
            if (response != "failed")
            {
                foreach (var item in response.Split('?'))
                {
                    fut_ls.Items.Add(item.Split(';')[1] + ", " + item.Split(';')[5]);
                }
            }
            else
            {
                MessageBox.Show("Hiba");
            }*/

            rend_list.ItemsSource = rendelesek;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FoMenu fm = new FoMenu();
            fm.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
