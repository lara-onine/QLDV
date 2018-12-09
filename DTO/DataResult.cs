using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DataResult
    {
        private bool disposed;

        public int successItem { get; set; }
        public int duplicateItem { get; set; }
        public int errorItem { get; set; }

        public DataResult()
        {
            disposed = false;
            successItem = 0;
            duplicateItem = 0;
            errorItem = 0;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose all used resources.
        /// </summary>
        /// <param name="disposing">Indicates the source call to dispose.</param>
        private void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                successItem = 0;
                duplicateItem = 0;
                errorItem = 0;
                this.disposed = true;
                ////Number of instance you want to dispose
            }
        }
    }
}
