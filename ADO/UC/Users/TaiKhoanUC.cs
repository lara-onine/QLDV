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
using BUS;

namespace ADO.UC.Users
{
    public partial class TaiKhoanUC : UserControl
    {
        public delegate void Success(bool complete);
        public event Success success = null;
        private User user;
        public TaiKhoanUC(User user)
        {
            InitializeComponent();
            this.user = user;
            lblFullname.Text = user.full_name;
            lblName.Text = user.full_name;
            lblAddress.Text = user.address;
            lblPhone.Text = user.phone;
            lblRole.Text = user.role_name;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFullName.Text))
            {
                user.address = txtAddress.Text;
                user.full_name = txtFullName.Text;
                user.phone = txtPhone.Text;
                if (UserBus.Instance.SuaNguoiDung(this.user) > 0)
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
