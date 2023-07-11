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
    public partial class Form3 : Form
    {
        public Form1 login;
        public Form3()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            try
            {
                string username = richTextBox6.Text;
                if (string.IsNullOrEmpty(richTextBox6.Text))
                {
                    MessageBox.Show("برای دریافت رمز عبور کد ملی خود را وارد کنید");
                    return;
                }

                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Melika\source\repos\Final\Final\Database1.mdf;Integrated Security=True");
                sc.Open();
                string query = "SELECT pass FROM Users WHERE code = '" + username + "'";
                SqlCommand cmd = new SqlCommand(query, sc);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string password = reader["pass"].ToString();
                login.richTextBox1.Text = username;
                login.richTextBox2.Text = password;

                richTextBox6.Text = "";
                this.Hide();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("!رمز عبوری برای کد کاربری وارد شده یافت نشد");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

       
    }
}
