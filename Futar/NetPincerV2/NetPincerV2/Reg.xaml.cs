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
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
            if (UserData.GetInstance().Database_ID != -1)
            {
                nev.Text = UserData.GetInstance().Name;
                datum.Text = UserData.GetInstance().Date;
                varos.Text = UserData.GetInstance().City;
                jogsi.Text = UserData.GetInstance().Driver_L;
                email.Text = UserData.GetInstance().Email;
                tel.Text = UserData.GetInstance().Tel;
                jelso.Text = UserData.GetInstance().Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (StringEll())
            {
                if (UserData.GetInstance().Database_ID != -1)
                {
                    string message = "updateC;" + nev.Text + ";" + datum.Text + ";" + varos.Text + ";" + jogsi.Text + ";" + email.Text + ";" + tel.Text + ";" + jelso.Text + ";" + UserData.GetInstance().Database_ID;
                    string message_back = Server_connection.GetInstance().SendMessageToServer(message, true);

                    if (message_back == "OK")
                    {
                        MessageBox.Show("Adatváltoztatás sikerült");

                        UserData.GetInstance().Name = nev.Text;
                        UserData.GetInstance().City = varos.Text;
                        UserData.GetInstance().Date = datum.Text;
                        UserData.GetInstance().Driver_L = jogsi.Text;
                        UserData.GetInstance().Email = email.Text;
                        UserData.GetInstance().Tel = tel.Text;
                        UserData.GetInstance().Password = jelso.Text;

                        this.Close();
                        return;
                    }

                    MessageBox.Show("Adatbázis hiba");
                    this.Close();
                }
                else
                {
                    string message = "regC;" + nev.Text + ";" + datum.Text + ";" + varos.Text + ";" + jogsi.Text + ";" + email.Text + ";" + tel.Text + ";" + jelso.Text;
                    string message_back = Server_connection.GetInstance().SendMessageToServer(message, true);

                    if (message_back == "OK")
                    {
                        MessageBox.Show("Regisztrálás sikerült");
                        this.Close();
                        return;
                    }

                    MessageBox.Show("Adatbázis hiba");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Az adatok nem megfelelőek");
            }
        }

        private bool StringEll()
        {
            bool acceptable = true;

            if (nev.Text.Contains(';')) acceptable = false;
            if (varos.Text.Contains(';')) acceptable = false;
            if (datum.Text.Contains(';')) acceptable = false;
            if (jogsi.Text.Contains(';')) acceptable = false;
            if (email.Text.Contains(';')) acceptable = false;
            if (!email.Text.Contains('@')) acceptable = false;
            if (tel.Text.Contains(';')) acceptable = false;
            if (jelso.Text.Contains(';')) acceptable = false;

            return acceptable;
        }
    }
}
