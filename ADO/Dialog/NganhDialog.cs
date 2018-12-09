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
using ADO.Code;
using BUS;

namespace ADO.Dialog
{
    public partial class NganhDialog : Form
    {
        private User user;
        private List<ItemCombobox> listItemKhoa = new List<ItemCombobox>();
        private Nganh nganh;
        public Extention.StatusDialog type { get; set; }

        public delegate void ClickSuccess();
        public event ClickSuccess clickSuccess;

        public NganhDialog(Extention.StatusDialog type, User user, Nganh nganh = null)
        {
            InitializeComponent();

            this.user = user;

            this.type = type;

            if (nganh != null)
            {
                this.nganh = nganh;
            }

            listItemKhoa.Add(new ItemCombobox() { ID = 0, name = "==Chọn khoa==" });
            var khoa = KhoaBus.Instance.GetKhoas();
            foreach (Khoa kh in khoa)
            {
                listItemKhoa.Add(new ItemCombobox() { ID = kh.maKhoa, name = kh.tenKhoa });
            }
            cboKhoa.DataSource = listItemKhoa;
            cboKhoa.DisplayMember = "name";
            cboKhoa.ValueMember = "ID";
            cboKhoa.SelectedIndex = 0;

            if(type == Extention.StatusDialog.IS_CREATE)
            {
                btnThem.Text = "Thêm";
                lblTitle.Text = "Thêm ngành học";
            }
            else if (type == Extention.StatusDialog.IS_UPDATE)
            {
                btnThem.Text = "Lưu";
                lblTitle.Text = "Sửa ngành học";
                cboKhoa.SelectedItemByValue(nganh.maKhoa);
                txtNganh.Text = nganh.tenNganh;
            }
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ItemCombobox item = cboKhoa.SelectedItem as ItemCombobox;
            if (type == Extention.StatusDialog.IS_CREATE)
            {
                if (cboKhoa.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn khoa trực thuộc", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    if(string.IsNullOrEmpty(txtNganh.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên ngành học", "Lỗi", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Nganh nganhHoc = new Nganh();
                        nganhHoc.tenNganh = txtNganh.Text;
                        nganhHoc.maKhoa = item.ID;
                        nganhHoc.userName = user.user_name;

                        var result = NganhBus.Instance.ThemNganh(nganhHoc);

                        if (result == -1)
                        {
                            MessageBox.Show("Thêm ngành học không thành công", "Lỗi", MessageBoxButtons.OK);
                        }
                        else
                        {
                            this.Close();
                            MessageBox.Show("Thêm ngành học thành công", "Thông báo", MessageBoxButtons.OK);
                            if (clickSuccess != null)
                            {
                                clickSuccess();
                            }
                        }
                    }
                }
            }
            else if (type == Extention.StatusDialog.IS_UPDATE)
            {
                if (cboKhoa.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn khoa trực thuộc", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtNganh.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên ngành học", "Lỗi", MessageBoxButtons.OK);
                    }
                    else
                    {
                        nganh.tenNganh = txtNganh.Text;
                        nganh.maKhoa = item.ID;

                        var result = NganhBus.Instance.SuaNganh(nganh);

                        if (result == -1)
                        {
                            MessageBox.Show("Sửa ngành học không thành công", "Lỗi", MessageBoxButtons.OK);
                        }
                        else
                        {
                            this.Close();
                            MessageBox.Show("Sửa ngành học thành công", "Thông báo", MessageBoxButtons.OK);
                            if (clickSuccess != null)
                            {
                                clickSuccess();
                            }
                        }
                    }
                }
            }
        }
    }
}
