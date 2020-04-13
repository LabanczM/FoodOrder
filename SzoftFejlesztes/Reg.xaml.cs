using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Interaction logic for Reg.xaml
    /// </summary>
    /// 
    public partial class Reg : Window
    {
        static string filename = "";

        public Reg()
        {
            InitializeComponent();
        }


        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            string message = "regR;" + Enev.Text + ";" + Ecim.Text + ";" + Email.Text + ";" + Etel.Text + ";" + Ejel.Text + ";" + "https://szoftbead.000webhostapp.com/etteremicon/"+filename;
            string message_back = Server_connection.GetInstance().SendMessageToServer(message, true);

            if (message_back == "OK")
            {
                MessageBox.Show("Regisztrálás sikerült");
                MainWindow mw = new MainWindow();
                mw.NewButton();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Adatbázis hiba");
                this.Close();
            }
        }

        private void Img_Click(object sender, RoutedEventArgs e)
        {
            string filepath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName.Split('\\').Last().ToString();
                filepath = openFileDialog.FileName.ToString();
            }
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com/public_html/etteremicon/" + filename);
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

                //if you want to delete, uncomment the line below, and remove the line above
                //requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile; 

                ftpRequest.Credentials = new NetworkCredential("szoftbead", "M%WNI7ioZ&*xyqpyvW)Q");

                byte[] fileData;
                using (StreamReader readStream = new StreamReader(filepath))
                {
                    fileData = File.ReadAllBytes(filepath);
                }
                ftpRequest.ContentLength = fileData.Length;

                using (Stream sendStream = ftpRequest.GetRequestStream())
                {
                    sendStream.Write(fileData, 0, fileData.Length);
                }
                ftpRequest.GetResponse();
            }
            catch
            {
                MessageBox.Show("Valami hiba történt!");
            }
            
        }
    }
}
