using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace ModernUI
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {        
        public Form1()
        {
            InitializeComponent();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = button1.Text;
            us_Home.Show();
            us_Help.Hide();
            us_Other.Hide();
            us_Tools.Hide();
            us_Setting.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = button1.Text;
            us_Home.Show();
            us_Help.Hide();
            us_Other.Hide();
            us_Tools.Hide();
            us_Setting.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = button2.Text;
            us_Home.Hide();
            us_Help.Hide();
            us_Other.Hide();
            us_Tools.Hide();
            us_Setting.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = button3.Text;
            us_Home.Hide();
            us_Help.Hide();
            us_Other.Hide();
            us_Tools.Show();
            us_Setting.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = button4.Text;
            us_Home.Hide();
            us_Help.Hide();
            us_Other.Show();
            us_Tools.Hide();
            us_Setting.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = button5.Text;
            us_Home.Hide();
            us_Help.Show();
            us_Other.Hide();
            us_Tools.Hide();
            us_Setting.Hide();
        }
    }
}
