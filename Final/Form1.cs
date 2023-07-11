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
    public partial class Form1 : Form
    {
        Form2 signin = new Form2();
        Form3 pass = new Form3();
        Form4 home = new Form4();
        public Form1()
        {
            InitializeComponent();
            pass.login = this;
        }
        List<Panel> listpanel = new List<Panel>();
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richTextBox1.Text))
                {
                    MessageBox.Show("اطلاعات خواسته شده را وارد کنید");
                    return;
                }
                if (string.IsNullOrEmpty(richTextBox2.Text))
                {
                    MessageBox.Show("اطلاعات خواسته شده را وارد کنید");
                    return;
                }
                string username = richTextBox1.Text;
                string pass = richTextBox2.Text;

                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Melika\source\repos\Final\Final\Database1.mdf;Integrated Security=True");
                sc.Open();
                string query = "SELECT pass FROM Users WHERE code = '" + username + "'";
                SqlCommand cmd = new SqlCommand(query, sc);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string password = reader["pass"].ToString();
                if (pass == password)
                {
                    home.ShowDialog();
                    this.Hide();
                }
                else
                { 
                    MessageBox.Show("!رمز عبور یا کد کاربری نادرست میباشد");
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            signin.ShowDialog();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
             pass.ShowDialog(); 

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
    
}
