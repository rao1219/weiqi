using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoGame
{
    class Server
    {
        int port = 10010;
        RichTextBox infoTextBox;
        TcpListener tcpListener;
        NetworkStream netStream;
        private Encoding encode = Encoding.Default;
        Dictionary<string, Socket> socketDic = new Dictionary<string, Socket>();
        Dictionary<string, string> playerPair = new Dictionary<string, string>();
        Socket listenSocket;
        public ServerForm serverForm;
        public Server(RichTextBox infoTextBox, ServerForm serverForm)
        {
            this.infoTextBox = infoTextBox;
            this.serverForm = serverForm;
        }
        /// <summary>
        /// 监听请求
        /// </summary>
        /// <param name="port"></param>
        public void Listen()
        {
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            listenSocket.Listen(100);
            Console.WriteLine("成功绑定端口：" + port);
            infoTextBox.AppendText("成功绑定端口：" + port + " \n");
            new Thread(keepListen).Start();
            
        }
        public void keepListen()
        {
            while (true)
            {
                Socket acceptSocket = listenSocket.Accept();
                Console.WriteLine("New Client Connected!");
                new Thread(new ListenThread(acceptSocket, 5000, this).run).Start();

                acceptSocket.Send(encode.GetBytes("ok"));
            }
        }
        public void sendMessage(String userName, String data)//发送data字符串到某用户userName
        {
            Console.WriteLine(userName + " : " + data);
            socketDic[userName].Send(encode.GetBytes(data));
        }
        public Dictionary<string, Socket> getSocketDic()
        {
            return socketDic;
        }
        public Dictionary<string,string> getPlayerPairDic()
        {
            return playerPair;
        }
    }
    class ListenThread
    {
        Socket socket;
        int timeout;
        Encoding encode = Encoding.Default;
        Server server;
        string clientName="NONE";
        public ListenThread(Socket socket, int timeout, Server server)
        {
            this.socket = socket;
            this.timeout = timeout;
            this.server = server;
        }
        public void run()
        {
            while (true)
            {
                String str = Receive();
                Console.WriteLine("From server : " + str);
                if(str.Length>0) server.serverForm.getInfoTextBox().Invoke(new EventHandler(delegate { server.serverForm.getInfoTextBox().AppendText("Client["+clientName+"]:"+str+'\n'); }));
                String[] strArr = str.Split(' ');
                string command = strArr[0];
                if (command.CompareTo("TELL_NAME") == 0)//将该socket及其客户名添加到服务器的字典中
                {
                    String userName = strArr[1];
                    server.getSocketDic().Add(userName, this.socket);
                    Console.WriteLine("Client Name : " + userName);
                    clientName = userName;
                }
                else if(command.CompareTo("REQ_BATTLE") == 0)
                {
                    string reqMan = strArr[1];
                    server.sendMessage(reqMan,"DO_U_AGREE "+ clientName);
                }
                else if (command.CompareTo("AGREE") == 0)
                {
                    string[] pair = strArr[1].Split(',');
                    server.getPlayerPairDic().Add(pair[0], pair[1]);
                    server.getPlayerPairDic().Add(pair[1], pair[0]);
                    
                    //请求者白色，被请求者黑色
                    server.sendMessage(pair[0],"SET_COLOR BLACK");
                    server.sendMessage(pair[0], "TURN");
                    server.sendMessage(pair[1], "SET_COLOR WHITE");
                    server.sendMessage(pair[1], "PAUSE");
                }
                else if(command.Equals("PUT"))
                {
                    string enemy = server.getPlayerPairDic()[clientName];
                    server.sendMessage(enemy, str);
                    server.sendMessage(clientName, "PAUSE");
                    server.sendMessage(enemy, "TURN");
                }
                else if(command.Equals("HAS_PUT"))
                {
                    string enemy = server.getPlayerPairDic()[clientName];
                    server.sendMessage(enemy, str);
                }
                else if (command.Equals("LOAD_SGF"))
                {
                    string[] info = strArr[1].Split(',');
                    Boolean clientTurn = info[0].Equals("True") ? true : false;
                    string enemy = server.getPlayerPairDic()[clientName];
                    server.sendMessage(enemy, "LOAD_SGF " + !clientTurn + ","+info[2] + "," + info[3]);
                    server.sendMessage(clientName, "LOAD_SGF " + clientTurn + "," + info[1] + "," + info[3]);
                }
                else if (command.Equals("RANGZI"))
                {
                    string enemy = server.getPlayerPairDic()[clientName];
                    server.sendMessage(enemy, "TURN");
                }
                else if (command.Equals("FINISH"))
                {
                    string enemy = server.getPlayerPairDic()[clientName];
                    server.sendMessage(enemy, "WANT_FINISH");
                }
                else if(command.Equals("AGREE_FINISH"))
                {
                    string enemy = server.getPlayerPairDic()[clientName];
                    server.sendMessage(clientName,"SHOW_FINISH");
                    server.sendMessage(enemy, "SHOW_FINISH");
                    server.sendMessage(clientName, "PAUSE");
                    server.sendMessage(enemy, "PAUSE");
                }
                else if (command.Equals("NOT_AGREE_FINISH"))
                {
                    string enemy = server.getPlayerPairDic()[clientName];
                    server.sendMessage(enemy, "NOT_AGREE_FINISH");
                }
            }
        }
        public string Receive()
        {
            string result = string.Empty;
            socket.ReceiveTimeout = timeout;
            List<byte> data = new List<byte>();
            byte[] buffer = new byte[1024];
            int length = 0;
            try
            {
                while ((length = socket.Receive(buffer)) > 0)
                {
                    for (int j = 0; j < length; j++)
                    {
                        data.Add(buffer[j]);
                    }
                    if (length < buffer.Length)
                    {
                        break;
                    }
                }
            }
            catch { }
            if (data.Count > 0)
            {
                result = encode.GetString(data.ToArray(), 0, data.Count);
            }
            return result;
        }
    }
}
