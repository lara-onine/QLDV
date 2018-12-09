using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVien
    {
        public string ma_sv { get; set; }
        public string ho_ten { get; set; }
        public string pass { get; set; }
        public string dia_chi { get; set; }
        public string sdt { get; set; }
        public bool la_doanvien { get; set; }
        public bool la_hoivien { get; set; }
        public int ma_lop { get; set; }
        public int role_id { get; set; }
        public bool da_xoa { get; set; }
        public bool da_dong { get; set; }
    }
}
