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
using DTO.ViewModels;
using ADO.Dialog;
using ADO.Code;
using BUS;

namespace ADO.UC.HV
{
    public partial class DanhSachHoiVienUC : UserControl
    {
        private SinhVien sv;
        private User user;

        public DanhSachHoiVienUC(User user)
        {
            InitializeComponent();
            LoadData();
            this.user = user;
            if(user.role_id != 1)
            {
                btnSuaDV.Visible = false;
                btnThemDV.Visible = false;
                btnXoaDV.Visible = false;
            }
        }

        void LoadData()
        {
            dataGridView1.DataSource = SinhVienBus.Instance.GetSinhVienModels();
            dataGridView1.Refresh();
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            DoanVienDialog dv = new DoanVienDialog("Thêm mới sinh viên");
            if (dv.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string masv = row.Cells[0].Value.ToString();
                sv = SinhVienBus.Instance.GetSinhVienHV(masv);
            }
            catch { }

        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            if (sv != null)
            {
                DoanVienDialog dv = new DoanVienDialog("Sửa thông tin sinh viên", sv, false);
                if (dv.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sinh viên");
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (sv != null)
            {
                ConfirmDialog confirmDialog = new ConfirmDialog(Extention.Confirm.IS_DOANVIEN, sv);
                confirmDialog.deleteSuccess += ConfirmDialog_deleteSuccess; ;
                confirmDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn phải chọn một sinh viên");
            }
        }

        private void ConfirmDialog_deleteSuccess()
        {
            LoadData();
        }
    }
}
