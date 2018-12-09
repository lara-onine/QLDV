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
    public partial class AddUser : Form
    {
        public delegate void SuccessClick();
        public event SuccessClick success = null;
        private Extention.StatusDialog type;

        private List<ItemCombobox> listItemKhoaHoc = new List<ItemCombobox>();
        private User user;

        public AddUser(Extention.StatusDialog type, string name, User user = null)
        {
            InitializeComponent();
            this.type = type;
            lblTitle.Text = name;
            if(type == Extention.StatusDialog.IS_UPDATE && user != null)
            {
                txtUserName.Text = user.user_name;
                txtAddress.Text = user.address;
                txtFullName.Text = user.full_name;
                txtPhone.Text = user.phone;
                txtUserName.Enabled = false;
                this.user = user;
            }
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (type == Extention.StatusDialog.IS_CREATE)
            {
                if (!string.IsNullOrEmpty(txtUserName.Text))
                {
                    if (!string.IsNullOrEmpty(txtFullName.Text))
                    {
                        User user = new User();
                        user.address = txtAddress.Text;
                        user.full_name = txtFullName.Text;
                        user.pass = "1234".MD5();
                        user.user_name = txtUserName.Text;
                        user.phone = txtPhone.Text;
                        user.role_id = 2;
                        if(UserBus.Instance.ThemNguoiDung(user) > 0)
                        {
                            if(success != null)
                            {
                                this.Close();
                                success();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đã xảy ra lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn phải nhập vào họ tên");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải nhập vào tên người dùng");
                }
            }
            else if (type == Extention.StatusDialog.IS_UPDATE)
            {
                if (!string.IsNullOrEmpty(txtFullName.Text))
                {
                    user.address = txtAddress.Text;
                    user.full_name = txtFullName.Text;
                    user.phone = txtPhone.Text;
                    if (UserBus.Instance.SuaNguoiDung(user) > 0)
                    {
                        if (success != null)
                        {
                            this.Close();
                            success();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải nhập vào họ tên");
                }
            }
        }
    }
}
