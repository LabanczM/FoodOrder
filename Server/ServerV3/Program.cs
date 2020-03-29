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
                    string query = "Select * from " + tablename + " where Nev like '" + name + "' and Jelszo like '" + password + "'";
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

            public string RegisterUser_R(string values)
            {
                try
                {
                    string query = "Insert into Etterem (`Nev`, `Email`, `Cim`, `Tel`, `Jelszo`) Values('" + values.Split(";")[0] + "', '" + values.Split(";")[1] + "', '" + values.Split(";")[2] + "' ," +
                    " '" + values.Split(";")[3] + "' , '" + values.Split(";")[4] + "')";
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
                        string query = "Select Rendeles.Id, Rendeles.Datum, Vasarlo.Nev, Vasarlo.Cim, Rendeles.Ar from Rendeles join Vasarlo on Vasarlo.Id = Rendeles.Vasarlo_Id where Futar_Id like " + id;
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
                        "Rendeles.Etelek from Rendeles join Vasarlo on Rendeles.Vasarlo_Id = Vasarlo.Id";
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
                        return message;
                    }
                    catch (Exception ex)
                    {
                        dataReader.Close();
                        return "failed";
                    }
                }
            }

            public string Order_cancel_from_futar(string id, string order_id)
            {
                try
                {
                    string query = "Update Rendeles set Futar_Id = (select Futar.Id from Futar where Ertekeles <= (select Ertekeles from Futar where Futar.Id = " + id+ ") AND Futar.Id != 1   order by Ertekeles limit 1 ) WHERE Id = " + order_id;
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

        static void Main(string[] args)
        {
            Server_Run();
        }

        private static void Server_Run()
        {
            IPAddress ipAd = IPAddress.Parse("192.168.1.65");
            TcpListener serverSocket = new TcpListener(ipAd, 8081); 
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();

            Console.WriteLine("Server Started ....");

            while (true) // folyamatosan várja a klienseket
            {
                clientSocket = serverSocket.AcceptTcpClient();

                int buffersize = clientSocket.ReceiveBufferSize;
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
                    string values = dataFromClient.Substring(dataFromClient.Split(';')[0].Length+1); // ell +1 rész
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
                       // case "updateR": messageback = DB.Instance.RegisterUser_R(values); break;
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
                    string messageback = DB.Instance.Order_cancel_from_futar(dataFromClient.Split(';')[1], dataFromClient.Split(';')[2]);

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
