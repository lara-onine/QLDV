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
using DTO;
using ADO.UC.Setting;
using static ADO.Code.DelegateHandle;

namespace ADO.UC
{
    public partial class SettingControl : UserControl
    {
        private User user;

        public event LogOut logout = null;
        List<ItemSidebarControl> items = new List<ItemSidebarControl>()
        {
            new ItemSidebarControl("Danh sách khóa học", ADO.Properties.Resources.List_View_Light_96px, Extention.SettingItemList.DS_KHOAHOC),
            new ItemSidebarControl("Danh sách khoa", ADO.Properties.Resources.Search_Light_96px, Extention.SettingItemList.DS_KHOA),
            new ItemSidebarControl("Danh sách ngành học", ADO.Properties.Resources.Paper_Money_Light_96px, Extention.SettingItemList.DS_NGANHHOC),
            new ItemSidebarControl("Danh sách lớp", ADO.Properties.Resources.Book_Litght_96px, Extention.SettingItemList.DS_LOP),
        };

        public SettingControl(User user)
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLogout, "Đăng xuất");
            for (int i = 0; i < items.Count; i++)
            {
                sidebarFlowPanel.Controls.Add(items[i]);
                items[i].settingClick += SettingControl_settingClick;
            }
            this.user = user;
            lblFullname.Text = user.full_name;
            btnRole.Text = user.role_name;
            KhoaHocUC us = new KhoaHocUC(user);
            mainPanel.Controls.Add(us);
        }

        private void SettingControl_settingClick(Extention.SettingItemList type)
        {
            mainPanel.Controls.Clear();
            switch (type)
            {
                case Extention.SettingItemList.DS_KHOAHOC:
                    {
                        KhoaHocUC us = new KhoaHocUC(user);
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.SettingItemList.DS_KHOA:
                    {
                        KhoaUC us = new KhoaUC(user);
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.SettingItemList.DS_NGANHHOC:
                    {
                        NganhHocUC us = new NganhHocUC(user);
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.SettingItemList.DS_LOP:
                    {
                        LopUC us = new LopUC(user);
                        mainPanel.Controls.Add(us);
                    }
                    break;
                default:
                    {
                        KhoaHocUC us = new KhoaHocUC(user);
                        mainPanel.Controls.Add(us);
                    }
                    break;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if(logout != null)
            {
                logout();
            }
        }
    }
}
