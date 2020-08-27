using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       

        private void Maximize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            maximize.Visible = false;
            restore.Visible = true;
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            restore.Visible = false;
            maximize.Visible = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (double i = 0.1; i < 50; i+=0.1)
            {
                chart1.Series[0].Points.AddXY(i, Math.Sin(i));
                chart1.Series[1].Points.AddXY(i, Math.Cos(i));
            }
        }
    }
}
