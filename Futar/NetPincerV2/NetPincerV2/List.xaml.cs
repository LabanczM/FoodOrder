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
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Window
    {

        private class RendelesClass
        {
            private int id;
            private DateTime date;
            private string name;
            private string address;
            private string cost;

            public RendelesClass(string id, string date,string name, string address,string cost)
            {
                this.id = Convert.ToInt32(id);
                this.date =  Convert.ToDateTime(date);
                this.name = name;
                this.address = address;
                this.cost = cost;
            }

            public int Id { get => id; set => id = value; }
            public DateTime Date { get => date; set => date = value; }
            public string Name { get => name; set => name = value; }
            public string Address { get => address; set => address = value; }
            public string Cost { get => cost; set => cost = value; }
        }


        private int list_selected_item_index = -1;

        private static List<RendelesClass> rendelesek = new List<RendelesClass>();

        public List()
        {
            InitializeComponent();
            if(rendelesek.Count == 0) Fill_list();
            else rendeles.ItemsSource = rendelesek;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (list_selected_item_index != -1)
            {
                string messageback = Server_connection.GetInstance().SendMessageToServer("cancelorderC;" + UserData.GetInstance().Database_ID+";"+rendelesek[list_selected_item_index].Id, true);

                if (messageback != "failed" && messageback != "Error")
                {
                    MessageBox.Show("Leadás sikeres");
                    rendelesek.RemoveAt(list_selected_item_index);
                    rendeles.ItemsSource = null;
                    rendeles.ItemsSource = rendelesek;
                }
                else
                {
                    if (messageback == "failed") MessageBox.Show("Nem lehet leadni");
                    else MessageBox.Show("Adatbázis hiba");
                }
            }
        }

        private void Fill_list()
        {
            
            string messageback = Server_connection.GetInstance().SendMessageToServer("getordersC;" + UserData.GetInstance().Database_ID, true);

            if (messageback != "failed" && messageback != "Error")
            {
                foreach (var item in messageback.Split('?'))
                {
                    rendelesek.Add(new RendelesClass(item.Split(';')[0], item.Split(';')[1], item.Split(';')[2], item.Split(';')[3], item.Split(';')[4]));
                }
            }
            else
            {
                if (messageback == "failed") MessageBox.Show("Nincs rendelés");
                else rendeles.Items.Add("Adatbázis hiba");
            }

            rendeles.ItemsSource = null;
            rendeles.ItemsSource = rendelesek;

        }

        private void Rendeles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list_selected_item_index = rendeles.SelectedIndex;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // rákérdezés


            if (list_selected_item_index != -1)
            {
                string message = Server_connection.GetInstance().SendMessageToServer("szall_fin;" + UserData.GetInstance().Database_ID + ";" + rendelesek[list_selected_item_index].Id,true);
                if (message == "OK") MessageBox.Show("Elfogadva");
                else if (message == "failed") MessageBox.Show("Nincs másik futár.");
                else MessageBox.Show("Adatbázis hiba");
                rendelesek.RemoveAt(list_selected_item_index);
                rendeles.ItemsSource = null;
                rendeles.ItemsSource = rendelesek;
            }
        }
    }
}
