using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModels
{
    public class KhoaModel
    {
        public int ma_khoa { get; set; }
        public string ten_khoa { get; set; }
        public DateTime ngay_tao { get; set; }
        public string full_name { get; set; }
    }
}
