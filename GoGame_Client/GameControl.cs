using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//0 为空位、2 为黑子、1 为白子 来表示
//棋盘大小为19*19
namespace GoGame_Client
{
    public class GameControl
    {
        const int ROW = 19, COL = 19, CNUM = 19 * 19, EMPTY = 0, BLACK = 2, WHITE = 1;
        int step;
        string SGFINFO;
        char[] SGFchar;
        int[] SGFInvChar;
        int[] peer;
        int[] pa;
        int[] qi;
        int[,] board;
        int[,] dir = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        bool[,] vis;
        ChessBoard chessBoard;
        public GameControl(ChessBoard chessBoard)
        {
            step = 0;
            SGFINFO = ";CA[gb2312]SZ[19]AP[MultiGo:4.4.4]MULTIGOGM[1]\n";
            SGFchar = new char[44];
            SGFchar[BLACK] = 'B';
            SGFchar[WHITE] = 'W';
            SGFInvChar = new int[322];
            SGFInvChar['B'] = BLACK;
            SGFInvChar['W'] = WHITE;
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
            this.chessBoard = chessBoard;
        }
        public GameControl()
        {
            step = 0;
            SGFINFO = ";CA[gb2312]SZ[19]AP[MultiGo:4.4.4]MULTIGOGM[1]\n";
            SGFchar = new char[44];
            SGFchar[BLACK] = 'B';
            SGFchar[WHITE] = 'W';
            SGFInvChar = new int[322];
            SGFInvChar['B'] = BLACK;
            SGFInvChar['W'] = WHITE;
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

        static void test_Main(string[] args)
        {
            GameControl test = new GameControl();
            test.loadFromSGF("2016_1_4_22_19_17.sgf");

            //test.oneStep(0, 0, 1);
            //test.oneStep(0, 1, 2);
            //test.oneStep(3, 2, 1);
            //test.oneStep(1, 0, 2);
            //test.oneStep(4, 3, 1);
            //test.oneStep(0, 0, 2);
            //test.oneStep(13, 4, 1);
            //test.oneStep(3, 3, 2);
            //test.oneStep(1, 3, 1);
            //test.oneStep(10, 10, 2);
            //test.oneStep(2, 2, 1);
            //test.oneStep(10, 1, 2);
            //test.oneStep(2, 4, 1);
            //test.oneStep(0, 2, 2);
            //test.oneStep(3, 4, 1);
            //test.oneStep(2, 3, 2);
            //test.oneStep(1, 1, 2);
            //test.oneStep(1, 2, 2);
            //test.oneStep(0, 3, 1);
            //test.oneStep(2, 1, 1);
            //test.oneStep(2, 0, 2);
            //test.oneStep(3, 0, 1);
            //int Winner = test.judgeWinner();
            //Console.WriteLine("这场决斗的赢家是：" + test.SGFchar[Winner]);
            //test.writeSGFToFile();
            Console.ReadLine();
            test.writeSGFToFile();
        }


        public void oneStep(int row, int col, int player)
        {
            if (board[row, col] != EMPTY)
            {
                Console.WriteLine("下错啦！！SB");
                return;
            }
            SGFINFO += ";" + SGFchar[player] + "[" + (char)('a' + col) + (char)('a' + row) + ']';
            step++;
            if (step % 14 == 0) SGFINFO += '\n';
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

            resetBoard(player);
            resetBoard(peer[player]);

            //test code start
            pushBoard();
            Console.WriteLine("");
            Console.ReadLine();
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
        /// 在终局计算谁是赢家
        /// </summary>
        /// <returns></returns>
        public string judgeWinner()
        {
            resetBoard(BLACK);
            resetBoard(WHITE);
            int[] res = new int[10];
            res[BLACK] = res[WHITE] = 0;
            for (int i = 0; i < ROW; i++)
                for (int j = 0; j < COL; j++)
                {
                    vis = new bool[ROW, COL];
                    res[judgeOwnner(i, j) >> 1]++;
                }
            string winner = "";
            if (res[BLACK] > res[WHITE]) winner = "黑方";
            else if (res[BLACK] < res[WHITE]) winner = "白方";
            else winner = "平局";
            return winner + " 黑方 " + res[BLACK] + "目 WHITE " + res[WHITE]+"目";
            //if (res[BLACK] > res[WHITE]) return BLACK;
            //else return WHITE;
        }

        /// <summary>
        /// 在终局判断某个节点属于哪一方
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int judgeOwnner(int x, int y)
        {
            vis[x, y] = true;
            if (board[x, y] != 0) return 1 << board[x, y];
            int Ownner = 0;
            for (int i = 0; i < 4; i++)
            {
                int cx = x + dir[i, 0], cy = y + dir[i, 1];
                if (!check(cx, cy)) continue;
                if (vis[cx, cy]) continue;
                int tmp = judgeOwnner(cx, cy);
                if (tmp == 6) return tmp;
                Ownner |= tmp;
            }
            return Ownner;
        }

        public void writeSGFToFile()
        {
            DateTime now = DateTime.Now;
            
            string path = now.ToString();
            path = path.Replace('/', '_');
            path = path.Replace(':', '_');
            path = path.Replace(' ', '_');
            string timeString = path;
            path += ".sgf";
            Console.WriteLine(path);
            //string path = "testsgf.sgf";

            if (Directory.Exists(@"C:\csharp_gogame\GoGame\棋谱\" + timeString + @"\")) { }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\csharp_gogame\GoGame\棋谱\" + timeString + @"\");
                directoryInfo.Create();
            }

            string p1 = @"C:\csharp_gogame\GoGame\棋谱\" + timeString + @"\" + path;
            Console.WriteLine("保存路径："+p1);
            writeStrToFile('(' + SGFINFO + ')', p1);

            //第一行，己方状态，是在下还是暂停
            //第二行己方已下棋子数目
            //第三行对方已下棋子数目
            string elseInfo=this.chessBoard.SELF_TURN + "\n";
            elseInfo += this.chessBoard.putNum + "\n";
            elseInfo += this.chessBoard.client.oppositePutNum + "\n";
            string p2 = @"C:\csharp_gogame\GoGame\棋谱\"+timeString + @"\" + "elseInfo";
            writeStrToFile(elseInfo , p2);
        }

        public bool loadFromSGF(string info)
        {
            for (int i = 0; i + 3 < info.Length; i++)
            {
                if (info[i] == ';' && SGFInvChar[info[i + 1]] != 0 && info[i + 2] == '[')
                {
                    int player = SGFInvChar[info[i + 1]];
                    if (info[i + 3] == ']')
                    {
                        emptyTurn(player);
                        i += 3;
                    }
                    else
                    {
                        if (i + 5 < info.Length && info[i + 3] >= 'a' && info[i + 3] <= 's'
                            && info[i + 4] >= 'a' && info[i + 4] <= 's' && info[i + 5] == ']')
                        {
                            int col = info[i + 3] - 'a', row = info[i + 4] - 'a';
                            oneStep(row, col, player);
                            i += 5;
                        }
                        else
                        {
                            this.clearAllInfo();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 清空棋盘所有信息
        /// </summary>
        public void clearAllInfo()
        {
            Array.Clear(board, 0, board.Length);
            for (int i = 0; i < CNUM; i++)
            {
                pa[i] = i;
                qi[i] = calqi(i, 0);
            }
        }


        /// <summary>
        /// 轮子：将某个str存入path文件中
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path"></param>
        public void writeStrToFile(string str, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 计算player的对手的该提走的棋子
        /// </summary>
        /// <param name="player"></param>
        public void resetBoard(int player)
        {
            for (int i = 0; i < ROW; i++)
                for (int j = 0; j < COL; j++)
                {
                    if (board[i, j] == EMPTY) continue;
                    if (board[i, j] == player) continue;
                    if (qi[find(getidx(i, j))] == 0)
                        emptyComponent(i, j);
                }
        }

        public void emptyTurn(int player)
        {
            SGFINFO += ";" + SGFchar[player] + "[]";
            step++;
            if (step % 14 == 0) SGFINFO += '\n';
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
                    }
                }
            for (int i = 0; i < ROW; i++)
                for (int j = 0; j < COL; j++)
                {
                    if (board[i, j] != EMPTY) continue;
                    qi[getidx(i, j)] = calqi(getidx(i, j), 0);
                    pa[getidx(i, j)] = getidx(i, j);

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
