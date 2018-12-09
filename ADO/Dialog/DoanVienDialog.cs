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
using BUS;
using ADO.Code;
using DTO.ViewModels;
using static ADO.Code.Extention;
using static ADO.Code.DelegateHandle;

namespace ADO.Dialog
{
    public partial class DoanVienDialog : Form
    {
        private List<ItemCombobox> listItemKhoaHoc = new List<ItemCombobox>();
        private List<ItemCombobox> listItemKhoa = new List<ItemCombobox>();
        private List<ItemCombobox> listItemNganh = new List<ItemCombobox>();
        private List<ItemCombobox> listItemLop = new List<ItemCombobox>();

        private string fileName = string.Empty;

        private DataTable t;
        private DataResult result;
        private int checkDone = 0;
        private delegate void DELEG();

        private bool isNewDV = true;
        private TrangThai trangthai;

        private SinhVien sinhVien;

        BackgroundWorker worker;

        public DoanVienDialog(string title, SinhVien sinhVien = null, bool isNew = true, TrangThai status = TrangThai.la_doan_vien)
        {
            InitializeComponent();

            result = new DataResult();
            t = new DataTable();
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;

            lblTitle.Text = title;

            this.isNewDV = isNew;
            this.trangthai = status;

            LoadCombobox();
            if (sinhVien != null)
            {
                this.sinhVien = sinhVien;
                txtHoTen.Text = sinhVien.ho_ten;
                txtDiaChi.Text = sinhVien.dia_chi;
                txtSdt.Text = sinhVien.sdt;
                txtMaSV.Text = sinhVien.ma_sv;

                //set selected combobox
                Temp temp = LopBus.Instance.GetTemp(sinhVien.ma_lop);
                cboKhoaHoc.SelectedItemByValue(temp.maKhoaHoc);
                cboKhoa.SelectedItemByValue(temp.maKhoa);
                cboNganh.SelectedItemByValue(temp.maNganh);
                cboLop.SelectedItemByValue(temp.maLop);
                btnThem.Text = "Lưu";
            }
        }

        

        private void LoadCombobox()
        {
            listItemKhoaHoc.Add(new ItemCombobox() { ID = 0, name = "==Chọn khóa học==" });
            var khoaHoc = KhoaHocBus.Instance.GetKhoaHocs();
            foreach(KhoaHoc kh in khoaHoc)
            {
                listItemKhoaHoc.Add(new ItemCombobox() { ID = kh.maKhoaHoc, name = kh.tenKhoaHoc });
            }

            cboKhoaHoc.DataSource = listItemKhoaHoc;
            cboKhoaHoc.DisplayMember = "name";
            cboKhoaHoc.ValueMember = "ID";
            cboKhoaHoc.SelectedIndex = 0;

            cboKhoaHoc1.DataSource = listItemKhoaHoc;
            cboKhoaHoc1.DisplayMember = "name";
            cboKhoaHoc1.ValueMember = "ID";

            listItemKhoa.Add(new ItemCombobox() { ID = 0, name = "==Chọn khoa==" });

            cboKhoa.DataSource = listItemKhoa;
            cboKhoa.DisplayMember = "name";
            cboKhoa.ValueMember = "ID";

            cboKhoa1.DataSource = listItemKhoa;
            cboKhoa1.DisplayMember = "name";
            cboKhoa1.ValueMember = "ID";

            listItemNganh.Add(new ItemCombobox() { ID = 0, name = "==Chọn Ngành==" });

            cboNganh.DataSource = listItemNganh;
            cboNganh.DisplayMember = "name";
            cboNganh.ValueMember = "ID";

            cboNganh1.DataSource = listItemNganh;
            cboNganh1.DisplayMember = "name";
            cboNganh1.ValueMember = "ID";

            listItemLop.Add(new ItemCombobox() { ID = 0, name = "==Chọn lớp==" });

            cboLop.DataSource = listItemLop;
            cboLop.DisplayMember = "name";
            cboLop.ValueMember = "ID";

            cboLop1.DataSource = listItemLop;
            cboLop1.DisplayMember = "name";
            cboLop1.ValueMember = "ID";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Combobox Selection

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox() { ID = 0, name = "==Chọn khoa==" });
            ItemCombobox item = cboKhoaHoc.SelectedItem as ItemCombobox;
            if(item.ID != 0)
            {
                var khoa = KhoaBus.Instance.GetKhoas(item.ID);
                foreach(var i in khoa)
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
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboKhoaHoc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox() { ID = 0, name = "==Chọn khoa==" });
            ItemCombobox item = cboKhoaHoc1.SelectedItem as ItemCombobox;
            if (item.ID != 0)
            {
                var khoa = KhoaBus.Instance.GetKhoas(item.ID);
                foreach (var i in khoa)
                {
                    list.Add(new ItemCombobox() { ID = i.maKhoa, name = i.tenKhoa });
                }
            }
            cboKhoa1.DataSource = list;
            cboKhoa1.DisplayMember = "name";
            cboKhoa1.ValueMember = "ID";
            cboKhoa1.Refresh();
        }

