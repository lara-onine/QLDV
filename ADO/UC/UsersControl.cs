using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using ADO.Code;
using ADO.UC.Users;
using static ADO.Code.DelegateHandle;
using BUS;

namespace ADO.UC
{
    public partial class UsersControl : UserControl
    {
        private User user;

        public event LogOut logout = null;
        List<ItemSidebarControl> items = new List<ItemSidebarControl>()
        {
            new ItemSidebarControl("Danh sách người dùng", ADO.Properties.Resources.List_View_Light_96px, Extention.UserItemList.DS_NGUOI_DUNG),
            new ItemSidebarControl("Tài khoản", ADO.Properties.Resources.Search_Light_96px, Extention.UserItemList.TAI_KHOAN),
            new ItemSidebarControl("Mật khẩu", ADO.Properties.Resources.Paper_Money_Light_96px, Extention.UserItemList.MAT_KHAU),
        };

        public UsersControl(User user)
        {
            InitializeComponent();
            for (int i = 0; i < items.Count; i++)
            {
                sidebarFlowPanel.Controls.Add(items[i]);
                items[i].userClick += UsersControl_userClick;
            }
            this.user = user;
            lblFullname.Text = user.full_name;
            btnRole.Text = user.role_name;
            DanhSachUserUC us = new DanhSachUserUC(user);
            mainPanel.Controls.Add(us);
        }

        private void UsersControl_userClick(Extention.UserItemList type)
        {
            mainPanel.Controls.Clear();
            switch (type)
            {
                case Extention.UserItemList.DS_NGUOI_DUNG:
                    {
                        DanhSachUserUC us = new DanhSachUserUC(user);
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.UserItemList.TAI_KHOAN:
                    {
                        TaiKhoanUC us = new TaiKhoanUC(user);
                        us.success += Us_success;
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.UserItemList.MAT_KHAU:
                    {
                        MatKhauUC us = new MatKhauUC(user);
                        us.success += Us_success1;
                        mainPanel.Controls.Add(us);
                    }
                    break;
                default:
                    {
                        DanhSachUserUC us = new DanhSachUserUC(user);
                        mainPanel.Controls.Add(us);
                    }
                    break;
            }
        }

        private void Us_success1(bool complete)
        {
            MatKhauUC us = new MatKhauUC(user);
            us.success += Us_success1;
            mainPanel.Controls.Add(us);
        }

        private void Us_success(bool complete)
        {
            mainPanel.Controls.Clear();
            TaiKhoanUC us = new TaiKhoanUC(UserBus.Instance.GetUser(user.user_name));
            us.success += Us_success;
            mainPanel.Controls.Add(us);
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
