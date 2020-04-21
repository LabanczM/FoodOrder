using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerV3
{
    class Program
    {
        public sealed class DB
        {
            private string user;

            private static DB instance = null;
            private MySqlConnection connection;

            private DB()
            {
                string connectionString = "server=remotemysql.com;userid=pP2C6kiKVe;password=nCxeCZCMf7;database=pP2C6kiKVe";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }

            public static DB Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new DB();
                    }
                    return instance;
                }
            }

            public string User { get => user; set => user = value; }

            public static bool Has_instance()
            {
                if (instance == null) return false;
                return true;
            }

            public void CloseConn()
            {
                connection.Close();
            }
            public string Login(string tablename, string name, string password)
            {
                MySqlDataReader dataReader = null;
                try
                {
                    string query = "";
                    if (tablename != "Vasarlo")  query = "Select * from " + tablename + " where Nev like '" + name + "' and Jelszo like '" + password + "'";
                    else  query = "Select * from " + tablename + " where Tel like '" + name + "' and Jelszo like '" + password + "'";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    dataReader = cmd.ExecuteReader();

                    dataReader.Read();

                    if (!dataReader.HasRows)
                    {
                        dataReader.Close();
                        return "failed";
                    }

                    string message = "";
                    switch (tablename)
                    {
                        case "Futar": message = "accepted;" + dataReader.GetInt16("Id") + ";" + dataReader.GetString("Nev") + ";" + dataReader.GetString("Cim") + ";" + dataReader.GetDateTime("Szul_Date").ToString() + ";" + dataReader.GetString("Jogsi") + ";" + dataReader.GetString("Email") + ";" + dataReader.GetString("Tel") + ";" + dataReader.GetString("Jelszo"); break;
                        case "Etterem":
                            message = "accepted;" +
                            dataReader.GetInt16("Id") + "; " + dataReader.GetString("Nev") + "; " + dataReader.GetString("Cim") + "; " +
                            dataReader.GetString("Email") + "; " + dataReader.GetString("Tel") + "; " + dataReader.GetString("Jelszo"); break;
                        case "Vasarlo": message = "accepted;"; break; // kitölt
                        default: break;
                    }
                    dataReader.Close();
                    return message;
                }
                catch (Exception)
                {
                    dataReader.Close();
                    return "Error";
                }
            }

            public string RegisterUser_C(string values)
            {
                try
                {
                    string query = "Insert into Futar ( `Nev`, `Szul_Date`, `Cim`, `Jogsi`, `Email`, `Tel`, `Jelszo`, `Elerhetoseg`) Values('" + values.Split(";")[0] + "', '" + values.Split(";")[1] + "', '" + values.Split(";")[2] + "' ," +
                    " '" + values.Split(";")[3] + "' , '" + values.Split(";")[4] + "', '" + values.Split(";")[5] + "', '" + values.Split(";")[6] + "', 0)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
                
            }

            public string RegisterUser_B(string values)
            {
                try
                {
                    string query = "Insert into Vasarlo  (`Nev`, `Email`, `Cim`, `Jelszo`) Values('" + values.Split(";")[0] + "', '" + values.Split(";")[1] + "', '" + values.Split(";")[2] + "' ," +
                    " '" + values.Split(";")[3] + "')";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
            }

            public string RegNumber()
            {
                string message = "";
                string query = "Select Nev, Icon From Etterem Order By Id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        message += dataReader.GetString("Nev") + ";" + dataReader.GetString("Icon") + "?";
                    }
                    dataReader.Close();
                    if (message != "")
                        return message;
                    else return "failed";
                }
                catch (Exception)
                {
                    dataReader.Close();
                    return "failed";
                }
            }
            public string RegisterUser_R(string values)
            {
                try
                {
                    string query = "Insert into Etterem (`Nev`, `Cim`, `Email`, `Tel`, `Jelszo`, `Icon`) Values('" + values.Split(";")[0] + "', '" + values.Split(";")[1] + "', '" + values.Split(";")[2] + "' ," +
                    " '" + values.Split(";")[3] + "' , '" + values.Split(";")[4] + "' , '" + values.Split(";")[5] + "')";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
            }

            public string UpdateUser_C(string values)
            {
                try
                {
                    string query = "Update Futar SET `Nev` =  '" + values.Split(";")[0] + "',  `Szul_Date` = '" + values.Split(";")[1] + "', `Cim` = '" + values.Split(";")[2] + "' , `Jogsi` = '" + values.Split(";")[3] + "'" +
                        " , `Email` = '" + values.Split(";")[4] + "', `Tel` = '" + values.Split(";")[5] + "', `Jelszo` = '" + values.Split(";")[6] + "' where Id = " + values.Split(";")[7];
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
            }

            public string Set_C_Active(string values)
            {
                try
                {
                    string query = "Update Futar SET `Elerhetoseg` =  '" + values.Split(";")[0] + "' where Id = " + values.Split(";")[1];
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
            }

            /* message to client teszt
            public void sendmessage()
            {
                Console.WriteLine("kinek:");
                string kinek = Console.ReadLine();
                string mit = "alert";

                Broadcast_to_saved_client(mit, kinek);
            }
            */

            public string Get_futar()
            {
                string message = "";
                string query = "Select Id, Nev, Cim, Jogsi, Email, Tel From Futar";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                try
                {
                    while (dataReader.Read())
                    {
                        message += dataReader.GetInt16("Id") + ";" + dataReader.GetString("Nev") + ";" + dataReader.GetString("Cim") + ";" +
                            dataReader.GetString("Jogsi") + ";" + dataReader.GetString("Email") + ";" + dataReader.GetString("Tel") + "?";
                    }
                    dataReader.Close();
                    return message;
                }
                catch (Exception)
                {
                    dataReader.Close();
                    return "failed";
                }
            }

            public string Get_orders(string who, string id)
            {
                if (who == "C")
                {
                    MySqlDataReader dataReader = null;
                    try
                    {
                        string message = "";
                        string query = "Select Rendeles.Id, Rendeles.Datum, Vasarlo.Nev, Vasarlo.Cim, Rendeles.Ar from Rendeles join Vasarlo on Vasarlo.Id = Rendeles.Vasarlo_Id where Rendeles.Allapot = 0 and Futar_Id like " + id;
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        dataReader = cmd.ExecuteReader();

                        if (!dataReader.HasRows)
                        {
                            dataReader.Close();
                            return "failed";
                        }

                        while (dataReader.Read())
                        {
                            message += dataReader.GetInt16("Id") + ";" + dataReader.GetDateTime("Datum") + ";" + dataReader.GetString("Nev") + ";" + dataReader.GetString("Cim").ToString() + ";" + dataReader.GetString("Ar")+"?";
                        }
                        message = message.Remove(message.Length - 1);
                        dataReader.Close();
                        return message;
                    }
                    catch (Exception)
                    {
                        dataReader.Close();
                        return "Error";
                    }
                }
                else
                {
                    string message = "";
                    string query = "Select Rendeles.Id, Rendeles.Datum, Vasarlo.Nev, Vasarlo.Cim, Rendeles.Ar, " +
                        "Rendeles.Etelek from Rendeles join Vasarlo on Rendeles.Vasarlo_Id = Vasarlo.Id Where Rendeles.Allapot = 0 And Rendeles.Etterem_Id = " + id;
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    try
                    {
                        while (dataReader.Read())
                        {
                            message += dataReader.GetInt16("Id") + ";" + dataReader.GetDateTime("Datum").ToString() + ";" +
                                dataReader.GetString("Nev") + ";" + dataReader.GetString("Cim") + ";" +
                                dataReader.GetInt32("Ar") + ";" + dataReader.GetString("Etelek") + "?";
                        }

                        dataReader.Close();
                        if (message != "")
                            return message;
                        else return "NoData";
                    }
                    catch (Exception ex)
                    {
                        dataReader.Close();
                        return "failed";
                    }
                }
            }

            public string Order_cancel_from_futar(string id, string order_id, string varos)
            {
                try
                {
                    string query = "select Futar.Id from Futar where Ertekeles <= (select Ertekeles from Futar where Futar.Id = " + id + ") AND Futar.Id != " + id + " AND Elerhetoseg = 1 AND Cim = '"+varos+"' order by Ertekeles limit 1";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();
                    if (!dataReader.HasRows) { return "failed"; }

                    string id2 = dataReader.GetInt32("Id").ToString();

                    dataReader.Close();

                    string query_2 = "Update Rendeles set Futar_Id = " +id2+ " WHERE Id = " + order_id;
                    cmd = new MySqlCommand(query_2, connection);
                    cmd.ExecuteNonQuery();

                    Broadcast_to_saved_client("Uj rendeles erkezett", id2 + ",C");

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
            }

            public string Szallitas_Finished(string id)
            {
                try 
                {
                    string query = "Update Futar set Szall_szam = Szall_szam + 1 Where Id = " + id;
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
            }

            public string Orderstate_update(string order_id)
            {
                try
                {
                    string query = "Update Rendeles set Allapot = 1 Where Id = " + order_id;
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
            }
            public void Fizetes()
            {
                string query = "Update Futar set Penz = Szall_szam * 300";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }

            public string GetIncomeDay(string dates)
            {
                if (dates.Contains("getbevetelNC"))
                {
                    dates = dates.Replace('.', '-').Replace(':', '-');
                    string[] splitdates = dates.Split(";");
                    string message = "";
                    string id = splitdates[splitdates.Length-1];
                    string select = "";
                    for (int i = 1; i < splitdates.Length - 1; i++)
                    {
                        if (i != splitdates.Length - 2)
                            select += "Datum = '" + splitdates[i] + "' OR ";
                        else
                            select += "Datum = '" + splitdates[i] + "'";
                    }
                    try
                    {
                        string query = "Select Datum AS date, Count(Id) AS db From Rendeles Where Futar_Id = " + id + " And " + select + " And Allapot = 1 Group By Datum Order By Datum";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            message += dataReader.GetDateTime("date").ToString() + ";" + (300  * dataReader.GetInt16("db")) + "?";
                        }
                        if (message == "")
                            message = "NoData";
                        dataReader.Close();
                        return message;
                    }
                    catch (Exception)
                    {
                        return "Error";
                    }
                }
                else
                {
                    dates = dates.Replace('.', '-').Replace(':', '-');
                    string[] splitdates = dates.Split(";");
                    string message = "";

                    string select = "";
                    for (int i = 1; i < splitdates.Length; i++)
                    {
                        if (i != splitdates.Length - 1)
                            select += "Datum = '" + splitdates[i] + "' OR ";
                        else
                            select += "Datum = '" + splitdates[i] + "'";
                    }

                    try
                    {
                        string query = "Select Datum AS date, SUM(Ar) AS Ar From Rendeles Where " + select + " Group By Datum Order By Datum";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            message += dataReader.GetDateTime("date").ToString() + ";" + dataReader.GetInt16("Ar") + "?";
                        }
                        if (message == "")
                            message = "NoData";
                        dataReader.Close();
                        return message;
                    }
                    catch (Exception)
                    {
                        return "Error";
                    }
                }
            }
            public string GetIncomeMonth()
            {
                string message = "";
                try
                {
                    string query = "Select Month(Datum) AS Ho, SUM(Ar) AS Ar From Rendeles Group By Month(Datum)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        message += dataReader.GetInt16("Ho") + ";" + dataReader.GetInt16("Ar") + "?";
                    }
                    if (message == "")
                        message = "NoData";
                    dataReader.Close();
                    return message;
                }
                catch (Exception)
                {
                    return "Error";
                }
            }
            public string NewFood(string values)
            {
                try
                {
                    string query = "Insert into Menu (`Nev`, `Ar`, `Elk_ido`, `Link`) Values('" + values.Split(";")[0] + "', '" + values.Split(";")[1] + "', '" + values.Split(";")[2] + "' ," +
                    " '" + values.Split(";")[3] + "')";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception)
                {
                    return "Error";
                }
            }
        }

        public static Hashtable clientsList = new Hashtable();

        //Timer a fizeteshez==========================
        private System.Threading.Timer timer;
        private void SetUpTimer(TimeSpan alertTime)
        {
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = alertTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                return;//time already passed
            }
            this.timer = new System.Threading.Timer(x =>
            {
                this.SomeMethodRunsAt2359();
            }, null, timeToGo, System.Threading.Timeout.InfiniteTimeSpan);
        }
        private void SomeMethodRunsAt2359()
        {
            DB.Instance.Fizetes();
        }
        //===========================================
        static void Main(string[] args)
        {
            Program p = new Program();
            p.SetUpTimer(new TimeSpan(23, 59, 00));
            Server_Run();
        }

        private static void Server_Run()
        {
            //Attila
            IPAddress ipAd = IPAddress.Parse("192.168.1.107");
            //IPAddress ipAd = IPAddress.Parse("192.168.1.7");
            TcpListener serverSocket = new TcpListener(ipAd, 8081); 
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();

            Console.WriteLine("Server Started ....");

            while (true) // folyamatosan várja a klienseket
            {
                clientSocket = serverSocket.AcceptTcpClient();

                int buffersize = 500;
                byte[] bytesFrom = new byte[buffersize];
                string dataFromClient = null;

                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, buffersize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);

                Handle_Request(clientSocket, dataFromClient, networkStream);
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }

        private static void Handle_Request(TcpClient clientSocket, string dataFromClient, NetworkStream networkStream)
        {
            dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

            if (dataFromClient.Contains("Waiting")) // ezt a klienst tárolja el hogy tudjon majd neki üzenetet küldeni
            {
                try
                {
                    clientsList.Add(dataFromClient.Split(';')[1], clientSocket);
                    Console.WriteLine(dataFromClient.Split(';')[1] + " added to waiting list");
                }
                catch (Exception)
                {
                }
            }
            else
            {
                if (dataFromClient.Contains("login"))
                {
                    string messageback = "";
                    switch (dataFromClient.Split(';')[0])
                    {
                        case "loginrestaurante": messageback = DB.Instance.Login("Etterem", dataFromClient.Split(';')[2], dataFromClient.Split(';')[3]); break;
                        case "logincourier": messageback = DB.Instance.Login("Futar", dataFromClient.Split(';')[2], dataFromClient.Split(';')[3]); break;
                        case "loginbuyer": messageback = DB.Instance.Login("Vasarlo", dataFromClient.Split(';')[2], dataFromClient.Split(';')[3]); break;
                        default: break;
                    }

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                if (dataFromClient.Contains("reg"))
                {
                    string messageback = "";
                    string values = dataFromClient.Substring(dataFromClient.Split(';')[0].Length + 1); // ell +1 rész
                    switch (dataFromClient.Split(';')[0])
                    {
                        case "regC": messageback = DB.Instance.RegisterUser_C(values); break;
                        case "regB": messageback = DB.Instance.RegisterUser_B(values); break;
                        case "regR": messageback = DB.Instance.RegisterUser_R(values); break;
                        default: break;
                    }

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                if (dataFromClient.Contains("closethisclient"))
                {
                    // broadcast("close", dataFromClient.Split(';')[1]);
                    if (clientsList.ContainsKey(dataFromClient.Split(';')[1]))
                    {
                        clientsList.Remove(dataFromClient.Split(';')[1]);
                        Console.WriteLine("client removed" + dataFromClient.Split(';')[1]);
                    }
                    else
                    {
                        Console.WriteLine("client not in list");
                    }
                    return;
                }
                if (dataFromClient.Contains("update")) // megír vásárló és étterem rész
                {
                    string messageback = "";
                    string values = dataFromClient.Substring(dataFromClient.Split(';')[0].Length + 1);
                    switch (dataFromClient.Split(';')[0])
                    {
                        case "updateC": messageback = DB.Instance.UpdateUser_C(values); break;
                        //case "updateB": messageback = DB.Instance.RegisterUser_B(values); break;
                       //case "updateR": messageback = DB.Instance.RegisterUser_R(values); break;
                        default: break;
                    }

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                if (dataFromClient.Contains("setactive")) // csak futárnak van 
                {
                    string messageback = "";
                    string values = dataFromClient.Substring(dataFromClient.Split(';')[0].Length + 1);

                    messageback = DB.Instance.Set_C_Active(values);

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                if (dataFromClient.Contains("getorders"))
                {
                    string messageback = "";
                    switch (dataFromClient.Split(';')[0])
                    {
                        case "getordersC": messageback = DB.Instance.Get_orders("C", dataFromClient.Split(';')[1]); break;
                        case "getordersR": messageback = DB.Instance.Get_orders("R", dataFromClient.Split(';')[1]); break;
                        default: break;
                    }

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                if (dataFromClient.Contains("getfutar"))
                {
                    string messageback = DB.Instance.Get_futar();

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                if (dataFromClient.Contains("cancelorderC"))
                {
                    string messageback = DB.Instance.Order_cancel_from_futar(dataFromClient.Split(';')[1], dataFromClient.Split(';')[2], dataFromClient.Split(';')[3]);

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                //Szallitas vegrehajtva
                if (dataFromClient.Contains("szall_fin"))
                {
                    string stateoforder = DB.Instance.Szallitas_Finished(dataFromClient.Split(';')[1]);
                    string messageback = "";
                    if (stateoforder == "OK")
                    {
                        messageback = DB.Instance.Orderstate_update(dataFromClient.Split(';')[2]);
                    }
                    else messageback = stateoforder;

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                //Bevétel
                if (dataFromClient.Contains("getbevetelN"))
                {
                    string messageback = DB.Instance.GetIncomeDay(dataFromClient);

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                if (dataFromClient.Contains("getbevetelH"))
                {
                    string messageback = DB.Instance.GetIncomeMonth();

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
                
                if (dataFromClient.Contains("Buttoncont"))
                {
                    string messageback = DB.Instance.RegNumber();

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }

                if (dataFromClient.Contains("nfood"))
                {
                    string messageback = "";
                    string values = dataFromClient.Substring(dataFromClient.Split(';')[0].Length + 1); // ell +1 rész

                    messageback = DB.Instance.NewFood(values);

                    Byte[] broadcastBytes = null;
                    broadcastBytes = Encoding.ASCII.GetBytes(messageback);
                    networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    networkStream.Flush();
                }
            }
        }

        public static void Broadcast_to_saved_client(string message, string dest_ID) 
        {
            foreach (DictionaryEntry item in clientsList)
            {
                try
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    if (item.Key.ToString() == dest_ID)
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(message);

                        broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                        broadcastStream.Flush();
                    }
                }
                catch (Exception)
                {
                    clientsList.Remove(item.Key);
                    Console.WriteLine("removed from list: "+ item.Key);
                }
            }
        }
    }
}
