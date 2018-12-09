using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using ADO.UC.Items;
using DTO;
using DTO.ViewModels;
using static ADO.Code.DelegateHandle;

namespace ADO.UC
{
    public partial class DashboardControl : UserControl
    {
        List<ItemDashboardControl> items = null;
        private SuKienModel sukien = null;

        public event LogOut logout = null;

         public DashboardControl()
        {
            InitializeComponent();

            items = new List<ItemDashboardControl>()
        {
            new ItemDashboardControl(SinhVienBus.Instance.CountDoanVien().ToString()
                , "Số lượng đoàn viên", 55, 129, 204),
            new ItemDashboardControl(SinhVienBus.Instance.CountHoiVien().ToString()
                , "Số lượng hội viên", 251, 171, 79),
            new ItemDashboardControl(EventsBus.Instance.DanhSachSuKien() == null ? "0" : EventsBus.Instance.DanhSachSuKien().Count.ToString()
                , "Hoạt động", 84, 168, 92),
            new ItemDashboardControl(UserBus.Instance.GetUsers().Count.ToString()
                , "Người dùng", 230, 96, 80),

        };

            var events = EventsBus.Instance.DanhSachSuKien();
            if (events != null || events.Count > 0)
            {
                EventPanel.AutoScroll = true;
                EventPanel.HorizontalScroll.Visible = false;
                foreach (var item in events)
                {
                    EventPanel.Controls.Add(new ItemEvent(item.thoi_gian.Day.ToString(), item.thoi_gian.Month.ToString(),
                        item.thoi_gian.Year.ToString(),
                        item.tieu_de, item.noi_dung));
                }

                for (int i = 0; i < items.Count; i++)
                {
                    flowLayoutPanel1.Controls.Add(items[i]);
                }
                countDown();
                sukien = EventsBus.Instance.DanhSachSuKien().Where(x =>x.thoi_gian > DateTime.Now).OrderBy(x => x.thoi_gian).FirstOrDefault();
                lblNameEvent.Text = sukien.tieu_de;
                lblContent.Text = sukien.noi_dung;
                endTime = sukien.thoi_gian;
            }
            else
            {
                endTime = DateTime.Now;
            }
        }

        private Timer timer;
        DateTime endTime;

        private void countDown()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            TimeSpan timeSpan = endTime.Subtract(DateTime.Now);
            lblDay.Text = timeSpan.ToString(@"dd");
            lblHour.Text = timeSpan.ToString(@"hh");
            lblMinutes.Text = timeSpan.ToString(@"mm");
            lblSeconds.Text = timeSpan.ToString(@"ss");
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = endTime.Subtract(DateTime.Now);
            lblDay.Text = timeSpan.ToString(@"dd");
            lblHour.Text = timeSpan.ToString(@"hh");
            lblMinutes.Text = timeSpan.ToString(@"mm");
            lblSeconds.Text = timeSpan.ToString(@"ss");
            if (timeSpan.TotalSeconds <= 0)
            {
                timer.Stop();
                lblDay.Text = "00";
                lblHour.Text = "00";
                lblMinutes.Text = "00";
                lblSeconds.Text = "00";
            }
        }
    }
}
