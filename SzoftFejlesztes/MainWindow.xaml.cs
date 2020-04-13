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

namespace SzoftFejlesztes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> etterem = new Dictionary<string, string>();
        static bool lekerdezve = false;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            if (!lekerdezve)
            {
                lekerdezve = true;
                NewButton();
            }  
        }
        public void NewButton()
        {
            
            etterem.Clear();
            string message = "Buttoncont";
            string message_back = Server_connection.GetInstance().SendMessageToServer(message, true);
            
            if (message_back != "failed")
            {
                message_back = message_back.Remove(message_back.Length - 1);
                foreach (var item in message_back.Split('?'))
                {
                    etterem.Add(item.Split(';')[0], item.Split(';')[1]);
                }
            }
            Thickness margin = new Thickness();
            margin.Left = 5;
            margin.Bottom = 5;
            margin.Right = 5;
            margin.Top = 5;
            
            for (int i = 0; i < etterem.Count; i++)
            {
                Button button = new Button()
                {
                    Name = string.Format(etterem.ElementAt(i).Key),
                    Margin = margin,
                    Content = new Image
                    {

                        Source = new BitmapImage(new Uri(etterem.ElementAt(i).Value)),
                        Stretch = Stretch.Fill,
                        VerticalAlignment = VerticalAlignment.Center,
                    }
                };

                if (i < 7)
                {
                    Grid.SetRow(button, 3);
                    Grid.SetColumn(button, i+1);
                }
                else
                {
                    Grid.SetRow(button, 4);
                    Grid.SetColumn(button, i - 5);
                }

                button.Click += new RoutedEventHandler(Login_Click);
                this.grid.Children.Add(button);
            }

        }
        public void PasswordCheck(string etterem_neve)
        {
            MyDialog md = new MyDialog();
            md.EtteremBe(etterem_neve);
            md.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            Button b = sender as Button;
            string ettrem_neve = b.Name.ToString();
            PasswordCheck(ettrem_neve);
        }
        public static void MessageFromServer(string message)
        {
            MessageBox.Show(message);
        }

        private void Regiszt_Click(object sender, RoutedEventArgs e)
        {
            Reg r = new Reg();
            r.Show();
            this.Close();
        }
    }
}
