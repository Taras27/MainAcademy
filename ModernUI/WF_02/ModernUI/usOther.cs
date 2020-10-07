using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ModernUI
{
    public partial class usOther : UserControl
    {
        formTleLoad formTle;
        public usOther()
        {
            InitializeComponent();
        }

        private void usOther_Load(object sender, EventArgs e)
        {
            TimerTle.Enabled = true;
            TimerTle.Interval = 50;
            TimerTle.Start();
            TimerTle.Tick += TimerTle_Tick;
        }

        private void TimerTle_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.Link = textBox1.Text;
            openForm();           
        }

        private void openForm()
        {
            try
            {
                formTle = new formTleLoad();
                formTle.ShowDialog(this);
            }
            catch (Exception)
            {
                MessageBox.Show( "Some bad!","Error", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
           
        }        
    }
}
