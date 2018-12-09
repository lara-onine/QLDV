using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModels
{
    public class Temp
    {
        public int maKhoaHoc { get; set; }
        public int maKhoa { get; set; }
        public int maNganh { get; set; }
        public int maLop { get; set; }
    }

    public class TempView
    {
        public string tenKhoaHoc { get; set; }
        public string tenKhoa { get; set; }
        public string tenNganh { get; set; }
        public string tenLop { get; set; }
    }
}
