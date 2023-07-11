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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richTextBox4.Text))
                {
                    MessageBox.Show("برای ثبت نام اطلاعات خواسته شده را کامل وارد کنید");
                    return;
                }

                if (string.IsNullOrEmpty(richTextBox3.Text))
                {
                    MessageBox.Show("برای ثبت نام اطلاعات خواسته شده را کامل وارد کنید");
                    return;
                }
                string username = richTextBox3.Text;
                string pass = richTextBox4.Text;
                string passs = richTextBox5.Text;
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Melika\source\repos\Final\Final\Database1.mdf;Integrated Security=True");
                sc.Open();

                if (passs.Contains(pass))
                {
                    string query = "INSERT INTO users (code,pass) VALUES ('" + username + "','" + pass + "')";
                    SqlCommand command = new SqlCommand(query, sc);
                    command.ExecuteNonQuery();
                    sc.Close();
                    MessageBox.Show("!ثبت نام با موفقیت انجام شد ");
                    richTextBox4.Text = richTextBox3.Text = richTextBox5.Text = "";
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("!رمز عبور های وارد شده یکسان نمیباشند");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
