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
    public partial class KhoaDialog : Form
    {
        private Khoa khoa;
        private User user;

        public delegate void SuccessClick();
        public event SuccessClick successClick = null;

        private Extention.StatusDialog type;

        private List<ItemCombobox> listItemKhoaHoc = new List<ItemCombobox>();

        public KhoaDialog(Extention.StatusDialog type, User user, Khoa khoa = null)
        {
            InitializeComponent();

            listItemKhoaHoc.Add(new ItemCombobox() { ID = 0, name = "Tất cả" });
            var listKhoaHoc = KhoaHocBus.Instance.GetKhoaHocs();
            foreach (var i in listKhoaHoc)
            {
                listItemKhoaHoc.Add(new ItemCombobox() { ID = i.maKhoaHoc, name = i.tenKhoaHoc });
            }
            
            this.type = type;

            this.user = user;

            if (type == Extention.StatusDialog.IS_CREATE)
            {
                lblTitle.Text = "Thêm khoa";
                btnThem.Text = "Thêm";
            }
            else
            {
                lblTitle.Text = "Sửa khoa";
                btnThem.Text = "Lưu";
                txtKhoa.Text = khoa.tenKhoa;
            }
            
            if ( khoa != null )
            {
                this.khoa = khoa;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if ( type == Extention.StatusDialog.IS_CREATE )
            {
                if (string.IsNullOrEmpty(txtKhoa.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khoa!", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    khoa = new Khoa();
                    khoa.tenKhoa = txtKhoa.Text;
                    khoa.userName = user.user_name;
                    var result = KhoaBus.Instance.ThemKhoa(khoa);

                    if (result == -1)
                    {
                        MessageBox.Show("Thêm khoa không thành công!", "Lỗi", MessageBoxButtons.OK);
                    }
                    
                    else
                    {
                        MessageBox.Show("Thêm khoa thành công!", "Thông báo", MessageBoxButtons.OK);
                        if (successClick != null)
                        {
                            successClick();
                        }
                    }
                }
            }
            else if (type == Extention.StatusDialog.IS_UPDATE)
            {
                if (string.IsNullOrEmpty(txtKhoa.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khoa!", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    khoa.tenKhoa = txtKhoa.Text;
                    var result = KhoaBus.Instance.SuaKhoa(khoa);

                    if (result == -1)
                    {
                        MessageBox.Show("Sửa khoa không thành công!", "Lỗi", MessageBoxButtons.OK);
                    }

                    else
                    {
                        MessageBox.Show("Sửa khoa thành công!", "Thông báo", MessageBoxButtons.OK);
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
