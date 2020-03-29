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
        public MainWindow()
        {
            InitializeComponent();
        }
        public void PasswordCheck(string etterem_neve)
        {
            MyDialog md = new MyDialog();
            md.EtteremBe(etterem_neve);
            md.Show();
            this.Close();
        }

        private void McDonalds_Click(object sender, RoutedEventArgs e)
        {
            string ettrem_neve = McDonalds.Name.ToString();
            PasswordCheck(ettrem_neve);
        }

        private void KFC_Click(object sender, RoutedEventArgs e)
        {
            string ettrem_neve = KFC.Name.ToString();
            PasswordCheck(ettrem_neve);
        }

        private void BurgerKing_Click(object sender, RoutedEventArgs e)
        {
            string ettrem_neve = BurgerKing.Name.ToString();
            PasswordCheck(ettrem_neve);
        }

        private void PizzaHut_Click(object sender, RoutedEventArgs e)
        {
            string ettrem_neve = PizzaHut.Name.ToString();
            PasswordCheck(ettrem_neve);
        }
        public static void MessageFromServer(string message)
        {
            MessageBox.Show(message);
        }
    }
}
