using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModels
{
    public class LopModel
    {
        public int ma_lop { get; set; }
        public string ten_lop { get; set; }
        public string ten_nganh { get; set; }
        public string ten_khoa_hoc { get; set; }
        public string ten_khoa { get; set; }
        public string full_name { get; set; }
        public DateTime ngay_tao { get; set; }
    }
}
