using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoGame
{
    
    public partial class ServerForm : Form
    {
        Server server;
        public ServerForm()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("../../../image/bg.gif");
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            server = new Server(infoTextBox, this);
            server.Listen();
        }

        private void btnLookUser_Click(object sender, EventArgs e)
        {
            string userList = "";
            Dictionary<string,Socket>.Enumerator it = server.getSocketDic().GetEnumerator();
            while (it.MoveNext())
            {
                userList = userList + it.Current.Key + '\n';
            } 
            MessageBox.Show(userList);
        }

        private void btnLookPlayerPair_Click(object sender, EventArgs e)
        {
            Dictionary<string, string>.Enumerator it = server.getPlayerPairDic().GetEnumerator();
            string content = "";
            while (it.MoveNext())
            {
                string key = it.Current.Key, value = it.Current.Value;
                content = content + key + " <-> " + value + '\n';
                it.MoveNext();
            }
            MessageBox.Show(content);
        }
        public RichTextBox getInfoTextBox()
        {
            return infoTextBox;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
