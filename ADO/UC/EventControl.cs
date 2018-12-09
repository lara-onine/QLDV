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
using DTO;
using ADO.Code;
using static ADO.Code.DelegateHandle;

namespace ADO.UC
{
    public partial class EventControl : UserControl
    {
        private User user;
        private Events events;

        public event LogOut logout = null;

        public EventControl(User user)
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLogout, "Đăng xuất");
            toolTip.SetToolTip(btnSetting, "Cài đặt");
            this.user = user;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            
        }

        private void EventDialog_eventSuccess()
        {
            dgvEvent.DataSource = EventsBus.Instance.DanhSachSuKien();
        }

        private void EventControl_Load(object sender, EventArgs e)
        {
            dgvEvent.DataSource = EventsBus.Instance.DanhSachSuKien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Dialog.EventDialog eventDialog = new Dialog.EventDialog(Extention.StatusDialog.IS_CREATE, user);
            eventDialog.eventSuccess += EventDialog_eventSuccess;
            eventDialog.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Dialog.EventDialog eventDialog = new Dialog.EventDialog(Extention.StatusDialog.IS_UPDATE, user, events);
            eventDialog.eventSuccess += EventDialog_eventSuccess;
            eventDialog.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Dialog.ConfirmDialog confirmDialog = new Dialog.ConfirmDialog(Extention.Confirm.IS_EVENTS, events);
            confirmDialog.deleteSuccess += ConfirmDialog_deleteSuccess;
            confirmDialog.ShowDialog();
        }

        private void ConfirmDialog_deleteSuccess()
        {
            dgvEvent.DataSource = EventsBus.Instance.DanhSachSuKien();
        }

        private void dgvEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow data = dgvEvent.Rows[e.RowIndex];
            var id = data.Cells[0].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            events = EventsBus.Instance.GetEvents(int.Parse(id));  
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
