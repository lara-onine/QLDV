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
    public partial class HomeControl : UserControl
    {

        public delegate void ItemClicked(Extention.ItemList type);
        public event ItemClicked clicked;

        List<ItemHomeControl> items = new List<ItemHomeControl>()
        {
            new ItemHomeControl(Extention.ItemList.Dashboard,"Dashboard","Dashboard", ADO.Properties.Resources.Home_96px, ADO.Properties.Resources.Home_Light_96px),
            new ItemHomeControl(Extention.ItemList.QLDV,"QLDV","Quản lý đoàn viên", ADO.Properties.Resources.Male_User_96px, ADO.Properties.Resources.Male_User_Light_96px),
            new ItemHomeControl(Extention.ItemList.QLHV,"QLHV","Quản lý hội viên", ADO.Properties.Resources.Staff_96px, ADO.Properties.Resources.Staff_Light_96px),
            new ItemHomeControl(Extention.ItemList.Event,"Event","Sự kiện", ADO.Properties.Resources.Calendar_96px, ADO.Properties.Resources.Calendar_Light_96px),
            new ItemHomeControl(Extention.ItemList.User,"User", "Người dùng", ADO.Properties.Resources.Admin_Settings_Male_96px, ADO.Properties.Resources.Admin_Settings_Male_Light_96px),
            new ItemHomeControl(Extention.ItemList.Setting,"Setting", "Cài đặt", ADO.Properties.Resources.Settings_96px, ADO.Properties.Resources.Settings_Light_96px),
        };
        public HomeControl()
        {
            InitializeComponent();
            for (int i = 0; i < items.Count; i++)
            {
                items[i].clickEvent += HomeControl_clickEvent;
                flowLayoutPanel1.Controls.Add(items[i]);
            }
        }

        private void HomeControl_clickEvent(Extention.ItemList type)
        {
            if(clicked != null)
            {
                clicked(type);
            }
        }
    }
}
