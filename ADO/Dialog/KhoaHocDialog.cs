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

namespace ADO.Dialog
{
    public partial class KhoaHocDialog : Form
    {
        private User user;
        private KhoaHoc khoaHoc;

        public delegate void SuccessClick();
        public event SuccessClick successClick = null;

        public Extention.StatusDialog type { get; set; }

        public KhoaHocDialog(User user,Extention.StatusDialog type, KhoaHoc khoaHoc = null)
        {
            InitializeComponent();
            this.user = user;
            this.type = type;
            if (khoaHoc != null)
            {
                this.khoaHoc = khoaHoc;
            }
            if (type == Extention.StatusDialog.IS_CREATE)
            {
                btnThem.Text = "Thêm";
                lblTitle.Text = "Thêm khóa học";
            }
            else
            {
                btnThem.Text = "Lưu";
                lblTitle.Text = "Sửa khóa học";
                txtKhoaHoc.Text = khoaHoc.tenKhoaHoc;
            }
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(type == Extention.StatusDialog.IS_CREATE)
            {
                if (string.IsNullOrEmpty(txtKhoaHoc.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khóa học", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    KhoaHoc kh = new KhoaHoc();
                    kh.tenKhoaHoc = txtKhoaHoc.Text;
                    kh.userName = user.user_name;
                    var result = KhoaHocBus.Instance.ThemKhoaHoc(kh);
                    if (result == -1)
                    {
                        MessageBox.Show("Thêm dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        this.Close();
                        if (successClick != null)
                        {
                            successClick();
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtKhoaHoc.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khóa học", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    khoaHoc.tenKhoaHoc = txtKhoaHoc.Text;
                    var result = KhoaHocBus.Instance.SuaKhoaHoc(khoaHoc);
                    if (result == -1)
                    {
                        MessageBox.Show("Sửa dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);
                        this.Close();
                        if (successClick != null)
                        {
                            successClick();
                        }
                    }
                }
            }
         
        }
    }
}
