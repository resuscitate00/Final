﻿using System;
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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richTextBox1.Text))
                {
                    MessageBox.Show(" اطلاعات خواسته شده را کامل وارد کنید");
                    return;
                }

                if (string.IsNullOrEmpty(richTextBox2.Text))
                {
                    MessageBox.Show("اطلاعات خواسته شده را کامل وارد کنید");
                    return;
                }
                string name = richTextBox1.Text;
                string address = richTextBox2.Text;
                string phone = richTextBox3.Text;
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Melika\source\repos\Final\Final\Database1.mdf;Integrated Security=True");
                sc.Open();

                     string query = "INSERT INTO Supplier (name,address,phone) VALUES (N'" + name + "',N'" + address + "','" + phone + "')";
                    SqlCommand command = new SqlCommand(query, sc);
                    command.ExecuteNonQuery();
                    sc.Close();
                    MessageBox.Show("! با موفقیت افزوده شد ");
                    richTextBox1.Text = richTextBox3.Text = richTextBox2.Text = "";
                    this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
