using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernUI
{
    public partial class DriveTo : Form
    {
        List<string> tle = new List<string>(); 
        public DriveTo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName);
                richTextBox1.Text = openFileDialog1.FileName;

                try
                {                    
                    tle = File.ReadAllLines(openFileDialog1.FileName).ToList();

                    for (int i = 0; i < tle.Count; i++)
                    {
                        if ((i % 3) == 0)
                            comboBox1.Items.Add(tle[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                    
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Text = null;
                comboBox1.Enabled = false;
                groupBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = true;
                groupBox1.Enabled = false;
            }
        }

        private void DriveTo_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = false;
                groupBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = true;
                groupBox1.Enabled = false;
            }
        }
    }
}
