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
using ADO.Code;
using DTO;

namespace ADO.UC.Setting
{
    public partial class NganhHocUC : UserControl
    {
        private List<ItemCombobox> listItemKhoa = new List<ItemCombobox>();
        private User user;
        private Nganh nganh;
        public NganhHocUC(User user)
        {
            InitializeComponent();
            this.user = user;
            dgvNganhHoc.DataSource = NganhBus.Instance.GetNganhHocModels();

            listItemKhoa.Add(new ItemCombobox() { ID = 0, name = "Tất cả" });
            var khoa = KhoaBus.Instance.GetKhoas();
            foreach (var i in khoa)
            {
                listItemKhoa.Add(new ItemCombobox() { ID = i.maKhoa, name = i.tenKhoa });
            }
            cboKhoa.DataSource = listItemKhoa;
            cboKhoa.DisplayMember = "name";
            cboKhoa.ValueMember = "ID";

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemCombobox item = cboKhoa.SelectedItem as ItemCombobox;
            if(item.ID == 0)
            {
                dgvNganhHoc.DataSource = NganhBus.Instance.GetNganhHocModels();
            }
            else
            {
                dgvNganhHoc.DataSource = NganhBus.Instance.GetNganhHocModels(item.ID);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Dialog.NganhDialog nganhDialog = new Dialog.NganhDialog(Extention.StatusDialog.IS_CREATE, user);
            nganhDialog.clickSuccess += NganhDialog_clickSuccess;
            nganhDialog.ShowDialog();
        }

        private void NganhDialog_clickSuccess()
        {
            dgvNganhHoc.DataSource = NganhBus.Instance.GetNganhHocModels();
        }

        private void dgvNganhHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow data = dgvNganhHoc.Rows[e.RowIndex];
            var id = data.Cells[0].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            nganh = NganhBus.Instance.GetNganh(int.Parse(id));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Dialog.NganhDialog nganhDialog = new Dialog.NganhDialog(Extention.StatusDialog.IS_UPDATE, user, nganh);
            nganhDialog.clickSuccess += NganhDialog_clickSuccess;
            nganhDialog.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Dialog.ConfirmDialog confirmDialog = new Dialog.ConfirmDialog(Extention.Confirm.IS_NGANH, nganh);
            confirmDialog.deleteSuccess += NganhDialog_clickSuccess;
            confirmDialog.ShowDialog();
        }
    }
}
