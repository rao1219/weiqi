namespace GoGame
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartServer = new System.Windows.Forms.Button();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLookUser = new System.Windows.Forms.Button();
            this.btnLookPlayerPair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(24, 63);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(100, 53);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "开启服务器";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(149, 35);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(348, 266);
            this.infoTextBox.TabIndex = 1;
            this.infoTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "服务器信息窗";
            // 
            // btnLookUser
            // 
            this.btnLookUser.Location = new System.Drawing.Point(24, 135);
            this.btnLookUser.Name = "btnLookUser";
            this.btnLookUser.Size = new System.Drawing.Size(100, 53);
            this.btnLookUser.TabIndex = 3;
            this.btnLookUser.Text = "查看连入用户";
            this.btnLookUser.UseVisualStyleBackColor = true;
            this.btnLookUser.Click += new System.EventHandler(this.btnLookUser_Click);
            // 
            // btnLookPlayerPair
            // 
            this.btnLookPlayerPair.Location = new System.Drawing.Point(24, 207);
            this.btnLookPlayerPair.Name = "btnLookPlayerPair";
            this.btnLookPlayerPair.Size = new System.Drawing.Size(100, 53);
            this.btnLookPlayerPair.TabIndex = 4;
            this.btnLookPlayerPair.Text = "查看对战用户";
            this.btnLookPlayerPair.UseVisualStyleBackColor = true;
            this.btnLookPlayerPair.Click += new System.EventHandler(this.btnLookPlayerPair_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 330);
            this.Controls.Add(this.btnLookPlayerPair);
            this.Controls.Add(this.btnLookUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.btnStartServer);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.RichTextBox infoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLookUser;
        private System.Windows.Forms.Button btnLookPlayerPair;
    }
}