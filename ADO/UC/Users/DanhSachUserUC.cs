using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using ADO.Dialog;

namespace ADO.UC.Users
{
    public partial class DanhSachUserUC : UserControl
    {
        private User user = null;
        public DanhSachUserUC(User user)
        {
            InitializeComponent();
            this.user = user;
            LoadData();
        }

        private void LoadData()
        {
            dgvSinhVien.DataSource = UserBus.Instance.GetUsers();
            dgvSinhVien.Columns["role_id"].Visible = false;
            dgvSinhVien.Columns["pass"].Visible = false;
            dgvSinhVien.Refresh();

            if(user.role_id != 1)
            {
                btnEditRole.Visible = false;
                btnSua.Visible = false;
                btnThem.Visible = false;
                btnXoa.Visible = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (new AddUser(Code.Extention.StatusDialog.IS_CREATE, "Thêm mới người dùng", null).ShowDialog() == DialogResult.OK)
            {
                LoadData();
            };
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                user = UserBus.Instance.GetUser(row.Cells[0].Value.ToString());
            }
            catch { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(user == null)
            {
                MessageBox.Show("Bạn phải chọn một người dùng");
            }
            else
            {
                if (new AddUser(Code.Extention.StatusDialog.IS_UPDATE, "Sửa thông tin người dùng", user).ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                };
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if(UserBus.Instance.XoaNguoiDung(user.user_name) > 0)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn một người dùng");
            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Bạn phải chọn một người dùng");
            }
            else
            {
                if(new EditRole(user).ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
