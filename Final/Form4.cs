using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    
    public partial class Form4 : Form
    {
        Form5 s = new Form5();
        Form7 p = new Form7();
        public Form4()
        {
            InitializeComponent();
            s.home = this;
            p.home = this;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.ShowDialog();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            p.ShowDialog();
        }

        
    }
}
