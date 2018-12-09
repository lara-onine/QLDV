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
using ADO.Code;

namespace ADO.Dialog
{
    public partial class ConfirmDialog : Form
    {
        public delegate void DeleteSuccess();
        public event DeleteSuccess deleteSuccess;

        private Events events;
        private KhoaHoc khoaHoc;
        private Nganh nganh;
        private Lop lop;
        private Khoa khoa;
        private SinhVien sv;

        public Extention.Confirm type { get; set; }
        public ConfirmDialog(Extention.Confirm type, Events events)
        {
            InitializeComponent();

            this.type = type;

            this.events = events;
        }

        public ConfirmDialog(Extention.Confirm type, KhoaHoc khoaHoc)
        {
            InitializeComponent();

            this.type = type;

            this.khoaHoc = khoaHoc;
        }

        public ConfirmDialog(Extention.Confirm type, Nganh nganh)
        {
            InitializeComponent();

            this.type = type;

            this.nganh = nganh;
        }

        public ConfirmDialog(Extention.Confirm type, Lop lop)
        {
            InitializeComponent();

            this.type = type;

            this.lop = lop;
        }

        public ConfirmDialog(Extention.Confirm type, Khoa khoa)
        {
            InitializeComponent();

            this.type = type;

            this.khoa = khoa;
        }

        public ConfirmDialog(Extention.Confirm type, SinhVien sv)
        {
            InitializeComponent();

            this.type = type;

            this.sv = sv;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (type == Extention.Confirm.IS_EVENTS)
            {
                var result = EventsBus.Instance.XoaSuKien(events);
                if (result == 1)
                {
                    this.Close();
                    MessageBox.Show("Xóa sự kiện thành công", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    this.Close();
                    MessageBox.Show("Xóa sự kiện không thành công", "Lỗi", MessageBoxButtons.OK);
                    if (deleteSuccess != null)
                    {
                        deleteSuccess();
                    }
                }

            }
            else if (type == Extention.Confirm.IS_KHOAHOC)
            {
                var result = KhoaHocBus.Instance.XoaKhoaHoc(khoaHoc);
                if (result == -1)
                {
                    this.Close();
                    MessageBox.Show("Xóa khóa học không thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Xóa khóa học thành công", "Lỗi", MessageBoxButtons.OK);
                    if (deleteSuccess != null)
                    {
                        deleteSuccess();
                    }
                }
            }
            else if (type == Extention.Confirm.IS_NGANH)
            {
                var result = NganhBus.Instance.XoaNganh(nganh);
                if (result == -1)
                {
                    this.Close();
                    MessageBox.Show("Xóa ngành không thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Xóa ngành học thành công", "Thông báo", MessageBoxButtons.OK);
                    if (deleteSuccess != null)
                    {
                        deleteSuccess();
                    }
                }
            }
            else if (type == Extention.Confirm.IS_LOP)
            {
                var result = LopBus.Instance.XoaLop(lop);
                if (result == -1)
                {
                    this.Close();
                    MessageBox.Show("Xóa lớp không thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Xóa lớp thành công", "Thông báo", MessageBoxButtons.OK);
                    if (deleteSuccess != null)
                    {
                        deleteSuccess();
                    }
                }
            }
            else if (type == Extention.Confirm.IS_KHOA)
            {
                var result = KhoaBus.Instance.XoaKhoa(khoa);
                if (result == -1)
                {
                    this.Close();
                    MessageBox.Show("Xóa khoa không thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Xóa khoa thành công", "Thông báo", MessageBoxButtons.OK);
                    if (deleteSuccess != null)
                    {
                        deleteSuccess();
                    }
                }
            }
            else if (type == Extention.Confirm.IS_DOANVIEN)
            {
                var result = SinhVienBus.Instance.XoaSinhVien(sv.ma_sv);
                if (result == -1)
                {
                    this.Close();
                    MessageBox.Show("Xóa sinh viên không thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Xóa sinh viên thành công", "Thông báo", MessageBoxButtons.OK);
                    if (deleteSuccess != null)
                    {
                        deleteSuccess();
                    }
                }
            }
            else if (type == Extention.Confirm.IS_HOIVIEN)
            {
                var result = SinhVienBus.Instance.XoaSinhVien(sv.ma_sv);
                if (result == -1)
                {
                    this.Close();
                    MessageBox.Show("Xóa sinh viên không thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Xóa sinh viên thành công", "Thông báo", MessageBoxButtons.OK);
                    if (deleteSuccess != null)
                    {
                        deleteSuccess();
                    }
                }
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
