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
    /// Interaction logic for FoMenu.xaml
    /// </summary>
    public partial class FoMenu : Window
    {
        public FoMenu()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Fut_Click(object sender, RoutedEventArgs e)
        {
            Futarok ft = new Futarok();
            ft.KiListaz();
            ft.Show();
            this.Close();
        }

        private void Rend_Click(object sender, RoutedEventArgs e)
        {
            Rendekesek r = new Rendekesek();
            r.KiListaz();
            r.Show();
            this.Close();
        }

        private void Stat_Click(object sender, RoutedEventArgs e)
        {
            Bevetel be = new Bevetel();
            this.Close();
            be.Show();
        }

        
    }
}
