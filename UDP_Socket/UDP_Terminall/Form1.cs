using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_Terminall
{
    
    public partial class Form1 : Form
    {
        int speedAz, speedEl, SpeedPol;
        UdpClient udpClient = new UdpClient();
        public Form1()
        {
            InitializeComponent();
            Timer timerSpeed = new Timer();
            timerSpeed.Interval = 50;
            timerSpeed.Start();
            timerSpeed.Tick += TimerSpeed_Tick;

            Timer timerStatus = new Timer();
            timerStatus.Interval = 100;
            timerStatus.Start();
            timerStatus.Tick += TimerStatus_Tick;
        }

        private void TimerStatus_Tick(object sender, EventArgs e)
        {
            if (udpClient.EnableBroadcast == true)
            {
                byte[] statusArray = new byte[] { 0x7E, 0x02, 0x02, 0xF8, 0x86 };

                udpClient.Send(statusArray, statusArray.Length);
            }
        }

        private void TimerSpeed_Tick(object sender, EventArgs e)
        {
            speedAz = trackBar3.Value;
            speedEl = trackBar1.Value;
            SpeedPol = trackBar2.Value;

            if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0))
            {
                button7.Enabled = false;
            }
            else
                button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            udpClient.Connect(textBox1.Text, int.Parse(textBox2.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            udpClient.Close();
        }

        private void button4_KeyUp(object sender, KeyEventArgs e)
        {
            //byte[] array = new byte {  };
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
