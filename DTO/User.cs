using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public string user_name { get; set; }
        public string pass { get; set; }
        public string full_name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int role_id { get; set; }
        public string role_name { get; set; }

    }
}
