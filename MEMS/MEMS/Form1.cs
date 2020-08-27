using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace MEMS
{    
    public partial class Form1 : Form
    {
        string data = "We write some data";
        static string writePath = @"C:\Users\TARAS\Desktop\testTXT\test.txt";
        int lineCounter = 1;
        SerialPort serialPort = new SerialPort();
        
        string DataIn;
        public Form1()
        {
            InitializeComponent();
            serialPort.DataReceived += SerialPort_DataReceived1;
        }

        private void SerialPort_DataReceived1(object sender, SerialDataReceivedEventArgs e)
        {
            ReadComPort();
            Invoke((MethodInvoker)(() =>
            {
                textBoxLog.Text += $"[{DateTime.Now.ToLongTimeString()}] Received data: -> {DataIn} \r\n";
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(writePath, true, Encoding.Default))
                {                    
                    file.Write("[{0}]\t[{1}] -> {2};\r\n",lineCounter++,DateTime.Now.ToString(), data);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
            timerScanSerialPorts.Enabled = true;
            timerScanSerialPorts.Tick += TimerScanSerialPorts_Tick;
            if (ports.Length == 0)
            {
                comboBoxPorts.Items.Clear();
                comboBoxPorts.Enabled = false;
            }
        }

        private void TimerScanSerialPorts_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.Clear();
            comboBoxPorts.Items.AddRange(ports);
            if (ports.Length == 0)
            {
                comboBoxPorts.Items.Clear();
                comboBoxPorts.Enabled = false;
            }
            else
            {
                comboBoxPorts.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = comboBoxPorts.Text;
                serialPort.BaudRate = int.Parse(comboBoxBaudRate.Text);
                serialPort.DataBits = int.Parse(comboBoxDataBits.Text);
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.Text);

                serialPort.ReadTimeout = 1000;
                serialPort.WriteTimeout = 1000;

                serialPort.Open();

                textBoxLog.Text += "COM PORT IS OPEN\r\n";
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                    textBoxLog.Text += "COM PORT IS CLOSED\r\n";
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }

        

        private async void  ReadComPort()
        {
            await Task.Run(() =>
            {                
                try
                {
                    if(serialPort.IsOpen)
                        DataIn = serialPort.ReadLine();              
                }
                catch (TimeoutException ex)
                {
                MessageBox.Show(ex.Message, "Time out exception!!!");
                }
            });
        }

        private void textBoxLog_TextChanged(object sender, EventArgs e)
        {
            textBoxLog.SelectionStart = textBoxLog.Text.Length;
            textBoxLog.ScrollToCaret();
        }
    }
}
