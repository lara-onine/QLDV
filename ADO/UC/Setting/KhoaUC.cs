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
using ADO.Dialog;
using ADO.Code;
using DTO;

namespace ADO.UC.Setting
{
    public partial class KhoaUC : UserControl
    {
        private User user;
        private Khoa khoa;

        public KhoaUC(User user)
        {
            InitializeComponent();

            this.user = user;

            dgvKhoa.DataSource = KhoaBus.Instance.GetKhoaModels();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoaDialog khoaDialog = new KhoaDialog(Extention.StatusDialog.IS_CREATE ,user);
            khoaDialog.successClick += KhoaDialog_successClick;
            khoaDialog.ShowDialog();
        }

        private void KhoaDialog_successClick()
        {
            dgvKhoa.DataSource = KhoaBus.Instance.GetKhoaModels();
        }

        private void btnKhoaKhoaHoc_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhoaDialog khoaDialog = new KhoaDialog(Extention.StatusDialog.IS_UPDATE, user, khoa);
            khoaDialog.successClick += KhoaDialog_successClick;
            khoaDialog.ShowDialog();
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow data = dgvKhoa.Rows[e.RowIndex];
            var id = data.Cells[0].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            this.khoa = KhoaBus.Instance.GetKhoa(int.Parse(id));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ConfirmDialog confirmDialog = new ConfirmDialog(Extention.Confirm.IS_KHOA, khoa);
            confirmDialog.deleteSuccess += KhoaDialog_successClick;
            confirmDialog.ShowDialog();
        }
    }
}
