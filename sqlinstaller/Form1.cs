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

namespace sqlinstaller
{
    public partial class Form1 : Form
    {
        string path_to_sql = "ingenerka.sql";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = textBox1.Text;
            string login = textBox2.Text;
            string password = textBox3.Text;
            string default_design = textBox4.Text;
            string unique_design = textBox5.Text;

            if (server.Trim() == "" || password.Trim() == "" || login.Trim() == "")
            {
                MessageBox.Show("Текст введи");
                return;
            }

            string sql = "";
            sql = File.ReadAllText(path_to_sql);

            SQLClass.CONNECTION_STRING = String.Format(
                "SslMode=none;" +
                "Server={0};" +
                "database=ingenerka;" +
                "port=3306;" +
                "uid={1};" +
                "pwd={2};" +
                "old guids=true;", server, login, password);

            try
            {
                SQLClass.OpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильный сервер: " + ex.Message);
                return;
            }

            SQLClass.Insert(sql);

            SQLClass.CloseConnection();

            string CONNECTION_STRING = String.Format(
            "SslMode=none;" +
            "Server={0};" +
            "database=ingenerka;" +
            "port=3306;" +
            "uid={1};" +
            "pwd={2};" +
            "old guids=true;", server, login, password);

            saveFileDialog1.ShowDialog();
            File.WriteAllText(saveFileDialog1.FileName, CONNECTION_STRING);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            path_to_sql = openFileDialog1.FileName;
        }
    }
}