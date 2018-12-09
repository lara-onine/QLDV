using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModels
{
    public class SinhVienModel
    {
        public string ma_sv { get; set; }
        public string ho_ten { get; set; }
        public string dia_chi { get; set; }
        public string sdt { get; set; }
        public string lop { get; set; }
        public string nganh { get; set; }
        public string khoa { get; set; }
        public string khoa_hoc { get; set; }
    }
    
    public class SinhVienModelExtent : SinhVienModel
    {
        public bool da_dong_doan_phi { get; set; }
    }
}
