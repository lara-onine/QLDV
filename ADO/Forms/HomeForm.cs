using ADO.Code;
using ADO.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace ADO.Forms
{
    public partial class HomeForm : Form
    {
        private HomeControl homeControl;
        private DashboardControl dashboardControl;
        private QLDVControl qlDoanVien;
        private QLHVControl qlHoiVien;
        private EventControl eventControl;
        private SettingControl settingControl;
        private UsersControl usersControl;
        private User user;

         List<ItemSidebarControl> items = new List<ItemSidebarControl>()
        {
            new ItemSidebarControl("Danh sách đoàn viên", ADO.Properties.Resources.List_View_Light_96px),
            new ItemSidebarControl("Đoàn phí", ADO.Properties.Resources.Paper_Money_Light_96px),
            new ItemSidebarControl("Quản lý sổ đoàn", ADO.Properties.Resources.Book_Litght_96px),
            new ItemSidebarControl("Chuyển sinh hoạt đoàn", ADO.Properties.Resources.Denied_Light_96px),
        };


        private bool isActive = false;

        public HomeForm(User user)
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClose, "Close");
            toolTip.SetToolTip(btnMinimize, "Minimize");           
            pictureBox2.Location = new Point(12, 0);

            dashboardControl = new DashboardControl();
            qlDoanVien = new QLDVControl(user);
            qlDoanVien.logout += Logout;

            qlHoiVien = new QLHVControl(user);
            qlHoiVien.logout += Logout;



            homeControl = new HomeControl();
            eventControl = new EventControl(user);
            eventControl.logout += Logout;
            settingControl = new SettingControl(user);
            settingControl.logout += Logout;
            usersControl = new UsersControl(user);
            usersControl.logout += Logout;

            //handler event
            homeControl.clicked += HomeControl_clicked;
            this.user = user;

            mainPanel.Controls.Add(homeControl);

        }

        private void Logout()
        {
            this.Close();
            new LoginForm().Show();
        }

        private void HomeControl_clicked(Extention.ItemList type)
        {
            mainPanel.Controls.Clear();

            isActive = true;

            switch (type)
            {
                case Extention.ItemList.Dashboard :
                    {
                        mainPanel.Controls.Add(new DashboardControl());
                        break;
                    }
                case Extention.ItemList.QLDV :
                    {
                        mainPanel.Controls.Add(qlDoanVien);
                        break;
                    }
                case Extention.ItemList.QLHV:
                    {
                        mainPanel.Controls.Add(qlHoiVien);
                        break;
                    }
                case Extention.ItemList.Event:
                    {
                        mainPanel.Controls.Add(eventControl);
                        break;
                    }
                case Extention.ItemList.Setting:
                    {
                        mainPanel.Controls.Add(settingControl);
                        break;
                    }
                case Extention.ItemList.User:
                    {
                        mainPanel.Controls.Add(usersControl);
                        break;
                    }
            }
            pictureBox2.Image = ADO.Properties.Resources.Left_96px;
            pictureBox2.Location = new Point(0, 0);
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(232, 17, 35);
            btnClose.Image = ADO.Properties.Resources.Delete_Light_96px;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.Image = ADO.Properties.Resources.Delete_96px;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(230, 230, 230);
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(homeControl);
                pictureBox2.Image = ADO.Properties.Resources.Logo_dark;
                pictureBox2.BackColor = Color.White;
                pictureBox2.Location = new Point(12, 0);
            }
            isActive = false;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            if (isActive)
            {
                pictureBox2.BackColor = Color.FromArgb(230, 230, 230);
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(pictureBox2, "Back");

            }
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if(isActive)
            {
                pictureBox2.BackColor = Color.White;
            }
        }

    }
}
