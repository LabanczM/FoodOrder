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
using LiveCharts;
using LiveCharts.Wpf;

namespace SzoftFejlesztes
{
    /// <summary>
    /// Interaction logic for Havibe.xaml
    /// </summary>
    public partial class Havibe : Window
    {
        public Havibe()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        public void GetDatas()
        {
            string message_to_send = "getbevetelH";
            string response = Server_connection.GetInstance().SendMessageToServer(message_to_send, true);

            int[] havibe = new int[12];
            for (int i = 0; i < havibe.Length; i++)
            {
                havibe[i] = 0;
            }
            if (response != "Error")
            {
                response = response.Remove(response.Length - 1);
                foreach (var item in response.Split('?'))
                {
                    havibe[Convert.ToInt32(item.Split(';')[0]) - 1] = Convert.ToInt32(item.Split(';')[1]);
                }

                SeriesCollection = new SeriesCollection
                {  
                    new ColumnSeries
                    {
                        Title = "Series 1",
                        Values = new ChartValues<int>(havibe)
                    }
                };
                this.Show();
            }
            else
            {
                MessageBox.Show("Something went wrond! Please try again!");
            }
            

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Okt", "Nov", "Dec" };
            Formatter = value => value.ToString("");

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

    }
}
