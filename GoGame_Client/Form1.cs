using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GoGame_Client
{
    public partial class Form1 : Form
    {
        Client client;
        ChessBoard chessBoard = new ChessBoard();
        public Form1(Client client = null)
        {
            InitializeComponent();
            this.client = client;
            this.BackgroundImage = Image.FromFile("../../../image/bg.gif");
            client.chessBoard = this.chessBoard;
            client.chessBoard.client = this.client;
            client.formObj = this;
            Console.WriteLine("运行到了Form1生成的地方");
            this.Text = client.name;
            this.Show();
        }
        private void picBoxChessBoard_Paint(object sender, PaintEventArgs e)
        {
            chessBoard.chessBoard_Paint(sender, e);
        }

        private void picBoxChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            chessBoard.chessBoard_MouseDown(sender, e);
            picBoxChessBoard.Refresh();
        }

        private void picBoxChessBoard_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reqMan = txtBox_enemyName.Text;
            client.sendMessage("REQ_BATTLE "+reqMan); 
            
        }
        public Button getReqBattle()
        {
            return reqBattle;
        }
        public Label getPutNumLabel()
        {
            return putNumLabel;
        }
        public TextBox getTextBoxEnemy()
        {
            return txtBox_enemyName;
        }
        public Label getOppositeLabel()
        {
            return label3;
        }
        public Label getColorLabel()
        {
            return lbColor;
        }
        public PictureBox getPicBoxChessBoard()
        {
            return picBoxChessBoard;
        }

        private void lbColor_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            chessBoard.gameControl.writeSGFToFile();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "棋谱文件(*.sgf)|*.sgf";
            
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string path = fd.FileName;
                Console.WriteLine(path);
                string sgfinfo = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)).ReadToEnd();
                
                path = path.Substring(0, path.LastIndexOf(@"\") + 1) + "elseInfo";

                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);

                string info = "";
                while(sr.Peek()>=0)
                {
                    String line = sr.ReadLine();
                    info += line + ",";
                }
                
                

                this.client.sendMessage("LOAD_SGF " + info + sgfinfo);
            }
        }

       
        private void btnFinsh_Click(object sender, EventArgs e)
        {
            this.client.sendMessage("FINISH");
        }

        private void btnRanzi_Click(object sender, EventArgs e)
        {
            this.client.sendMessage("RANGZI");
        }
    }
}
