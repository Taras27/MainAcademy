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
    }
}
