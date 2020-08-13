using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Text;
using System.Diagnostics;

namespace UDP_Terminall
{    
    public partial class Form1 : Form
    {
        const byte axisAz = 0x01;
        const byte axisEl = 0x02;
        const byte axisPol = 0x04;

        const byte dirCC = 0x00;
        const byte dirCCW = 0x01;

        static IPEndPoint RemoteAddress = new IPEndPoint(0, 0); 
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        static EndPoint remoteIp = new IPEndPoint(IPAddress.Parse("192.168.0.16"), 10000);
        static Thread receiveThread = new Thread(ReceiveMessage);

        int speedValueAz, speedValueEl, speedValuePol;
        int speedValueRealAz, speedValueRealEl, speedValueRealPol;
        float sensorValueAzF, sensorValueWindF, sensorValueElF, sensorValuePolF;
        int sensorValueEl, sensorValuePol;              
        static byte[] data = new byte[256];
        static int bytes;
        byte[] tranceivedData = new byte[256];
        static string message;
        int counter = 0;

        #region buttons

        private void buttonUp_MouseDown(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x05;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF2;
            tranceivedData[4] = axisEl;
            tranceivedData[5] = dirCC;
            tranceivedData[6] = (byte)speedValueEl;
            tranceivedData[7] = (byte)CRC(tranceivedData, 7);

            SendMessage(tranceivedData, 8);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 8) + "\r\n";
        }

