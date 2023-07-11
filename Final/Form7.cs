using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Form7 : Form
    {
        Form8 addp = new Form8();
        public Form4 home;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Melika\source\repos\Final\Final\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT sname,pname,ename FROM Products ";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["sname"].ToString();
                ListViewItem lv = new ListViewItem(name);
                string pname = reader["pname"].ToString();
                lv.SubItems.Add(pname);
                string ename = reader["ename"].ToString();
                lv.SubItems.Add(ename);
                listView1.Items.Add(lv);

            }


            sc.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            addp.ShowDialog();
            this.Hide();
            listView1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            listView1.Items.Clear();
        }
    }

        
}

