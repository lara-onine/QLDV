using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ADO.Code
{
    public static class Extention
    {
        /// <summary>
        /// This use in home form
        /// </summary>
        public enum ItemList
        {
            Dashboard,
            QLDV,
            QLHV,
            Event,
            User,
            Setting
        }

        public enum TrangThai
        {
            la_doan_vien,
            la_hoi_vien
        }

        /// <summary>
        /// This use in usercontrol QLDV
        /// </summary>
        public enum DVItemList
        {
            QL_DOANVIEN,
            TIM_KIEM,
            DOAN_PHI,
            QL_SODOAN,
            DANH_GIA,
            CHUYEN_SINH_HOAT_DOAN
        }

        public enum HVItemList
        {
            QL_HOIVIEN,
            TIM_KIEM,
            HOI_PHI,
            QL_SODOAN
        }

        /// <summary>
        /// This use in usercontrol Setting
        /// </summary>
        public enum SettingItemList
        {
            DS_KHOAHOC,
            DS_KHOA,
            DS_NGANHHOC,
            DS_LOP
        }


        public static string MD5(this string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        /// <summary>
        /// Set selection to combobox by value
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="value"></param>
        public static void SelectedItemByValue(this ComboBox cbo, int value)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                var prop = cbo.Items[i].GetType().GetProperty(cbo.ValueMember);
                if (prop != null && int.Parse(prop.GetValue(cbo.Items[i], null).ToString()) == value)
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }
        }

        public enum UserItemList
        {
            DS_NGUOI_DUNG,
            TAI_KHOAN,
            MAT_KHAU
        }

        public enum StatusDialog
        {
            IS_CREATE,
            IS_UPDATE
        }

        public enum Confirm
        {
            IS_EVENTS,
            IS_KHOAHOC,
            IS_KHOA,
            IS_NGANH,
            IS_LOP,
            IS_DOANVIEN,
            IS_HOIVIEN
        }
    }

    public static class ExcelData
    {
        public static DataTable LoadDataTable(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            switch (fileExtension.ToLower())
            {
                case ".xlsx":
                    return ConvertExcelToDataTable(filePath, true);
                case ".xls":
                    return ConvertExcelToDataTable(filePath);
                case ".csv":
                    return ConvertCsvToDataTable(filePath);
                default:
                    return new DataTable();
            }

        }


        public static DataTable ConvertExcelToDataTable(string filePath, bool isXlsx = false)
        {
            FileStream stream = null;
            IExcelDataReader excelReader = null;
            DataTable dataTable = null;
            stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            excelReader = isXlsx ? ExcelReaderFactory.CreateOpenXmlReader(stream) : ExcelReaderFactory.CreateBinaryReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();
            if (result != null && result.Tables.Count > 0)
                dataTable = result.Tables[0];
            return dataTable;
        }

        public static DataTable ConvertCsvToDataTable(string filePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }
    }
}
