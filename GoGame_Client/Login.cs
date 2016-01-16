using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoGame_Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           // this.BackgroundImage = Image.FromFile("../../../image/bg.gif");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String txt = txtbox_userName.Text;
            Client client = new Client();
            client.connect(txt);
            Form1 form1 = new Form1(client);
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
