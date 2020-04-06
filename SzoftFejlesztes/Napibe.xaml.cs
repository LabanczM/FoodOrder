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
    /// Interaction logic for Napibe.xaml
    /// </summary>
    ///
    public partial class Napibe : Window
    {
        public Napibe()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public void GetDatas(string dates)
        {
            
            string message_to_send = "getbevetelN" + dates;
            string response = Server_connection.GetInstance().SendMessageToServer(message_to_send, true);

            List<int> napibe = new List<int>();

            if (response == "NoData")
                MessageBox.Show("There were no transactions on these days");
            else if(response != "Error")
            {
                response = response.Remove(response.Length - 1);
                string datesgive = "";
                foreach (var item in response.Split('?'))
                {
                    napibe.Add(Convert.ToInt32(item.Split(';')[1]));
                    datesgive += item.Split(';')[0] + ";";
                }

                datesgive = datesgive.Substring(0, (datesgive.Length - 1));
                SeriesAddN(napibe, datesgive);

                this.Show();
            }
            else
            {
                MessageBox.Show("Something went wrond! Please try again!");
                PickDate pd = new PickDate();
                pd.Show();
            }
           
        }
        public void SeriesAddN(List<int> ndatas, string label)
        {

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<int>(ndatas)
                }
            };

            Labels = label.Split(';');
            YFormatter = value => value.ToString("");
            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
    
}
