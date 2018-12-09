using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADO.UC.HV;
using ADO.Code;
using DTO;
using static ADO.Code.DelegateHandle;

namespace ADO.UC
{
    public partial class QLHVControl : UserControl
    {
        List<ItemSidebarControl> items = new List<ItemSidebarControl>()
        {
            new ItemSidebarControl("Danh sách hội viên", ADO.Properties.Resources.List_View_Light_96px, Extention.HVItemList.QL_HOIVIEN),
            new ItemSidebarControl("Tìm kiếm hội viên", ADO.Properties.Resources.Search_Light_96px, Extention.HVItemList.TIM_KIEM),
            new ItemSidebarControl("Hội phí", ADO.Properties.Resources.Paper_Money_Light_96px,  Extention.HVItemList.HOI_PHI)
        };

        private User user = null;

        public event LogOut logout = null;

        public QLHVControl(User user)
        {
            InitializeComponent();
            this.user = user;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLogout, "Đăng xuất");
            for (int i = 0; i < items.Count; i++)
            {
                items[i].hoiClick += QLHVControl_hoiClick;
                sidebarFlowPanel.Controls.Add(items[i]);
            }
            lblNameUser.Text = user.full_name;
            btnRole.Text = user.role_name;

            foreach (ItemSidebarControl sd in items)
            {
                sd.hoiClick += QLHVControl_hoiClick;
            }

            DanhSachHoiVienUC us = new DanhSachHoiVienUC(user);
            us.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(us);
        }

        public QLHVControl()
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLogout, "Đăng xuất");

            lblNameUser.Text = user.full_name;
            btnRole.Text = user.role_name;

            for (int i = 0; i < items.Count; i++)
            {
                items[i].hoiClick += QLHVControl_hoiClick;
                sidebarFlowPanel.Controls.Add(items[i]);
            }

            foreach (ItemSidebarControl sd in items)
            {
                sd.hoiClick += QLHVControl_hoiClick;
            }

            DanhSachHoiVienUC us = new DanhSachHoiVienUC(user);
            us.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(us);
        }

        private void QLHVControl_hoiClick(Extention.HVItemList type)
        {
            mainPanel.Controls.Clear();
            switch (type)
            {
                case Extention.HVItemList.QL_HOIVIEN:
                    {
                        DanhSachHoiVienUC us = new DanhSachHoiVienUC(user);
                        us.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.HVItemList.TIM_KIEM:
                    {
                        TimKiemHoiVienUC us = new TimKiemHoiVienUC();
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.HVItemList.HOI_PHI:
                    {
                        HoiVienUC uc = new HoiVienUC(this.user);
                        mainPanel.Controls.Add(uc);
                    }
                    break;
                case Extention.HVItemList.QL_SODOAN:
                    break;
                default:
                    {
                        DanhSachHoiVienUC us = new DanhSachHoiVienUC(user);
                        us.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(us);
                    }
                    break;
            }
        }


        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(75, 136, 234);
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.Transparent;
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
