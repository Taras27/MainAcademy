using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernUI
{
    public partial class formTleLoad : Form
    {
        
        public formTleLoad()
        {
            InitializeComponent();
        }

        WebClient client;
        formTleLoad form; //= new formTleLoad();

        void TleDownload()
        {
            string url = DataBase.Link;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (!string.IsNullOrEmpty(url))
            {
                Uri uri = new Uri(url);
                string fileName = System.IO.Path.GetFileName(uri.AbsolutePath);

                try
                {
                    client.DownloadFileAsync(uri, Application.StartupPath + "/TLE/" + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }           
        }

        private void formTleLoad_Load(object sender, EventArgs e)
        {
            label2.Text += "Download from: " + DataBase.Link;
            client = new WebClient();
            client.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            client.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            Thread thread = new Thread(TleDownload);
            thread.Start();           
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                progressBar1.Minimum = 0;
                double receive = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = receive / total * 100;
                label3.Text = $"Downloaded {string.Format("{0:0.##}", percentage)}%";
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            }));
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {            
            if (MessageBox.Show("Download complette!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK )
            {
                
            }
        }
        void closeForm()
        {
            form = new formTleLoad();
            form.Hide();
        }
    }
}