        private void cboKhoa1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox() { ID = 0, name = "==Chọn Ngành==" });
            ItemCombobox item = cboKhoa1.SelectedItem as ItemCombobox;
            if (item.ID != 0)
            {
                var nganh = NganhBus.Instance.GetNganhs(item.ID);
                foreach (var i in nganh)
                {
                    list.Add(new ItemCombobox() { ID = i.maNganh, name = i.tenNganh });
                }
            }
            cboNganh1.DataSource = list;
        }

        private void cboNganh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ItemCombobox> list = new List<ItemCombobox>();
            list.Add(new ItemCombobox() { ID = 0, name = "==Chọn lớp==" });
            ItemCombobox itemKhoaHoc = cboKhoaHoc.SelectedItem as ItemCombobox;
            ItemCombobox itemNganh = cboNganh1.SelectedItem as ItemCombobox;

            if (itemKhoaHoc.ID != 0 && itemNganh.ID != 0)
            {
                var lop = LopBus.Instance.GetLops(itemNganh.ID, itemKhoaHoc.ID);
                foreach (var i in lop)
                {
                    list.Add(new ItemCombobox() { ID = i.maLop, name = i.tenLop });
                }
            }
            cboLop1.DataSource = list;
        }

        private void cboLop1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFile.Text))
                {
                    MessageBox.Show("Bạn chưa chọn file");
                }
                else
                {
                    worker.RunWorkerAsync();
                }
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isNewDV)
            {
                if (!string.IsNullOrEmpty(txtMaSV.Text))
                {
                    if (!string.IsNullOrEmpty(txtHoTen.Text))
                    {
                        SinhVien sinhVien = new SinhVien();
                        sinhVien.ma_sv = txtMaSV.Text;
                        sinhVien.ho_ten = txtHoTen.Text;
                        sinhVien.sdt = txtSdt.Text;
                        sinhVien.dia_chi = txtDiaChi.Text;

                        ItemCombobox khoa_hoc = cboKhoaHoc.SelectedItem as ItemCombobox;
                        ItemCombobox khoa = cboKhoa.SelectedItem as ItemCombobox;
                        ItemCombobox nganh = cboNganh.SelectedItem as ItemCombobox;
                        ItemCombobox lop = cboLop.SelectedItem as ItemCombobox;

                        if (khoa_hoc.ID == 0)
                        {
                            MessageBox.Show("Bạn phải chọn khóa học");
                        }
                        else
                        {
                            if (khoa.ID == 0)
                            {
                                MessageBox.Show("Bạn phải chọn khoa");
                            }
                            else
                            {
                                if (nganh.ID == 0)
                                {
                                    MessageBox.Show("Bạn phải chọn ngành học");
                                }
                                else
                                {
                                    if (lop.ID == 0)
                                    {
                                        MessageBox.Show("Bạn phải chọn lớp");
                                    }
                                    else
                                    {
                                        sinhVien.ma_lop = lop.ID;
                                        sinhVien.pass = "1234";
                                        sinhVien.role_id = 3;
                                        sinhVien.da_xoa = false;
                                        if (trangthai == TrangThai.la_doan_vien)
                                        {
                                            sinhVien.la_doanvien = true;

                                        }
                                        else
                                        {
                                            sinhVien.la_doanvien = false;
                                        }
                                        if(trangthai == TrangThai.la_hoi_vien)
                                        {
                                            sinhVien.la_hoivien = true;
                                        }
                                        else
                                        {
                                            sinhVien.la_hoivien = false;
                                        }
                                        

                                        if (SinhVienBus.Instance.ThemSinhVien(sinhVien) > 0)
                                        {
                                            MessageBox.Show("Them thanh cong");
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Them thất bại");
                                        }

                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bạn phải nhập vào họ tên sinh viên");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải nhập vào mã sinh viên");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtMaSV.Text))
                {
                    if (!string.IsNullOrEmpty(txtHoTen.Text))
                    {
                        SinhVien sinhVien = new SinhVien();
                        sinhVien.ma_sv = txtMaSV.Text;
                        sinhVien.ho_ten = txtHoTen.Text;
                        sinhVien.sdt = txtSdt.Text;
                        sinhVien.dia_chi = txtDiaChi.Text;

                        ItemCombobox khoa_hoc = cboKhoaHoc.SelectedItem as ItemCombobox;
                        ItemCombobox khoa = cboKhoa.SelectedItem as ItemCombobox;
                        ItemCombobox nganh = cboNganh.SelectedItem as ItemCombobox;
                        ItemCombobox lop = cboLop.SelectedItem as ItemCombobox;

                        if (khoa_hoc.ID == 0)
                        {
                            MessageBox.Show("Bạn phải chọn khóa học");
                        }
                        else
                        {
                            if (khoa.ID == 0)
                            {
                                MessageBox.Show("Bạn phải chọn khoa");
                            }
                            else
                            {
                                if (nganh.ID == 0)
                                {
                                    MessageBox.Show("Bạn phải chọn ngành học");
                                }
                                else
                                {
                                    if (lop.ID == 0)
                                    {
                                        MessageBox.Show("Bạn phải chọn lớp");
                                    }
                                    else
                                    {
                                        sinhVien.ma_lop = lop.ID;

                                        if (SinhVienBus.Instance.SuaSinhVien(sinhVien) > 0)
                                        {
                                            MessageBox.Show("Sửa thông tin sinh viên thành công");
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Sửa thông tin sinh viên thất bại");
                                        }

                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bạn phải nhập vào họ tên sinh viên");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải nhập vào mã sinh viên");
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "Excel file(*.xls, *.xlsx) | *.xls; *.xlsx";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = true;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                    fileName = choofdlog.FileName;
                else
                    fileName = string.Empty;

                txtFile.Text = fileName;
                if (checkDone == 1)
                {
                    result.Dispose();
                    result = new DataResult();
                    lblThanhCong.Text = "0";
                    lblTrungLap.Text = "0";
                    lblThatBai.Text = "0";
                    checkDone = 0;
                }
            }
            catch { }
        }

        private void AsysLoad()
        {
            t = ExcelData.LoadDataTable(fileName);
            Update();
            checkDone++;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //AsysLoad();
            Delegate del = new DELEG(AsysLoad);
            this.Invoke(del);
        }

        private SinhVien CreateEntity(DataRow row, int maLop)
        {
            SinhVien sv = new SinhVien();
            sv.ma_sv = row[1].ToString();
            sv.ho_ten = row[2].ToString();
            sv.dia_chi = row[3].ToString();
            sv.sdt = row[4].ToString();
            sv.role_id = 3;
            sv.pass = "1234";
            sv.la_doanvien = true;
            sv.la_hoivien = true;
            sv.da_xoa = false;
            sv.ma_lop = maLop;
            return sv;
        }

        private void Update()
        {
            ItemCombobox khoa_hoc = cboKhoaHoc1.SelectedItem as ItemCombobox;
            ItemCombobox khoa = cboKhoa1.SelectedItem as ItemCombobox;
            ItemCombobox nganh = cboNganh1.SelectedItem as ItemCombobox;
            ItemCombobox lop = cboLop1.SelectedItem as ItemCombobox;

            int maLop = 0;

            if (khoa_hoc.ID == 0)
            {
                MessageBox.Show("Bạn phải chọn khóa học");
            }
            else
            {
                if (khoa.ID == 0)
                {
                    MessageBox.Show("Bạn phải chọn khoa");
                }
                else
                {
                    if (nganh.ID == 0)
                    {
                        MessageBox.Show("Bạn phải chọn ngành học");
                    }
                    else
                    {
                        if (lop.ID == 0)
                        {
                            MessageBox.Show("Bạn phải chọn lớp");
                        }
                        else
                        {
                            maLop = lop.ID;

                        }
                    }
                }
            }

            foreach (DataRow row in t.Rows)
            {
                result = SinhVienBus.Instance.ThemSinhVien(CreateEntity(row, maLop), result);
            }
            lblThanhCong.Text = result.successItem.ToString();
            lblTrungLap.Text = result.duplicateItem.ToString();
            lblThatBai.Text = result.errorItem.ToString();

            //SetLabel(result.SuccessfulChange, result.DuplicateRecord, result.RecordMissing);
            MessageBox.Show("Successfully.");
        }
    }
}
