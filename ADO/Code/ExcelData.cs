using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;

namespace ADO.Code
{
    class ExcelData
    {
        private static ExcelData instance;

        public static ExcelData Instance
        {
            get { if (instance == null) instance = new ExcelData(); return ExcelData.instance; }
            set { instance = value; }
        }

        public void ImportDatabaseExcel(string filePath)
        {
            Excel.Application app = new Excel.Application();
            //Mo tep
            Excel.Workbook workbook = app.Workbooks.Open(filePath);
            //Mo sheet
            Excel.Worksheet sheet = workbook.Sheets[1];
            Excel.Range range = sheet.UsedRange;
            //Doc du lieu
            int rows = range.Rows.Count;
            int cols = range.Columns.Count;
            //Doc dong tieu de
            for (int c = 1; c <= cols; c++)
            {
                string columnname = range.Cells[1, c].Value.ToString();
                ColumnHeader col = new ColumnHeader();
                col.Text = columnname;
                col.Width = 100;
            }
        }
    }
}
