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
    public partial class Form5 : Form
    {
        Form6 adds = new Form6();
        public Form4 home;
        public Form5()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        public void Form5_Load(object sender, EventArgs e)
        {
            
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Melika\source\repos\Final\Final\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT name,address,phone FROM Supplier ";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                ListViewItem lv = new ListViewItem(name);
                string address = reader["address"].ToString();
                lv.SubItems.Add(address);
                string phone = reader["phone"].ToString();
                lv.SubItems.Add(phone);
                listView1.Items.Add(lv);
              
            }
            

            sc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adds.ShowDialog();
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
