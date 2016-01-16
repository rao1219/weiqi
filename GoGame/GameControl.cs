using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//0 为空位、2 为黑子、1 为白子 来表示
//棋盘大小为19*19
namespace GoGame
{
    class GameControl
    {
        const int ROW = 19, COL = 19, CNUM = 19 * 19, EMPTY = 0, BLACK = 2, WHITE = 1;
        int[] peer;
        int[] pa;
        int[] qi;
        int[,] board;
        int[,] dir = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        GameControl()
        {
            peer = new int[3];
            pa = new int[CNUM + 10];
            qi = new int[CNUM + 10];
            board = new int[20, 20];
            peer[BLACK] = WHITE;
            peer[WHITE] = BLACK;
            for (int i = 0; i < CNUM; i++)
            {
                pa[i] = i;
                qi[i] = calqi(i, 0);
            }
        }
        static void testmain(string[] args)
        {
            GameControl test = new GameControl();
            test.oneStep(0, 0, 1);
            test.oneStep(0, 1, 2);
            test.oneStep(3, 2, 1);
            test.oneStep(1, 0, 2);
            test.oneStep(4, 3, 1);
            test.oneStep(0, 0, 2);
            test.oneStep(13, 4, 1);
            test.oneStep(3, 3, 2);
            test.oneStep(1, 3, 1);
            test.oneStep(10, 10, 2);
            test.oneStep(2, 2, 1);
            test.oneStep(10, 1, 2);
            test.oneStep(2, 4, 1);
            test.oneStep(0, 2, 2);
            test.oneStep(3, 4, 1);
            test.oneStep(2, 3, 2);
            test.oneStep(1, 1, 2);
            test.oneStep(1, 2, 2);
            test.oneStep(0, 3, 1);
            test.oneStep(2, 1, 1);
            test.oneStep(2, 0, 2);
            test.oneStep(3, 0, 1);
        }


        public void oneStep(int row, int col, int player)
        {
            if (board[row, col] != EMPTY)
            {
                Console.WriteLine("下错啦！！SB");
                return;
            }
            Console.WriteLine("in List:" + row + ' ' + col + ' ' + player);
            board[row, col] = player;
            int per = peer[player];
            for (int i = 0; i < 4; i++)
            {
                int cx = row + dir[i, 0], cy = col + dir[i, 1];
                if (!check(cx, cy)) continue;
                if (board[cx, cy] == player) unite(getidx(row, col), getidx(cx, cy));
                if (board[cx, cy] != EMPTY)
                {
                    qi[find(getidx(cx, cy))]--;
                    qi[find(getidx(row, col))]--;
                }
            }

            resetBoard();

            //test code start
            pushBoard();
            Console.WriteLine("");
            string a;
            a = Console.ReadLine();
        }

        public void pushBoard()
        {
            for (int i = 0; i < ROW; i++)
                for (int j = 0; j < COL; j++)
                {
                    Console.Write(board[i, j] == 0 ? '.' : (board[i, j] == 1 ? '*' : '&'));
                    if (j == COL - 1)
                        Console.Write("\n");
                }
        }
        /// <summary>
        /// 清空已经没气的所有分量。
        /// </summary>
        public void resetBoard()
        {
            for (int i = 0; i < ROW; i++)
                for (int j = 0; j < COL; j++)
                {
                    if (board[i, j] == EMPTY) continue;
                    if (qi[find(getidx(i, j))] == 0)
                        emptyComponent(i, j);
                }
        }

        /// <summary>
        /// 清空某个分量，并且增加相邻的对手分量的气
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void emptyComponent(int row, int col)
        {
            int taridx = find(getidx(row, col));
            for (int i = 0; i < ROW; i++)
                for (int j = 0; j < COL; j++)
                {
                    if (board[i, j] == 0) continue;
                    if (find(getidx(i, j)) == taridx)
                    {
                        board[i, j] = 0;
                        for (int k = 0; k < 4; k++)
                        {
                            int cx = i + dir[k, 0], cy = j + dir[k, 1];
                            if (!check(cx, cy) || board[cx, cy] == EMPTY) continue;
                            qi[find(getidx(cx, cy))]++;
                        }
                        qi[getidx(i, j)] = calqi(getidx(i, j), 0);
                    }
                }
        }

        /// <summary>
        /// 计算一个点旁边有多少个特定颜色的棋子或者格子数
        /// 0 ---- 格子数量
        /// 非0 ---- 计算有多少个color颜色的棋子
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int calqi(int idx, int color)
        {
            int x = 0, y = 0;
            getpos(idx, ref x, ref y);
            int res = 0;
            for (int i = 0; i < 4; i++)
            {
                int cx = x + dir[i, 0], cy = y + dir[i, 1];
                if (!check(cx, cy)) continue;
                if (color != 0 && board[cx, cy] != color) continue;
                res++;
            }
            return res;
        }

        public bool check(int x, int y)
        {
            if (x >= 0 && x < ROW && y >= 0 && y < COL) return true;
            else return false;
        }

        public void getpos(int idx, ref int x, ref int y)
        {
            x = idx / COL;
            y = idx % COL;
        }

        public int getidx(int x, int y)
        {
            return x * COL + y;
        }

        public int find(int x)
        {
            return pa[x] == x ? x : pa[x] = find(pa[x]);
        }

        public void unite(int u, int v)
        {
            u = find(u);
            v = find(v);
            if (u == v) return;
            pa[u] = v;
            qi[v] += qi[u];
        }

        public List<ChessPiece> getChessPieceList()
        {
            List<ChessPiece> CPlist = new List<ChessPiece>();
            for (int i = 0; i < ROW; i++)
                for (int j = 0; j < COL; j++)
                {
                    if (board[i, j] == EMPTY) continue;
                    CPlist.Add(new ChessPiece(i, j, board[i, j]));
                }
            return CPlist;
        }

    }
}
