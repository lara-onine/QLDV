using ADO.Code;
using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.Dialog
{
    public partial class LopDialog : Form
    {
        private List<ItemCombobox> listItemKhoaHoc = new List<ItemCombobox>();
        private List<ItemCombobox> listItemKhoa = new List<ItemCombobox>();
        private List<ItemCombobox> listItemNganh = new List<ItemCombobox>();

        public delegate void ClickSuccess();
        public event ClickSuccess clickSuccess;

        public Extention.StatusDialog type { get; set; }
        private Lop lop;
        private User user;
        public LopDialog(Extention.StatusDialog type, User user, Lop lop = null)
        {
            InitializeComponent();
            LoadCombobox();

            this.user = user;

            this.type = type;

            if (lop != null)
            {
                this.lop = lop;
            }

            if (type == Extention.StatusDialog.IS_CREATE)
            {
                btnThem.Text = "Thêm";
                lblTitle.Text = "Thêm lớp học";
            }
            else if (type == Extention.StatusDialog.IS_UPDATE)
            {
                btnThem.Text = "Lưu";
                lblTitle.Text = "Sửa khóa học";
                txtLop.Text = lop.tenLop;
                cboKhoaHoc.SelectedItemByValue(lop.maKhoaHoc);
                Nganh nganh = new Nganh();
                nganh = NganhBus.Instance.GetNganh(lop.maNganh);
                cboKhoa.SelectedItemByValue(nganh.maKhoa);
                cboNganh.SelectedItemByValue(lop.maNganh);
            }
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ItemCombobox itemKhoaHoc = cboKhoaHoc.SelectedItem as ItemCombobox;
            ItemCombobox itemKhoa = cboKhoa.SelectedItem as ItemCombobox;
            ItemCombobox itemNganh = cboNganh.SelectedItem as ItemCombobox;

            if (type == Extention.StatusDialog.IS_CREATE)
            {
                if (itemKhoaHoc.ID == 0)
                {
                    MessageBox.Show("Vui lòng chọn khóa học", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    if (itemKhoa.ID == 0)
                    {
                        MessageBox.Show("Vui lòng chọn khoa", "Lỗi", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (itemNganh.ID == 0)
                        {
                            MessageBox.Show("Vui lòng chọn ngành học", "Lỗi", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtLop.Text))
                            {
                                MessageBox.Show("Vui lòng nhập tên lớp", "Lớp", MessageBoxButtons.OK);
                            }
                            else
                            {
                                try
                                {
                                    lop = new Lop();
                                    lop.maKhoaHoc = itemKhoaHoc.ID;
                                    lop.maNganh = itemNganh.ID;
                                    lop.tenLop = txtLop.Text;
                                    lop.userName = user.user_name;

                                    var result = LopBus.Instance.ThemLop(lop);

                                    if (result == -1)
                                    {
                                        this.Close();
                                        MessageBox.Show("Thêm lớp không thành công", "Lỗi", MessageBoxButtons.OK);
                                    }
                                    else
                                    {
                                        this.Close();
                                        MessageBox.Show("Thêm lớp thành công", "Thông báo", MessageBoxButtons.OK);
                                        if (clickSuccess != null)
                                        {
                                            clickSuccess();
                                        }
                                    }
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show("Bạn nhập sai định dạng. Vui lòng thử lại", "Lỗi", MessageBoxButtons.OK);
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                if (itemKhoaHoc.ID == 0)
                {
                    MessageBox.Show("Vui lòng chọn khóa học", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    if (itemKhoa.ID == 0)
                    {
                        MessageBox.Show("Vui lòng chọn khoa", "Lỗi", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (itemNganh.ID == 0)
                        {
                            MessageBox.Show("Vui lòng chọn ngành học", "Lỗi", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtLop.Text))
                            {
                                MessageBox.Show("Vui lòng nhập tên lớp", "Lớp", MessageBoxButtons.OK);
                            }
                            else
                            {
                                try
                                {
                                    lop.maKhoaHoc = itemKhoaHoc.ID;
                                    lop.maNganh = itemNganh.ID;
                                    lop.tenLop = txtLop.Text;

                                    var result = LopBus.Instance.SuaLop(lop);

                                    if (result == -1)
                                    {
                                        this.Close();
                                        MessageBox.Show("Sửa lớp không thành công", "Lỗi", MessageBoxButtons.OK);
                                    }
                                    else
                                    {
                                        this.Close();
                                        MessageBox.Show("Sửa lớp thành công", "Thông báo", MessageBoxButtons.OK);
                                        if (clickSuccess != null)
                                        {
                                            clickSuccess();
                                        }
                                    }
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message, "Lỗi", MessageBoxButtons.OK);
                                }
                            }

                        }
                    }
                }
            }
        }
    }


}
