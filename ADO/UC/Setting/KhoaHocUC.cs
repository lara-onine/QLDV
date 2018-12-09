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
using BUS;
using ADO.Dialog;
using ADO.Code;

namespace ADO.UC.Setting
{
    public partial class KhoaHocUC : UserControl
    {
        private User user;
        private KhoaHoc khoaHoc;

        public KhoaHocUC(User user)
        {
            InitializeComponent();
            dgvKhoaHoc.DataSource = KhoaHocBus.Instance.GetKhoaHocsModel();
            this.user = user;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaHocDialog khoaHocDialog = new KhoaHocDialog(user, Extention.StatusDialog.IS_CREATE);
            khoaHocDialog.successClick += KhoaHocDialog_successClick;
            khoaHocDialog.ShowDialog();
        }

        private void KhoaHocDialog_successClick()
        {
            dgvKhoaHoc.DataSource = KhoaHocBus.Instance.GetKhoaHocsModel();
        }

        private void dgvKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow data = dgvKhoaHoc.Rows[e.RowIndex];
            var id = data.Cells[0].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            khoaHoc = KhoaHocBus.Instance.GetKhoaHoc(int.Parse(id));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhoaHocDialog khoaHocDialog = new KhoaHocDialog(user, Extention.StatusDialog.IS_UPDATE, khoaHoc);
            khoaHocDialog.successClick += KhoaHocDialog_successClick;
            khoaHocDialog.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ConfirmDialog confirmDialog = new ConfirmDialog(Extention.Confirm.IS_KHOAHOC, khoaHoc);
            confirmDialog.deleteSuccess += ConfirmDialog_deleteSuccess;
            confirmDialog.ShowDialog();
        }

        private void ConfirmDialog_deleteSuccess()
        {
            dgvKhoaHoc.DataSource = KhoaHocBus.Instance.GetKhoaHocsModel();
        }
    }
}
