using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ADO.Code;
namespace ADO.UC
{
    public partial class ItemHomeControl : UserControl
    {
        private Bitmap icon;
        private Bitmap iconActive;
        public Extention.ItemList type { get; set; }
        public string Name_Item { get; set; }


        public delegate void itemClick(Extention.ItemList type);
        public event itemClick clickEvent;
        public ItemHomeControl()
        {
            InitializeComponent();
        }

        public ItemHomeControl(Extention.ItemList type, string name, string text, Bitmap icon, Bitmap iconActive)
        {
            InitializeComponent();
            label1.Text = text;
            pictureBox1.Image = icon;
            this.iconActive = iconActive;
            this.icon = icon;
            Name_Item = name;
            this.type = type;
        }
        

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(40, 117, 239);
            label1.ForeColor = Color.White;
            pictureBox1.Image = iconActive;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
            label1.ForeColor = Color.Black;
            pictureBox1.Image = this.icon;
        }

        private void ItemControl_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(40, 117, 239);
            label1.ForeColor = Color.White;
            pictureBox1.Image = iconActive;
        }

        private void ItemControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
            label1.ForeColor = Color.Black;
            pictureBox1.Image = this.icon;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(40, 117, 239);
            label1.ForeColor = Color.White;
            pictureBox1.Image = iconActive;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
            label1.ForeColor = Color.Black;
            pictureBox1.Image = this.icon;
        }

        void click()
        {
            if (clickEvent != null)
            {
                clickEvent(this.type);
            }
        }

        private void ItemControl_Click(object sender, EventArgs e)
        {
            click();
        }
    }
}
