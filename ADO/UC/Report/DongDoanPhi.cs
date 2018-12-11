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
    public partial class DongDoanPhi : Form
    {
        private Doan_HoiPhiTemp temp;

        public DongDoanPhi(Doan_HoiPhiTemp temp)
        {
            InitializeComponent();

            this.temp = temp;
        }

        private void DongDoanPhi_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "../../UC/Report/DongDoanPhi.rdlc";

            List<ReportParameter> list = new List<ReportParameter>()
            {
                new ReportParameter("tenKhoa", temp.tenKhoa),
                new ReportParameter("tenKhoaHoc", temp.tenKhoaHoc),
                new ReportParameter("tenLop", temp.tenLop),
                new ReportParameter("ma_sv", temp.ma_sv),
                new ReportParameter("ho_ten", temp.ho_ten),
                new ReportParameter("ngay", DateTime.Now.Day.ToString()),
                new ReportParameter("soTien", temp.soTien.ToString()),
                new ReportParameter("thang", DateTime.Now.Month.ToString()),
                new ReportParameter("nam", DateTime.Now.Year.ToString()),
            };
            
            reportViewer1.LocalReport.SetParameters(list);
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
            //reportViewer1.RefreshReport();
        }
    }
}
