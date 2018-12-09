using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.UC.Report
{
    public partial class ChuyenSinhHoatDoan : Form
    {
        private SinhVien sv;
        public ChuyenSinhHoatDoan()
        {
            InitializeComponent();
        }

        public ChuyenSinhHoatDoan(SinhVien sv)
        {
            InitializeComponent();
            this.sv = sv;
        }

        private void ChuyenSinhHoatDoan_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "../../UC/Report/ChuyenSinhHoatDoan.rdlc";
            if (string.IsNullOrEmpty(txtTruongChuyen.Text))
            {
                MessageBox.Show("Bạn phải nhập vào tên trường cần chuyển đến.");
            }
            else
            {
                var time = dtpTime.Value;
                List<ReportParameter> list = new List<ReportParameter>()
            {
                new ReportParameter("ten_truong", txtTruongChuyen.Text),
                new ReportParameter("ten_sv", sv.ho_ten),
                new ReportParameter("thang", DateTime.Now.Month.ToString()),
                new ReportParameter("nam", DateTime.Now.Year.ToString()),
                new ReportParameter("thang_chuyen", time.Month.ToString()),
                new ReportParameter("nam_chuyen", time.Year.ToString()),
                new ReportParameter("ngay", DateTime.Now.Day.ToString())
            };

                reportViewer1.LocalReport.SetParameters(list);
                reportViewer1.RefreshReport();
            }
            
        }
    }
}
