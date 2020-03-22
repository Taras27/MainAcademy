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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string str;
        
        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = "COM10";
            serialPort1.BaudRate = 115200;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;
            serialPort1.WriteTimeout = 500;
            serialPort1.ReadTimeout = 500;

            serialPort1.Open();
            checkBox1.Checked = true;
            ShowDataAsync();
            //Thread thread =  new Thread(ShowData);
            //thread.Start();
        }

        //private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    str = serialPort1.ReadLine();
        //    Invoke(new EventHandler(ShowData));
        //}

        private void ShowData()
        {
            
                string str = serialPort1.ReadLine();
                textBox1.Text += $"[{DateTime.Now.ToLongTimeString()}] -> {str};";
           
            
            //while (true)
            //{
            //    Invoke((MethodInvoker)(() =>
            //       {
            //            try
            //            {
            //                
            //            }
            //            catch (Exception) { }
            //        }));

            //if (checkBox.Checked)
            //{
            //    textBox.Text += str;
            //}
            //else if (checkBox.Checked)  //hex
            //{
            //    char[] values = str.ToCharArray();
            //    foreach (var value in values)
            //    {
            //        int tmp = Convert.ToInt32(value);
            //        textBox.Text += $"0x{tmp:X}, ";
            //    }
            //}
            //else if (checkBox.Checked) //dec
            //{

            //}
            //}
        }
        private async Task ShowDataAsync()
        {
            await Task.Run(() => ShowData());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {                    
                    serialPort1.Close();
                }
                catch (Exception)
                {
                     
                }

            }
            
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            Application.Exit();
        }
    }
       
}
