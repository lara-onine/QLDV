using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADO.Code;
using DTO;
using BUS;
using DTO.ViewModels;
using ADO.UC.Report;

namespace ADO.UC.DV
{
    public partial class TimKiemDoanVienUC : UserControl
    {

        private List<ItemCombobox> listItemKhoaHoc = new List<ItemCombobox>();
        private List<ItemCombobox> listItemKhoa = new List<ItemCombobox>();
        private List<ItemCombobox> listItemNganh = new List<ItemCombobox>();
        private List<ItemCombobox> listItemLop = new List<ItemCombobox>();

        private bool isChuyen = false;

        private List<SinhVienModel> list = new List<SinhVienModel>();

        private SinhVien sv;

        public TimKiemDoanVienUC(bool isChuyen = false)
        {
            InitializeComponent();

            list = SinhVienBus.Instance.GetSinhVienDVModels();
            dataGridView1.DataSource = list;

            this.isChuyen = isChuyen;
            if (isChuyen)
            {
                btnChuyenSH.Visible = true;
            }
            else
            {
                btnChuyenSH.Visible = false;
            }

            LoadCombobox();
            LoadData();
        }

        private void LoadData()
        {
            list.Clear();
            ItemCombobox khoa_hoc = cboKhoaHoc.SelectedItem as ItemCombobox;
            ItemCombobox khoa = cboKhoa.SelectedItem as ItemCombobox;
            ItemCombobox nganh = cboNganh.SelectedItem as ItemCombobox;
            ItemCombobox lop = cboLop.SelectedItem as ItemCombobox;
            if(khoa_hoc.ID == 0)
            {
                list = SinhVienBus.Instance.GetSinhVienDVModels();
            }
            else
            {
                if (khoa.ID == 0)
                {
                    list = SinhVienBus.Instance.GetSinhVienDVModels(khoa_hoc.ID);
                }
                else
                {
                    if (nganh.ID == 0)
                    {
                        list = SinhVienBus.Instance.GetSinhVienDVModels(khoa_hoc.ID, khoa.ID);
                    }
                    else
                    {
                        if(lop.ID == 0)
                        {
                            list = SinhVienBus.Instance.GetSinhVienDVModels(khoa_hoc.ID, khoa.ID, nganh.ID);
                        }
                        else
                        {
                            list = SinhVienBus.Instance.GetSinhVienDVModels(khoa_hoc.ID, khoa.ID, nganh.ID, lop.ID);
                        }
                    }
                }
            }
            dataGridView1.DataSource = list;
            dataGridView1.Refresh();
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


            listItemLop.Add(new ItemCombobox() { ID = 0, name = "==Chọn lớp==" });

            cboLop.DataSource = listItemLop;
            cboLop.DisplayMember = "name";
            cboLop.ValueMember = "ID";
        }

        #region Combobox Selection

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
            LoadData();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox() { ID = 0, name = "==Chọn Ngành==" });
            ItemCombobox item = cboKhoa.SelectedItem as ItemCombobox;
            if (item.ID != 0)
            {
                var nganh = NganhBus.Instance.GetNganhs(item.ID);
                foreach (var i in nganh)
                {
                    list.Add(new ItemCombobox() { ID = i.maNganh, name = i.tenNganh });
                }
            }
            cboNganh.DataSource = list;
            LoadData();
        }

        private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox() { ID = 0, name = "==Chọn lớp==" });
            ItemCombobox itemKhoaHoc = cboKhoaHoc.SelectedItem as ItemCombobox;
            ItemCombobox itemNganh = cboNganh.SelectedItem as ItemCombobox;

            if (itemKhoaHoc.ID != 0 && itemNganh.ID != 0)
            {
                var lop = LopBus.Instance.GetLops(itemNganh.ID, itemKhoaHoc.ID);
                foreach (var i in lop)
                {
                    list.Add(new ItemCombobox() { ID = i.maLop, name = i.tenLop });
                }
            }
            cboLop.DataSource = list;
            LoadData();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtSearch.Text;
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(text))
                {
                    LoadData();
                }
                else
                {
                    List<SinhVienModel> temp = list.Where(x => x.ma_sv.Contains(text) || x.ho_ten.Contains(text) || x.lop.Contains(text)
                || x.nganh.Contains(text) || x.khoa.Contains(text) || x.khoa_hoc.Contains(text)).ToList();

                    dataGridView1.DataSource = temp;
                }
                dataGridView1.Refresh();
            }
        }

        private void btnChuyenSH_Click(object sender, EventArgs e)
        {
            if(sv != null)
            {
                ChuyenSinhHoatDoan chuyen = new ChuyenSinhHoatDoan(sv);
                chuyen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn phải chọn một sinh viên");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                sv = SinhVienBus.Instance.GetSinhVienDV(row.Cells[0].Value.ToString());
            }
            catch
            {
                sv = null;
            }
        }
    }
}