        private void buttonUp_MouseUp(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x03;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF3;
            tranceivedData[4] = axisEl;
            tranceivedData[5] = (byte)CRC(tranceivedData, 5);

            SendMessage(tranceivedData, 6);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 6) + "\r\n"; 
        }

        private void buttonDown_MouseDown(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x05;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF2;
            tranceivedData[4] = axisEl;
            tranceivedData[5] = dirCCW;
            tranceivedData[6] = (byte)speedValueEl;
            tranceivedData[7] = (byte)CRC(tranceivedData, 7);

            SendMessage(tranceivedData, 8);
            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 8) + "\r\n";
        }

        private void buttonDown_MouseUp(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x03;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF3;
            tranceivedData[4] = axisEl;
            tranceivedData[5] = (byte)CRC(tranceivedData, 5);

            SendMessage(tranceivedData, 6);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 6) + "\r\n";
        }

        private void buttonLeft_MouseDown(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x05;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF2;
            tranceivedData[4] = axisAz;
            tranceivedData[5] = dirCCW;
            tranceivedData[6] = (byte)speedValueAz;
            tranceivedData[7] = (byte)CRC(tranceivedData, 7);

            SendMessage(tranceivedData, 8);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 8) + "\r\n";
        }

        private void buttonLeft_MouseUp(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x03;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF3;
            tranceivedData[4] = axisAz;
            tranceivedData[5] = (byte)CRC(tranceivedData, 5);

            SendMessage(tranceivedData, 6);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 6) + "\r\n";
        }

        private void buttonRight_MouseDown(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x05;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF2;
            tranceivedData[4] = axisAz;
            tranceivedData[5] = dirCC;
            tranceivedData[6] = (byte)speedValueAz;
            tranceivedData[7] = (byte)CRC(tranceivedData, 7);

            SendMessage(tranceivedData, 8);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 8) + "\r\n";
        }

        private void buttonRight_MouseUp(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x03;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF3;
            tranceivedData[4] = axisAz;
            tranceivedData[5] = (byte)CRC(tranceivedData, 5);

            SendMessage(tranceivedData, 6);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 6) + "\r\n";
        }

        private void buttonPolRight_MouseDown(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x05;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF2;
            tranceivedData[4] = axisPol;
            tranceivedData[5] = dirCC;
            tranceivedData[6] = (byte)speedValuePol;
            tranceivedData[7] = (byte)CRC(tranceivedData, 7);

            SendMessage(tranceivedData, 8);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 8) + "\r\n";
        }

        private void buttonPolRight_MouseUp(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x03;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF3;
            tranceivedData[4] = axisPol;
            tranceivedData[5] = (byte)CRC(tranceivedData, 5);

            SendMessage(tranceivedData, 6);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 6) + "\r\n";
        }

        private void buttonPolLeft_MouseDown(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x05;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF2;
            tranceivedData[4] = axisPol;
            tranceivedData[5] = dirCCW;
            tranceivedData[6] = (byte)speedValuePol;
            tranceivedData[7] = (byte)CRC(tranceivedData, 7);

            SendMessage(tranceivedData, 8);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 8) + "\r\n";
        }

        private void buttonPolLeft_MouseUp(object sender, MouseEventArgs e)
        {
            tranceivedData[0] = 0x7E;
            tranceivedData[1] = 0x03;
            tranceivedData[2] = 0x03;
            tranceivedData[3] = 0xF3;
            tranceivedData[4] = axisPol;
            tranceivedData[5] = (byte)CRC(tranceivedData, 5);

            SendMessage(tranceivedData, 6);

            richTextBoxLog.Text += "[" + DateTime.Now + "]" + " Transeived data -> " + BitConverter.ToString(tranceivedData, 0, 6) + "\r\n";
        }
        #endregion
        private void buttonClear_MouseUp(object sender, MouseEventArgs e)
        {
            richTextBoxLog.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        
       
        public Form1()
        {
            InitializeComponent();
            
            timerSpeed.Interval = 100;
            timerSpeed.Tick += TimerSpeed_Tick;

            
            timerUpDateData.Interval = 50;
            timerUpDateData.Tick += TimerUpDateData_Tick;

            timerStatus.Interval = 200;
            timerStatus.Tick += TimerStatus_Tick;

            timerLS.Interval = 500;
            timerLS.Tick += timerLS_tTick;           

            groupBoxButtons.Enabled = false;
            groupBoxSensor.Enabled = false;
            groupBoxData.Enabled = false;           

        }

        private void buttonUdpOpen_Click(object sender, EventArgs e)
        {
            try
            {
                RemoteAddress.Address = IPAddress.Parse(textBoxIp.Text);
                RemoteAddress.Port = Convert.ToInt32(textBoxPort.Text);
                timerLS.Enabled = true;
                timerStatus.Enabled = true;
                timerUpDateData.Enabled = true;
                timerSpeed.Enabled = true;

                groupBoxButtons.Enabled = true;
                groupBoxSensor.Enabled = true;
                groupBoxData.Enabled = true;

                try
                {
                    socket.Bind(remoteIp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    if(receiveThread.ThreadState == System.Threading.ThreadState.Suspended)
                        receiveThread.Resume();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonUdpClose_Click(object sender, EventArgs e)
        {
            try
            {
                timerLS.Enabled = false;
                timerStatus.Enabled = false;
                timerUpDateData.Enabled = false;
                timerSpeed.Enabled = false;

                groupBoxButtons.Enabled = false;
                groupBoxSensor.Enabled = false;
                groupBoxData.Enabled = false;

                try
                {          
                    socket.Disconnect(true);
                    receiveThread.Suspend();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //finally
                //{
                //    socket.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {           
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;           
            richTextBoxLog.ScrollToCaret();           
        }

        private void timerLS_tTick(object sender, EventArgs e)
        {
            if (data[25] == 0)
            {
                if (data[24] == 0x01)
                {
                    if ((counter % 2) == 0)
                        radioButtonLeft.Checked = true;
                    else
                        radioButtonLeft.Checked = false;
                }
                else
                {
                    radioButtonLeft.Checked = false;
                }

                if (data[24] == 0x02)
                {
                    if ((counter % 2) == 0)
                        radioButtonRight.Checked = true;
                    else
                        radioButtonRight.Checked = false;
                }
                else
                {
                    radioButtonRight.Checked = false;
                }

                if (data[24] == 0x04)
                {
                    if ((counter % 2) == 0)
                        radioButtonUp.Checked = true;
                    else
                        radioButtonUp.Checked = false;
                }
                else
                {
                    radioButtonUp.Checked = false;
                }

                if (data[24] == 0x08)
                {
                    if ((counter % 2) == 0)
                        radioButtonDown.Checked = true;
                    else
                        radioButtonDown.Checked = false;
                }
                else
                {
                    radioButtonDown.Checked = false;
                }
                counter++;
            }
        }

        private void TimerUpDateData_Tick(object sender, EventArgs e)
        {
            sensorValueWindF = ((data[22] << 8) + data[23]) / 10f;
            sensorValueAzF = ((data[14] << 8) + data[15])/100f;
            
            if ((data[17] & 0x80) == 0)
            {
                sensorValueEl = ((data[17] << 8) + data[18]);
            }
            else
            {
                sensorValueEl = ((data[17] << 8) + data[18]);
                sensorValueEl = ((~sensorValueEl - 1) & 0xFFFF)* -1;
            }

            if ((data[20] & 0x80) == 0)
            {
                sensorValuePol = ((data[20] << 8) + data[21]);                
            }
            else
            {
                sensorValuePol = ((data[20] << 8) + data[21]);
                sensorValuePol = ((~sensorValuePol - 1) & 0xFFFF) * -1;
            }

            sensorValueElF = sensorValueEl / 100f;
            sensorValuePolF = sensorValuePol / 100f;

            labelSensorAz.Text = sensorValueAzF.ToString();
            labelSensorEl.Text = sensorValueElF.ToString();
            labelSensorPol.Text = sensorValuePolF.ToString();

            if (data[5] == 0x01)
                speedValueRealAz = data[6] * -1;
            else
                speedValueRealAz = data[6];

            if (data[8] == 0x01)
                speedValueRealEl = data[9] * -1;
            else
                speedValueRealEl = data[9];

            if (data[11] == 0x01)
                speedValueRealPol = data[12] * -1;
            else
                speedValueRealPol = data[12];            

            labelSpeedAZ.Text = speedValueRealAz.ToString();
            labelSpeedEL.Text = speedValueRealEl.ToString();
            labelSpeedPOL.Text = speedValueRealPol.ToString();
            labelWindSpeed.Text = sensorValueWindF.ToString();

            if (data[24] == 0)
            {
                if (Convert.ToBoolean(data[25] & 0x01))
                    radioButtonLeft.Checked = true;
                else
                    radioButtonLeft.Checked = false;


                if (Convert.ToBoolean(data[25] & 0x02))
                    radioButtonRight.Checked = true;
                else
                    radioButtonRight.Checked = false;


                if (Convert.ToBoolean(data[25] & 0x04))

                    radioButtonDown.Checked = true;
                else
                    radioButtonDown.Checked = false;



                if (Convert.ToBoolean(data[25] & 0x08))
                    radioButtonUp.Checked = true;
                else
                    radioButtonUp.Checked = false;
            }
        }

        private void TimerStatus_Tick(object sender, EventArgs e)
        {
            getStatus();
        }

        private async void getStatus()
        {
            tranceivedData[0] = 0x7e;
            tranceivedData[1] = 0x02;
            tranceivedData[2] = 0x02;
            tranceivedData[3] = 0xf8;
            tranceivedData[4] = 0x86;

            await Task.Run(() =>
            {
                SendMessage(tranceivedData, 5);
            });
        }

        private void TimerSpeed_Tick(object sender, EventArgs e)
        {
            speedValueAz = trackBarAz.Value;
            speedValueEl = trackBarEl.Value;
            speedValuePol = trackBarPol.Value;
        }

        private static void SendMessage(byte[] data, int lenght)
        {
            UdpClient sender = new UdpClient();
            try
            {              
                sender.Send(data, lenght, RemoteAddress);               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        private static void ReceiveMessage()
        {   
            try
            {
                while (true)
                {
                    bytes = socket.ReceiveFrom(data, ref remoteIp);
                    message = BitConverter.ToString(data, 0, bytes);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
        
        private int CRC(byte[] data, int lenght)
        {
            int tmp=0;
            for (int i = 0; i < lenght; i++)
            {
                tmp ^= data[i];
            }
            return tmp & 0xFF;
        }
    }
}
