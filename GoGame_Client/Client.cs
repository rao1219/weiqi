using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoGame_Client
{
    public class Client
    {
        private Encoding encode = Encoding.Default;
        private Socket clientSocket;
        private string host = "127.0.0.1";
        private int port = 10010;
        public string name;
        public ChessBoard chessBoard;
        public Form1 formObj;
        public int oppositePutNum=0;
        public Client( )
        {
            
        }
        public void connect(string userName)
        {
            this.name = userName;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(host, port);
                sendMessage("TELL_NAME "+ userName);
                new Thread(new ListenThread(clientSocket, 5000, this).run).Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void sendMessage(string message)
        {
            clientSocket.Send(encode.GetBytes(message));
        }
    }
    class ListenThread
    {
        Socket socket;
        int timeout;
        Encoding encode = Encoding.Default;
        Client client;

        public ListenThread(Socket socket, int timeout, Client client)
        {
            this.socket = socket;
            this.timeout = timeout;
            this.client = client;
        }
        public void run()
        {
            while (true)
            {
                string str = Receive();
                Console.WriteLine("From server : " + str);
                String[] strArr = str.Split(' ');
                string command = strArr[0];
                if (command.CompareTo("DO_U_AGREE") == 0)//将该socket及其客户名添加到服务器的字典中
                {
                    string enemyName = strArr[1];
                    DialogResult dr = MessageBox.Show("愿意与"+enemyName+"交战吗？");
                    if(dr.CompareTo(DialogResult.OK) == 0)
                    {
                        client.sendMessage("AGREE "+ client.name + "," +enemyName );
                    }
                }
                else if(command.CompareTo("SET_COLOR") == 0)
                {
                    int color = strArr[1].Equals("BLACK") ? 2 : 1;
                    client.chessBoard.SELF_COLOR = color;
                    //更新己方颜色对方颜色
                    Label colorLabel = client.formObj.getColorLabel();
                    colorLabel.Invoke(new EventHandler(delegate { colorLabel.Text += strArr[1].Equals("BLACK")?"黑":"白"; }));
                    Label oppo = client.formObj.getOppositeLabel();
                    oppo.Invoke(new EventHandler(delegate { oppo.Text += strArr[1].Equals("BLACK") ? "白" : "黑"; }));

                    //隐藏请求对战的窗口
                    TextBox tb = client.formObj.getTextBoxEnemy();
                    tb.Invoke(new EventHandler(delegate { tb.Hide(); }));
                    Button bt = client.formObj.getReqBattle();
                    bt.Invoke(new EventHandler(delegate { bt.Hide(); }));


                }
                else if(command.Equals("TURN"))
                {
                    client.chessBoard.SELF_TURN = true;
                    Console.WriteLine("SELF_TURN:"+ client.chessBoard.SELF_TURN);
                }
                else if(command.Equals("PAUSE"))
                {
                    client.chessBoard.SELF_TURN = false;
                }
                else if(command.Equals("PUT"))
                {
                    string[] rc = strArr[1].Split(',');
                    int row = int.Parse(rc[0]);
                    int col = int.Parse(rc[1]);
                    client.chessBoard.gameControl.oneStep(row, col, 3 - client.chessBoard.SELF_COLOR);
                    client.chessBoard.chessPieceList = client.chessBoard.gameControl.getChessPieceList();
                    client.formObj.getPicBoxChessBoard().Invoke(new EventHandler(delegate { client.formObj.getPicBoxChessBoard().Refresh(); }));
                    client.oppositePutNum = int.Parse(rc[2]);
                }
                else if(command.Equals("HAS_PUT"))
                {
                    //更新对方已下棋子
                    client.oppositePutNum = int.Parse(strArr[1]);
                }
                else if(command.Equals("SET_PUTNUM"))
                {
                    int putNum = int.Parse(strArr[1]);
                    client.chessBoard.putNum = putNum;
                    Label putNumLabel = client.formObj.getPutNumLabel();
                    putNumLabel.Invoke(new EventHandler(delegate { putNumLabel.Text = "已下子数：" + putNum; }));
                }
                else if(command.Equals("LOAD_SGF"))
                {
                    
                    string[] info = strArr[1].Split(',');
                    client.chessBoard.gameControl.loadFromSGF(info[2]);
                    if (info[0].Equals("True"))
                    {
                        client.chessBoard.SELF_TURN = true;
                    }
                    else
                    {
                        client.chessBoard.SELF_TURN = false;
                    }

                    client.chessBoard.putNum = int.Parse(info[1]);
                    Label putNumLabel = client.formObj.getPutNumLabel();
                    putNumLabel.Invoke(new EventHandler(delegate { putNumLabel.Text = "已下子数：" + client.chessBoard.putNum; }));

                    client.chessBoard.refreshChessPieceList();
                    client.formObj.getPicBoxChessBoard().Invoke(new EventHandler(delegate { client.formObj.getPicBoxChessBoard().Refresh(); }));
                }
                else if (command.Equals("WANT_FINISH"))
                {
                    if(MessageBox.Show("对方想终局，你同意么？").CompareTo(DialogResult.OK) == 0)
                    {
                        client.sendMessage("AGREE_FINISH");
                    }
                    else
                    {
                        client.sendMessage("NOT_AGREE_FINISH");
                    }
                }
                else if (command.Equals("NOT_AGREE_FINISH"))
                {
                    MessageBox.Show("对方不同意终局");
                }
                else if (command.Equals("SHOW_FINISH"))
                {
                    MessageBox.Show(client.chessBoard.gameControl.judgeWinner());
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
