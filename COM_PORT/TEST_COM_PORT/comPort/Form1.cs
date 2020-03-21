using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comPort
{
    public partial class Form1 : Form
    {
        string DataOut;
        string DataIn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxComPort.Items.AddRange(ports);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBoxComPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(comboBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBit.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.Text); 

                serialPort1.Open();
                progressBar1.Value = 100;
                button1.Enabled = false;
                button2.Enabled = true;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = true;
                button2.Enabled = false;
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                DataOut = textBox1.Text;
                serialPort1.WriteLine(DataOut + "\r\n");
            }
            else
            {
                MessageBox.Show("Open COM Port");                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxComPort.Items.Clear();
            comboBoxComPort.Items.AddRange(ports);
            //textBox2.Text += $"[{DateTime.Now.ToLongTimeString()}] -> Refresh com port list.\r\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void ReadComPort ()
        {
            new Thread(() =>
           {
               Invoke((MethodInvoker)(()=>
               {
                   try
                   {
                        DataIn = serialPort1.ReadExisting();
                        textBox2.Text += $"[{DateTime.Now.ToLongTimeString()}] Received data: -> {DataIn}";
                   }
                   catch (TimeoutException ex)
                   {
                       MessageBox.Show(ex.Message, "Time out exception!!!");
                   }
                  
               }));
           }).Start();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReadComPort();            
        }
    }
}
