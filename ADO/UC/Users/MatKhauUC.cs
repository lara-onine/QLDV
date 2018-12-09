using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using ADO.Code;
using BUS;

namespace ADO.UC.Users
{
    public partial class MatKhauUC : UserControl
    {
        private User user;

        public delegate void Success(bool complete);
        public event Success success = null;

        public MatKhauUC(User user)
        {
            InitializeComponent();
            this.user = user;
            lblFullname.Text = user.full_name;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOldPass.Text))
            {
                if (!string.IsNullOrEmpty(txtNewPass.Text))
                {
                    if (!string.IsNullOrEmpty(txtRePass.Text))
                    {
                        if (!txtOldPass.Text.MD5().Equals(user.pass))
                        {
                            MessageBox.Show("Mật khẩu không chính xác");
                        }
                        else
                        {
                            if (!txtNewPass.Text.Equals(txtRePass.Text))
                            {
                                MessageBox.Show("Mật khẩu nhập lại không khớp nhau");
                            }
                            else
                            {
                                if (UserBus.Instance.DoiMatKhau(user.user_name, txtNewPass.Text.MD5()) > 0)
                                {
                                    if (success != null)
                                    {
                                        success(true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
