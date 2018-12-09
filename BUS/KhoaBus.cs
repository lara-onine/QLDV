using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.ViewModels;

namespace BUS
{
    public class KhoaBus
    {
        private static KhoaBus instance;

        public static KhoaBus Instance
        {
            get { if (instance == null) instance = new KhoaBus(); return KhoaBus.instance; }
            private set { instance = value; }
        }

        public Khoa GetKhoa(int id)
        {
            Khoa k = null;
            string query = @"SELECT [ma_khoa]
            ,[ten_khoa]
            FROM [QLDoanVien].[dbo].[Khoa] Where [ma_khoa] = @makhoa";

            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id });
            if (dt.Rows.Count > 0)
            {
                k = GetKhoa(dt.Rows[0]);
            }

            return k;
        }

        public List<Khoa> GetKhoas(int maKhoaHoc)
        {
            List<Khoa> list = new List<Khoa>();
            string query = @" SELECT Khoa.[ma_khoa]
      ,[ten_khoa]
  FROM [QLDoanVien].[dbo].[Khoa]";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetKhoa(dr));
                }
            }
            return list;
        }

        public List<KhoaModel> GetKhoaModels()
        {
            List<KhoaModel> list = new List<KhoaModel>();

            string query = @"SELECT [ma_khoa]
                              ,[ten_khoa]
                              ,[ngay_tao]
                              ,[User].[full_name]
                                FROM[QLDoanVien].[dbo].[Khoa]
                                INNER JOIN[User] ON Khoa.user_name = [User].user_name";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetKhoaModel(dr));
                }
            }
            return list;
        }

        public List<Khoa> GetKhoas()
        {
            List<Khoa> list = new List<Khoa>();
            string query = @"SELECT [ma_khoa]
      ,[ten_khoa]
  FROM [QLDoanVien].[dbo].[Khoa]";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetKhoa(dr));
                }
            }
            return list;
        }

        public int ThemKhoa(Khoa k)
        {
            string query = @"INSERT INTO [dbo].[Khoa]
           ([ten_khoa]
     VALUES
           ( @tenkhoa )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { k.tenKhoa, k.maKhoaHoc });
        }

        public int SuaKhoa(Khoa kh)
        {
            string query = @"UPDATE [dbo].[Khoa]
   SET [ten_khoa] = @tenkhoa  where [ma_khoa] = @makhoa";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { kh.tenKhoa, kh.maKhoa });
        }

        public int XoaKhoa(Khoa khoa)
        {
            string query = @"DELETE FROM [dbo].[Khoa]
      WHERE [ma_khoa] = @makhoa";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { khoa.maKhoa });
        }

        private Khoa GetKhoa(DataRow dr)
        {
            Khoa kh = new Khoa();
            kh.maKhoa = int.Parse(dr["ma_khoa"].ToString());
            kh.tenKhoa = dr["ten_khoa"].ToString();
            return kh;
        }

        private KhoaModel GetKhoaModel(DataRow dr)
        {
            KhoaModel kh = new KhoaModel();
            kh.ma_khoa = int.Parse(dr["ma_khoa"].ToString());
            kh.ten_khoa = dr["ten_khoa"].ToString();
            kh.ngay_tao = DateTime.Parse(dr["ngay_tao"].ToString());
            kh.full_name = dr["full_name"].ToString();
            return kh;
        }
    }
}
