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
    public class NganhBus
    {
        private static NganhBus instance;

        public static NganhBus Instance
        {
            get { if (instance == null) instance = new NganhBus(); return NganhBus.instance; }
            private set { instance = value; }
        }

        public Nganh GetNganh(int id)
        {
            Nganh ng = null;
            string query = @"SELECT [ma_nganh]
      ,[ten_nganh]
      ,[ma_khoa]
  FROM [QLDoanVien].[dbo].[Nganh] Where [ma_nganh] = @manganh";

            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id });
            if (dt.Rows.Count > 0)
            {
                ng = GetNganh(dt.Rows[0]);
            }

            return ng;
        }

        public List<Nganh> GetNganhs(int maKhoa)
        {
            List<Nganh> list = new List<Nganh>();
            string query = @"SELECT [ma_nganh]
      ,[ten_nganh]
      ,Nganh.[ma_khoa]
  FROM [QLDoanVien].[dbo].[Nganh]
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  where Nganh.[ma_khoa] = @makhoa";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoa});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetNganh(dr));
                }
            }
            return list;
        }

        public List<Nganh> GetNganhs()
        {
            List<Nganh> list = new List<Nganh>();
            string query = @"SELECT [ma_nganh]
      ,[ten_nganh]
      ,[ma_khoa]
  FROM [QLDoanVien].[dbo].[Nganh]";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetNganh(dr));
                }
            }
            return list;
        }

        public List<NganhHocModel> GetNganhHocModels()
        {
            List<NganhHocModel> list = new List<NganhHocModel>();

            string query = @"SELECT TOP (1000) [ma_nganh]
                              ,[ten_nganh]
                              ,[full_name]
                              ,[Nganh].[ngay_tao]
	                          ,[ten_khoa]
                          FROM [QLDoanVien].[dbo].[Nganh]
                          INNER JOIN [User] ON [User].user_name = [Nganh].user_name
                          INNER JOIN [Khoa] ON [Khoa].ma_khoa = [Nganh].ma_khoa";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetNganhHocModel(dr));
                }
            }
            return list;
        }

        public List<NganhHocModel> GetNganhHocModels(int maKhoa)
        {
            List<NganhHocModel> list = new List<NganhHocModel>();

            string query = @"SELECT TOP (1000) [ma_nganh]
                                  ,[ten_nganh]
                                  ,[full_name]
                                  ,[Nganh].[ngay_tao]
	                              ,[ten_khoa]
                              FROM [QLDoanVien].[dbo].[Nganh]
                              INNER JOIN [User] ON [User].user_name = [Nganh].user_name
                              INNER JOIN [Khoa] ON [Khoa].ma_khoa = [Nganh].ma_khoa
                              WHERE [Khoa].ma_khoa = @maKhoa ";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoa });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetNganhHocModel(dr));
                }
            }
            return list;
        }

        public int ThemNganh(Nganh ng)
        {
            string query = @"INSERT INTO [dbo].[Nganh]
           ([ten_nganh]
           ,[ma_khoa])
     VALUES
           ( @tennganh 
           , @makhoa )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { ng.tenNganh, ng.maKhoa });
        }

        public int SuaNganh(Nganh ng)
        {
            string query = @"UPDATE [dbo].[Nganh]
   SET [ten_nganh] = @tennganh 
      ,[ma_khoa] = @makhoa 
 WHERE [ma_nganh] = @manganh";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { ng.tenNganh, ng.maKhoa });
        }

        public int XoaNganh(Nganh nganh)
        {
            string query = @"DELETE FROM [dbo].[Nganh]
      WHERE [ma_nganh] = @manganh";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { nganh.maNganh });
        }

        private Nganh GetNganh(DataRow dr)
        {
            Nganh ng = new Nganh();
            ng.maNganh = int.Parse(dr["ma_nganh"].ToString());
            ng.maKhoa = int.Parse(dr["ma_khoa"].ToString());
            ng.tenNganh = dr["ten_nganh"].ToString();
            return ng;
        }

        private NganhHocModel GetNganhHocModel(DataRow dr)
        {
            NganhHocModel ng = new NganhHocModel();
            ng.ma_nganh = int.Parse(dr["ma_nganh"].ToString());
            ng.ten_khoa = dr["ten_khoa"].ToString();
            ng.ngay_tao = DateTime.Parse(dr["ngay_tao"].ToString());
            ng.ten_nganh = dr["ten_nganh"].ToString();
            ng.full_name = dr["full_name"].ToString();
            return ng;
        }
    }
}
