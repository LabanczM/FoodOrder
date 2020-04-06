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
    /// Interaction logic for PickDate.xaml
    /// </summary>
    public partial class PickDate : Window
    {
        public PickDate()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            MessageBox.Show("Please select the dates you want to see on the diagram");
        }
        public static string datumok = "";
        private void Picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            datumok += ";"+Picker.SelectedDate.ToString().Replace(" ","");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Napibe na = new Napibe();
            na.GetDatas(datumok);

            this.Close();
        }
    }
}
