using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoGame
{
    class ChessPiece
    {
        public int row, col, player;
        public ChessPiece(int row, int col, int player)
        {
            this.row = row;
            this.col = col;
            this.player = player;
        }
    }
    class ChessBoard
    {
        //画笔
        public SolidBrush[] solidBrush = new SolidBrush[] { new SolidBrush(Color.White), new SolidBrush(Color.Black), new SolidBrush(Color.Red) };
        public Pen pen = new Pen(Color.Black);
        //一些数据
        public int[,] chessBoardState = new int[19, 19];//0 为空位、2 为黑子、1 为白子 来表示
        public GameControl gameControl = new GameControl();
        public int COLOR = 1;//本方的颜色，0是白色，1是黑色
        List<ChessPiece> chessPieceList = new List<ChessPiece>();
        Color[] CHESS_COLOR = new Color[] { Color.Black, Color.White };
        public ChessBoard(int COLOR=0)
        {
            this.COLOR = COLOR;
        }

        /// <summary>
        /// 负责棋盘绘画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void chessBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int i = 130; i < 530; i += 198)
                for (int j = 130; j < 530; j += 198)
                    graphics.FillRectangle(solidBrush[1], i, j, 5, 5);
            for (int i = 33; i < 628; i += 33)
            {
                graphics.DrawLine(pen, 33, i, 627, i);
                graphics.DrawLine(pen, i, 33, i, 627);
            }
            Console.WriteLine("PAINT");

            int paintX = 1 * 33 + 16;
            int paintY = 2 * 33 + 16;
            System.Console.WriteLine("Paint Chess: " + paintX + "," + paintY);
            LinearGradientBrush brush = new LinearGradientBrush(new Point(paintX, paintY), new Point(paintX + 33, paintY + 33), Color.Black, Color.Gray);

            graphics.FillEllipse(brush, paintX, paintY, 33, 33);//绘制棋子 

            for (int i = 0; i < chessPieceList.Count; i++)
            {
                Console.WriteLine(i+"th"+chessPieceList[i].col+","+chessPieceList[i].row);
            }

            this.paintChessPieceUsingList(graphics);


        }

        /// <summary>
        /// 当鼠标点下时画出棋子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void chessBoard_MouseDown(object sender, MouseEventArgs e)
        {
            int row = (e.X - 17) / 33;
            int col = (e.Y - 17) / 33;
            
            if (col < 19 && row < 19 && chessBoardState[col, row] == 0)//&& (劫位.X != 行 || 劫位.Y != 列) )
            {
                //gameControl.oneStep(row, col);
                chessPieceList.Add(new ChessPiece(row, col));
                chessBoardState[col, row] = COLOR;//画图
                //chessPieceList = gameControl.getChessPieceList();

                Console.WriteLine("row:" + row + "  col:" + col);
                Console.WriteLine("LIST SIZE:" + chessPieceList.Count);
            }
            else
            {
                //## 打印错误放置提醒
            }
        }
        public void paintChessPieceUsingList(Graphics graphics)
        {
            if (chessPieceList == null)
            {
                Console.WriteLine("List is NULL!!");
                return;
            }
            for (int i = 0; i < chessPieceList.Count; i++)
            {
                int paintX = chessPieceList[i].row * 33 + 16;
                int paintY = chessPieceList[i].col * 33 + 16;
                System.Console.WriteLine("Paint Chess: "+paintX + "," + paintY);
                LinearGradientBrush brush = new LinearGradientBrush(new Point(paintX, paintY), new Point(paintX + 33, paintY + 33), Color.Black, Color.Gray);
                
                graphics.FillEllipse(brush, paintX, paintY, 33, 33);//绘制棋子 
            }
        }
    }
}
