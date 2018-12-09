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
    public partial class LopUC : UserControl
    {
        private List<ItemCombobox> listItemKhoaHoc = new List<ItemCombobox>();
        private List<ItemCombobox> listItemKhoa = new List<ItemCombobox>();
        private List<ItemCombobox> listItemNganh = new List<ItemCombobox>();

        private User user;
        private Lop lop;

        public LopUC(User user)
        {
            InitializeComponent();
            dgvLop.DataSource = LopBus.Instance.GetLopModels();
            LoadCombobox();

            this.user = user;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void LoadCombobox()
        {
            listItemKhoaHoc.Add(new ItemCombobox() { ID = 0, name = "==Chọn khóa học==" });
            var khoaHoc = KhoaHocBus.Instance.GetKhoaHocs();
            foreach (KhoaHoc kh in khoaHoc)
            {
                listItemKhoaHoc.Add(new ItemCombobox() { ID = kh.maKhoaHoc, name = kh.tenKhoaHoc });
            }

            cboKhoaHoc.DataSource = listItemKhoaHoc;
            cboKhoaHoc.DisplayMember = "name";
            cboKhoaHoc.ValueMember = "ID";
            cboKhoaHoc.SelectedIndex = 0;

            listItemKhoa.Add(new ItemCombobox() { ID = 0, name = "==Chọn khoa==" });

            cboKhoa.DataSource = listItemKhoa;
            cboKhoa.DisplayMember = "name";
            cboKhoa.ValueMember = "ID";

            listItemNganh.Add(new ItemCombobox() { ID = 0, name = "==Chọn Ngành==" });

            cboNganh.DataSource = listItemNganh;
            cboNganh.DisplayMember = "name";
            cboNganh.ValueMember = "ID";
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox() { ID = 0, name = "==Chọn khoa==" });
            ItemCombobox item = cboKhoaHoc.SelectedItem as ItemCombobox;
            if (item.ID != 0)
            {
                var khoa = KhoaBus.Instance.GetKhoas(item.ID);
                foreach (var i in khoa)
                {
                    list.Add(new ItemCombobox() { ID = i.maKhoa, name = i.tenKhoa });
                }
            }
            cboKhoa.DataSource = list;
            cboKhoa.DisplayMember = "name";
            cboKhoa.ValueMember = "ID";
            cboKhoa.Refresh();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox() { ID = 0, name = "==Chọn Ngành==" });
            ItemCombobox item = cboKhoa.SelectedItem as ItemCombobox;
            ItemCombobox itemKhoaHoc = cboKhoaHoc.SelectedItem as ItemCombobox;
            if (item.ID != 0)
            {
                var nganh = NganhBus.Instance.GetNganhs(item.ID);
                foreach (var i in nganh)
                {
                    list.Add(new ItemCombobox() { ID = i.maNganh, name = i.tenNganh });
                }
            }
            cboNganh.DataSource = list;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ItemCombobox itemNganh = cboNganh.SelectedItem as ItemCombobox;
            ItemCombobox itemKhoaHoc = cboKhoaHoc.SelectedItem as ItemCombobox;
            ItemCombobox itemKhoa = cboKhoa.SelectedItem as ItemCombobox;
            if(itemKhoaHoc.ID != 0)
            {
                dgvLop.DataSource = LopBus.Instance.GetLopModels(itemKhoaHoc.ID);
            }
            if (itemKhoa.ID != 0 && itemKhoaHoc.ID != 0)
            {
                dgvLop.DataSource = LopBus.Instance.GetLopModels(itemKhoaHoc.ID, itemKhoa.ID);
            }
             if (itemNganh.ID != 0 && itemKhoa.ID != 0 && itemKhoaHoc.ID != 0)
            {
                dgvLop.DataSource = LopBus.Instance.GetLopModels(itemKhoaHoc.ID, itemKhoa.ID, itemNganh.ID);
            }
            else
            {
                dgvLop.DataSource = LopBus.Instance.GetLopModels();
            }
            dgvLop.Refresh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Dialog.LopDialog lopDialog = new Dialog.LopDialog(Extention.StatusDialog.IS_CREATE, user);
            lopDialog.clickSuccess += LopDialog_clickSuccess;
            lopDialog.ShowDialog();
        }

        private void LopDialog_clickSuccess()
        {
            dgvLop.DataSource = LopBus.Instance.GetLopModels();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Dialog.ConfirmDialog confirmDialog = new Dialog.ConfirmDialog(Extention.Confirm.IS_LOP, lop);
            confirmDialog.deleteSuccess += LopDialog_clickSuccess;
            confirmDialog.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Dialog.LopDialog lopDialog = new Dialog.LopDialog(Extention.StatusDialog.IS_UPDATE, user, lop);
            lopDialog.clickSuccess += LopDialog_clickSuccess;
            lopDialog.ShowDialog();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow data = dgvLop.Rows[e.RowIndex];
            var id = data.Cells[0].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            this.lop = LopBus.Instance.GetLop(int.Parse(id));
        }
    }
}
