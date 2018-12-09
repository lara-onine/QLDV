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
using ADO.Forms;
using ADO.Code;

namespace ADO
{
    public partial class LoginForm : Form
    {
        private UserBus bus = null;

        public LoginForm()
        {
            InitializeComponent();
            bus = new UserBus();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClose, "Close");
            toolTip.SetToolTip(btnMinimize, "Minimize");

        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(232, 17, 35);
            btnClose.Image = ADO.Properties.Resources.Delete_Light_96px;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.Image = ADO.Properties.Resources.Delete_96px;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(230, 230, 230); 
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Transparent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Login();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
        private void Login()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("hay nhap vao ten tai khoan");
            }
            else
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("hay nhap vao mat khau");
                }
                else
                {
                    User user = new User();
                    User res = new User();
                    user.user_name = txtUsername.Text.Trim();
                    user.pass = txtPassword.Text.MD5().Trim();
                    var result = bus.KiemTraTaiKhoan(user, out res);
                    if (result == -1)
                    {
                        MessageBox.Show("Tai khoan khonng ton tai");
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Sai mat khau");
                    }
                    else
                    {
                        new HomeForm(res).Show();
                        this.Hide();
                    }

                }
            }
        }
    }
}
