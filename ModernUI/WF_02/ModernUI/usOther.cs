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
            Thread downloadTLE_Thread = new Thread(new ThreadStart(openForm));
            downloadTLE_Thread.Start();
        }

        private void openForm()
        {
            try
            {
                Application.Run(new formTleLoad());
            }
            catch (Exception)
            {
                MessageBox.Show( "Some bad!","Error", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
           
        }
    }
}
