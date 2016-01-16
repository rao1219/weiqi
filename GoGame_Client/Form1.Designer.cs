
namespace GoGame_Client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.reqBattle = new System.Windows.Forms.Button();
            this.txtBox_enemyName = new System.Windows.Forms.TextBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.putNumLabel = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRanzi = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.btnFinsh = new System.Windows.Forms.Button();
            this.picBoxChessBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxChessBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // reqBattle
            // 
            this.reqBattle.BackColor = System.Drawing.Color.White;
            this.reqBattle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reqBattle.BackgroundImage")));
            this.reqBattle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.reqBattle.FlatAppearance.BorderSize = 0;
            this.reqBattle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reqBattle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reqBattle.ForeColor = System.Drawing.Color.DimGray;
            this.reqBattle.Location = new System.Drawing.Point(713, 583);
            this.reqBattle.Name = "reqBattle";
            this.reqBattle.Size = new System.Drawing.Size(110, 38);
            this.reqBattle.TabIndex = 2;
            this.reqBattle.Text = "请求对弈";
            this.reqBattle.UseVisualStyleBackColor = false;
            this.reqBattle.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBox_enemyName
            // 
            this.txtBox_enemyName.Location = new System.Drawing.Point(717, 542);
            this.txtBox_enemyName.Name = "txtBox_enemyName";
            this.txtBox_enemyName.Size = new System.Drawing.Size(100, 21);
            this.txtBox_enemyName.TabIndex = 3;
            this.txtBox_enemyName.Text = "请输入对方昵称";
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbColor.Location = new System.Drawing.Point(694, 181);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(89, 12);
            this.lbColor.TabIndex = 4;
            this.lbColor.Text = "本方棋子颜色：";
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(679, 165);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(175, 83);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // putNumLabel
            // 
            this.putNumLabel.AutoSize = true;
            this.putNumLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.putNumLabel.Location = new System.Drawing.Point(694, 225);
            this.putNumLabel.Name = "putNumLabel";
            this.putNumLabel.Size = new System.Drawing.Size(71, 12);
            this.putNumLabel.TabIndex = 7;
            this.putNumLabel.Text = "已下子数：0";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(679, 22);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(175, 90);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Location = new System.Drawing.Point(710, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 39);
            this.button1.TabIndex = 9;
            this.button1.Text = "保存棋局";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.White;
            this.btnLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoad.BackgroundImage")));
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoad.ForeColor = System.Drawing.Color.DimGray;
            this.btnLoad.Location = new System.Drawing.Point(710, 68);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(113, 35);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "载入棋局";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(694, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "对手棋子颜色：";
            // 
            // btnRanzi
            // 
            this.btnRanzi.BackColor = System.Drawing.Color.White;
            this.btnRanzi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRanzi.BackgroundImage")));
            this.btnRanzi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRanzi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRanzi.FlatAppearance.BorderSize = 0;
            this.btnRanzi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRanzi.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRanzi.ForeColor = System.Drawing.Color.DimGray;
            this.btnRanzi.Location = new System.Drawing.Point(713, 290);
            this.btnRanzi.Name = "btnRanzi";
            this.btnRanzi.Size = new System.Drawing.Size(110, 50);
            this.btnRanzi.TabIndex = 13;
            this.btnRanzi.Text = "本轮让子";
            this.btnRanzi.UseVisualStyleBackColor = false;
            this.btnRanzi.Click += new System.EventHandler(this.btnRanzi_Click);
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(679, 276);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(175, 127);
            this.listView3.TabIndex = 12;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // btnFinsh
            // 
            this.btnFinsh.BackColor = System.Drawing.Color.White;
            this.btnFinsh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFinsh.BackgroundImage")));
            this.btnFinsh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFinsh.FlatAppearance.BorderSize = 0;
            this.btnFinsh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinsh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinsh.ForeColor = System.Drawing.Color.DimGray;
            this.btnFinsh.Location = new System.Drawing.Point(713, 346);
            this.btnFinsh.Name = "btnFinsh";
            this.btnFinsh.Size = new System.Drawing.Size(110, 42);
            this.btnFinsh.TabIndex = 15;
            this.btnFinsh.Text = "终局";
            this.btnFinsh.UseVisualStyleBackColor = false;
            this.btnFinsh.Click += new System.EventHandler(this.btnFinsh_Click);
            // 
            // picBoxChessBoard
            // 
            this.picBoxChessBoard.BackColor = System.Drawing.Color.Azure;
            this.picBoxChessBoard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxChessBoard.BackgroundImage")));
            this.picBoxChessBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxChessBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxChessBoard.Location = new System.Drawing.Point(0, 0);
            this.picBoxChessBoard.Name = "picBoxChessBoard";
            this.picBoxChessBoard.Size = new System.Drawing.Size(660, 660);
            this.picBoxChessBoard.TabIndex = 0;
            this.picBoxChessBoard.TabStop = false;
            this.picBoxChessBoard.Click += new System.EventHandler(this.picBoxChessBoard_Click);
            this.picBoxChessBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxChessBoard_Paint);
            this.picBoxChessBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxChessBoard_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 666);
            this.Controls.Add(this.btnFinsh);
            this.Controls.Add(this.btnRanzi);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.putNumLabel);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.txtBox_enemyName);
            this.Controls.Add(this.reqBattle);
            this.Controls.Add(this.picBoxChessBoard);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxChessBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button reqBattle;
        private System.Windows.Forms.TextBox txtBox_enemyName;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label putNumLabel;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRanzi;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Button btnFinsh;
        private System.Windows.Forms.PictureBox picBoxChessBoard;
    }
}

