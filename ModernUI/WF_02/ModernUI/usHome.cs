using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernUI
{
    
    public partial class usHome : UserControl
    {
        DriveTable driveTable = null;
        DriveTo driveTo = null;
        public usHome()
        {
            InitializeComponent();
        }

        private void usHome_Load(object sender, EventArgs e)
        {
            pbDown.Hide();
            pbTop.Hide();
            pbLeft.Hide();
            pbRight.Hide();
            pbPolRight.Hide();
            pbPolLeft.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)//table
        {
            driveTable = new DriveTable();
            driveTable.ShowDialog(this);
        }

        private void metroButton3_Click(object sender, EventArgs e)//driveTo
        {
            driveTo = new DriveTo();
            driveTo.ShowDialog(this);
        }
    }
}
