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
    public partial class ItemSidebarControl : UserControl
    {
        public delegate void ItemClick(Extention.DVItemList type);
        public event ItemClick click = null;

        public delegate void SettingClick(Extention.SettingItemList type);
        public event SettingClick settingClick = null;

        public delegate void UserClick(Extention.UserItemList type);
        public event UserClick userClick = null;

        public delegate void HoiVienClick(Extention.HVItemList type);
        public event HoiVienClick hoiClick = null;

        public Extention.DVItemList type { get; set; }

        public Extention.SettingItemList typeSetting { get; set; }

        public Extention.UserItemList typeUser { get; set; }

        public Extention.HVItemList typeHV { get; set; }

        public ItemSidebarControl()
        {
            InitializeComponent();
        }

        public ItemSidebarControl(string text, Bitmap icon)
        {
            InitializeComponent();
            btnItem.Text = text;
            btnItem.Iconimage = icon;
        }

        public ItemSidebarControl(string text, Bitmap icon, Extention.DVItemList type)
        {
            InitializeComponent();
            btnItem.Text = text;
            btnItem.Iconimage = icon;
            this.type = type;
        }

        public ItemSidebarControl(string text, Bitmap icon, Extention.SettingItemList type)
        {
            InitializeComponent();
            btnItem.Text = text;
            btnItem.Iconimage = icon;
            this.typeSetting = type;
        }

        public ItemSidebarControl(string text, Bitmap icon, Extention.UserItemList type)
        {
            InitializeComponent();
            btnItem.Text = text;
            btnItem.Iconimage = icon;
            this.typeUser = type;
        }

        public ItemSidebarControl(string text, Bitmap icon, Extention.HVItemList type)
        {
            InitializeComponent();
            btnItem.Text = text;
            btnItem.Iconimage = icon;
            this.typeHV = type;
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            if(click != null)
            {
                click(this.type);
            }

            if(settingClick != null)
            {
                settingClick(this.typeSetting);
            }

            if(userClick != null)
            {
                userClick(this.typeUser);
            }
            if(hoiClick != null)
            {
                hoiClick(this.typeHV);
            }
        }

    }
}
