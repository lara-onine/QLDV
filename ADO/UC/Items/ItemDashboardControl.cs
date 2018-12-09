using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.UC
{
    public partial class ItemDashboardControl : UserControl
    {
        public ItemDashboardControl()
        {
            InitializeComponent();
        }

        public ItemDashboardControl(string count, string text, int r, int g, int b)
        {
            InitializeComponent();
            lblText.Text = text;
            lblCount.Text = count;
            this.BackColor = Color.FromArgb(r, g, b);
        }
    }
}
