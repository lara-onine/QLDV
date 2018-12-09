using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADO.Forms;
using DTO;
using BUS;
using DTO.ViewModels;
using ADO.UC.DV;
using ADO.Code;
using static ADO.Code.DelegateHandle;

namespace ADO.UC
{

    public partial class QLDVControl : UserControl
    {
        private User user;

        public event LogOut logout = null;
        List<ItemSidebarControl> items = new List<ItemSidebarControl>()
        {
            new ItemSidebarControl("Danh sách đoàn viên", ADO.Properties.Resources.List_View_Light_96px, Extention.DVItemList.QL_DOANVIEN),
            new ItemSidebarControl("Tìm kiếm đoàn viên", ADO.Properties.Resources.Search_Light_96px, Extention.DVItemList.TIM_KIEM),
            new ItemSidebarControl("Đoàn phí", ADO.Properties.Resources.Paper_Money_Light_96px, Extention.DVItemList.DOAN_PHI),
            new ItemSidebarControl("Chuyển sinh hoạt đoàn", ADO.Properties.Resources.Denied_Light_96px, Extention.DVItemList.CHUYEN_SINH_HOAT_DOAN),
        };

        public QLDVControl(User user)
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLogout, "Đăng xuất");
            
            for (int i = 0; i < items.Count; i++)
            {
                sidebarFlowPanel.Controls.Add(items[i]);
            }
            this.user = user;
            lblUsername.Text = user.full_name;
            btnRole.Text = user.role_name;
            DanhSachDoanVienUC us = new DanhSachDoanVienUC(user);
            mainPanel.Controls.Add(us);

            foreach (ItemSidebarControl sd in items)
            {
                sd.click += Sd_click;
            }

        }

        private void Sd_click(Extention.DVItemList type)
        {
            mainPanel.Controls.Clear();
            switch (type)
            {
                case Extention.DVItemList.QL_DOANVIEN:
                    {
                        DanhSachDoanVienUC us = new DanhSachDoanVienUC(user);
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.DVItemList.TIM_KIEM:
                    {
                        TimKiemDoanVienUC us = new TimKiemDoanVienUC();
                        mainPanel.Controls.Add(us);
                    }
                    break;
                case Extention.DVItemList.DOAN_PHI:
                    {
                        DoanVienUC hv_uc = new DoanVienUC(user);
                        hv_uc.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(hv_uc);
                    }
                    break;
                case Extention.DVItemList.QL_SODOAN:
                    break;
                case Extention.DVItemList.DANH_GIA:
                    break;
                case Extention.DVItemList.CHUYEN_SINH_HOAT_DOAN:
                    {
                        TimKiemDoanVienUC us = new TimKiemDoanVienUC(true);
                        mainPanel.Controls.Add(us);
                    }
                    break;
                default:
                    {
                        DanhSachDoanVienUC us = new DanhSachDoanVienUC(SinhVienBus.Instance.GetSinhVienModels(), user);
                        us.Dock = DockStyle.Fill;
                        mainPanel.Controls.Add(us);
                    }
                    break;
            }
        }


        #region Form Event
        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(75, 136, 234);
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.Transparent;
        }
        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if(logout != null)
            {
                logout();
            }
        }
    }
}
