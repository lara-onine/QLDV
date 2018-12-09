using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.UC.Items
{
    public partial class ItemEvent : UserControl
    {
        public ItemEvent()
        {
            InitializeComponent();
        }

        public ItemEvent(string day, string month, string year, string name, string content)
        {
            InitializeComponent();
            lblDay.Text = day + "/"+month;
            lblMonth.Text = year;
            lblNameEvent.Text = name;
            lblContent.Text = content;
        }
    }
}
