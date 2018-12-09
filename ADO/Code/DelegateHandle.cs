using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Code
{
    public class DelegateHandle
    {
        public delegate void InSuccessUpdate(object sender, DelegateHandler handler);
        public class DelegateHandler : EventArgs
        {
            public bool IsCompelete { get; set; }
        }

        public delegate void LogOut();
    }
}
