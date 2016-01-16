using System;

public class ChessBoard
{
	public ChessBoard()
	{}
    static public void chessBoard_Paint(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        for (int i = 130; i < 530; i += 198)
            for (int j = 130; j < 530; j += 198)
                graphics.FillRectangle(solidBrush[1], i, j, 5, 5);
        for (int i = 33; i < 628; i += 33)
        {
            graphics.DrawLine(pen, 33, i, 627, i);
            graphics.DrawLine(pen, i, 33, i, 627);
        }//绘制棋盘
    }
}
