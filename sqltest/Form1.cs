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

namespace sqltest
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = textBox1.Text;
            string login = textBox2.Text;
            string password = textBox3.Text;

            if (server.Trim() == "" || password.Trim() == "" || login.Trim() == "")
            {
                return;
            }

            string sql = File.ReadAllText("ingenerka.sql");

            SQLClass.CONNECTION_STRING = String.Format(
                "SslMode=none;" +
                "Server={0};" +
                "database=ingenerka;" +
                "port=3306;" +
                "uid={1};" +
                "pwd={2};" +
                "old guids=true;", server, login, password);

            SQLClass.OpenConnection();

            SQLClass.Insert(sql);

            SQLClass.CloseConnection();
        }
    }
}
