using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetPincerV2
{
    public sealed class Server_connection
    {
        private static string ip = "192.168.1.65";
        private static int port = 8081;

        private static Server_connection instance = null;
        private TcpClient client;

        public Server_connection()
        {
            // Thread t = new Thread(WaitForCustomers_thread_function);
            // t.Start();
        }

        public static Server_connection GetInstance()
        {
            if (instance == null)
            {
                instance = new Server_connection();
            }
            return instance;
        }

        // message: id;userid;message
        // id list: loginrestaurante,logincourier,loginbuyer,getfooglist,getcourierlist,getmenus,getrestaurants,regC,regB,regR,closethisclient
        public string SendMessageToServer(String message, bool has_return = false)
        {
            try
            {
                message += "$";
                // connect to server
                client = new TcpClient();
                client.Connect(ip, port); // where to connect

                // send ip and id to server for identification
                Stream stm = client.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(message);
                stm.Write(ba, 0, ba.Length);

                if (has_return)
                {
                    byte[] bb = new byte[500];
                    int k = stm.Read(bb, 0, 500);
                    string response = "";
                    for (int i = 0; i < k; i++)
                    {
                        response += Convert.ToChar(bb[i]);
                    }

                    client.Close();

                    if (message.Contains("login") && response.Contains("accepted"))
                    {
                        UserData.GetInstance().Database_ID = int.Parse(response.Split(';')[1]);
                        UserData.GetInstance().Name = response.Split(';')[2];
                        UserData.GetInstance().City = response.Split(';')[3];
                        UserData.GetInstance().Date = response.Split(';')[4].Substring(0, 13).Replace(" ", "");
                        UserData.GetInstance().Driver_L = response.Split(';')[5];
                        UserData.GetInstance().Email = response.Split(';')[6];
                        UserData.GetInstance().Tel = response.Split(';')[7];
                        UserData.GetInstance().Password = response.Split(';')[8];

                        Thread waiting = new Thread(() => WaitForCustomers_thread_function(UserData.GetInstance().Database_ID.ToString()+",C"));
                        waiting.Start();

                        return "accepted";
                    }

                    return response;
                }

                client.Close();
                return "";
            }

            catch (Exception e)
            {
                return "";
            }
        }

        public void WaitForCustomers_thread_function(string username)
        {
            try
            {
                string message = "Waiting;" + username + "$";
                // connect to server
                client = new TcpClient();
                client.Connect(ip, port); // where to connect


                Stream stm = client.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(message);
                stm.Write(ba, 0, ba.Length);

                while (true)
                {
                    byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);
                    string response = "";
                    for (int i = 0; i < k; i++)
                    {
                        response += Convert.ToChar(bb[i]);
                    }

                    if (response == "alert")
                    {
                        MainWindow.MessageFromServer("Alert from server");

                        Console.Beep();
                        Thread.Sleep(500);
                        Console.Beep();
                    }
                }

                client.Close();
            }
            catch (Exception e)
            {
                client.Close();
            }

        }
    }
}

