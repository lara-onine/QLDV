using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DTO.ViewModels;
using DAL;
using System.Data;

namespace BUS
{
    public class KhoaHocBus
    {
        private static KhoaHocBus instance;

        public static KhoaHocBus Instance
        {
            get { if (instance == null) instance = new KhoaHocBus(); return KhoaHocBus.instance; }
            private set { instance = value; }
        }

        public KhoaHoc GetKhoaHoc(int id)
        {
            KhoaHoc kh = null;
            string query = @"SELECT [ma_khoa_hoc]
      ,[ten_khoa_hoc]
  FROM [dbo].[KhoaHoc] Where [ma_khoa_hoc] = @makhoa";

            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id });
            if (dt.Rows.Count > 0)
            {
                kh = GetKhoaHoc(dt.Rows[0]);
            }

            return kh;
        }

        public List<KhoaHoc> GetKhoaHocs()
        {
            List<KhoaHoc> list = new List<KhoaHoc>();
            string query = @"SELECT [ma_khoa_hoc]
                                  ,[ten_khoa_hoc]
                            FROM [QLDoanVien].[dbo].[KhoaHoc]";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetKhoaHoc(dr));
                }
            }
            return list;
        }

        public List<KhoaHocModel> GetKhoaHocsModel()
        {
            List<KhoaHocModel> list = new List<KhoaHocModel>();

            string query = @"SELECT [ma_khoa_hoc]
                                  ,[ten_khoa_hoc]
                                  ,[ngay_tao]
	                              ,[User].full_name
                              FROM [QLDoanVien].[dbo].[KhoaHoc]
                              INNER JOIN [User] ON [User].user_name = KhoaHoc.user_name";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetKhoaHocModels(dr));
                }
            }
            return list;
        }

        public int ThemKhoaHoc(KhoaHoc kh)
        {
            string query = @"INSERT INTO [dbo].[KhoaHoc]
           ([ten_khoa_hoc], [user_name])
     VALUES
           ( @tenkhoahoc , @username )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { kh.tenKhoaHoc, kh.userName });
        }

        public int SuaKhoaHoc(KhoaHoc kh)
        {
            string query = @"UPDATE [dbo].[KhoaHoc]
                            SET [ten_khoa_hoc] = @tenkhoahoc 
                             WHERE [ma_khoa_hoc] = @makhoahoc";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { kh.tenKhoaHoc, kh.maKhoaHoc });
        }

        public int XoaKhoaHoc(KhoaHoc kh)
        {
            string query = @"DELETE FROM [dbo].[KhoaHoc]
                             WHERE [ma_khoa_hoc] = @makhoahoc ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { kh.maKhoaHoc });
        }

        private KhoaHoc GetKhoaHoc(DataRow dr)
        {
            KhoaHoc kh = new KhoaHoc();
            kh.maKhoaHoc = int.Parse(dr["ma_khoa_hoc"].ToString());
            kh.tenKhoaHoc = dr["ten_khoa_hoc"].ToString();
            return kh;
        }

        private KhoaHocModel GetKhoaHocModels(DataRow dr)
        {
            KhoaHocModel kh = new KhoaHocModel();
            kh.ma_khoa_hoc = int.Parse(dr["ma_khoa_hoc"].ToString());
            kh.ten_khoa_hoc = dr["ten_khoa_hoc"].ToString();
            kh.ngay_tao = DateTime.Parse(dr["ngay_tao"].ToString());
            kh.full_name = dr["full_name"].ToString();
            return kh;
        }
    }
}
