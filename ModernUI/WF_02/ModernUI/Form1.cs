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
            usHome1.Show();
            usHelp1.Hide();
            usOther1.Hide();
            usTools1.Hide();
            usSetting1.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = button1.Text;
            usHome1.Show();
            usHelp1.Hide();
            usOther1.Hide();
            usTools1.Hide();
            usSetting1.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = button2.Text;
            usHome1.Hide();
            usHelp1.Hide();
            usOther1.Hide();
            usTools1.Hide();
            usSetting1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = button3.Text;
            usHome1.Hide();
            usHelp1.Hide();
            usOther1.Hide();
            usTools1.Show();
            usSetting1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = button4.Text;
            usHome1.Hide();
            usHelp1.Hide();
            usOther1.Show();
            usTools1.Hide();
            usSetting1.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = button5.Text;
            usHome1.Hide();
            usHelp1.Show();
            usOther1.Hide();
            usTools1.Hide();
            usSetting1.Hide();
        }
    }
}
