using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DAL;
using System.Data;
using DTO.ViewModels;

namespace BUS
{
    public class LopBus
    {
        private static LopBus instance;

        public static LopBus Instance
        {
            get { if (instance == null) instance = new LopBus(); return LopBus.instance; }
            private set { instance = value; }
        }

        public Lop GetLop(int id)
        {
            Lop lop = null;
            string query = @"SELECT [ma_lop]
      ,[ten_lop]
      ,[ma_nganh]
      ,[ma_khoa_hoc]
  FROM [QLDoanVien].[dbo].[Lop] Where [ma_lop] = @malop";

            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id });
            if (dt.Rows.Count > 0)
            {
                lop = GetLop(dt.Rows[0]);
            }

            return lop;
        }

        public Temp GetTemp(int maLop)
        {
            string query = @"SELECT [ma_lop]
      ,[ten_lop]
      ,Lop.[ma_nganh]
      ,Lop.[ma_khoa_hoc]
      ,Khoa.ma_khoa
      ,Nganh.ten_nganh
	  ,Khoa.ten_khoa
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[Lop]
  inner join Nganh on Nganh.ma_nganh = Lop.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on KhoaHoc.ma_khoa_hoc = Lop.ma_khoa_hoc
   where ma_lop = @ma_lop";

            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maLop });
            if (dt.Rows.Count > 0)
            {
                return GetTemp(dt.Rows[0]);
            }
            return null;
        }

        public TempView GetTempView(int maLop)
        {
            string query = @"SELECT [ma_lop]
      ,[ten_lop]
      ,Lop.[ma_nganh]
      ,Lop.[ma_khoa_hoc]
      ,Khoa.ma_khoa
      ,Nganh.ten_nganh
	  ,Khoa.ten_khoa
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[Lop]
  inner join Nganh on Nganh.ma_nganh = Lop.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on KhoaHoc.ma_khoa_hoc = Lop.ma_khoa_hoc
   where ma_lop = @ma_lop";

            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maLop });
            if (dt.Rows.Count > 0)
            {
                return GetTempView(dt.Rows[0]);
            }
            return null;
        }

        private Temp GetTemp(DataRow dr)
        {
            Temp t = new Temp();
            t.maKhoaHoc = int.Parse(dr["ma_khoa_hoc"].ToString());
            t.maKhoa = int.Parse(dr["ma_khoa"].ToString());
            t.maNganh = int.Parse(dr["ma_nganh"].ToString());
            t.maLop = int.Parse(dr["ma_lop"].ToString());
            return t;
        }

        private TempView GetTempView(DataRow dr)
        {
            TempView t = new TempView();
            t.tenKhoaHoc = dr["ten_khoa_hoc"].ToString();
            t.tenKhoa = dr["ten_khoa"].ToString();
            t.tenNganh = dr["ten_nganh"].ToString();
            t.tenLop = dr["ten_lop"].ToString();
            return t;
        }

            public List<Lop> GetLops(int maNganh, int maKhoaHoc)
        {
            List<Lop> list = new List<Lop>();
            string query = @"SELECT Lop.[ma_lop]
      ,[ten_lop]
      ,Lop.[ma_nganh]
	  ,KhoaHoc.ma_khoa_hoc
  FROM [QLDoanVien].[dbo].[Lop]
  inner join Nganh on Nganh.ma_nganh = Lop.ma_nganh
  inner join Khoa on Nganh.ma_khoa = Khoa.ma_khoa
  inner join KhoaHoc on KhoaHoc.ma_khoa_hoc = Lop.ma_khoa_hoc
  where Lop.ma_khoa_hoc = @makhoahoc and Lop.ma_nganh = @manganh";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maNganh });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetLop(dr));
                }
            }
            return list;
        }

        public List<Lop> GetLops()
        {
            List<Lop> list = new List<Lop>();
            string query = @"SELECT [ma_lop]
      ,[ten_lop]
      ,[ma_nganh]
      ,[ma_khoa]
  FROM [QLDoanVien].[dbo].[Lop]";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetLop(dr));
                }
            }
            return list;
        }

        public List<LopModel> GetLopModels()
        {
            List<LopModel> list = new List<LopModel>();
            string query = @"SELECT [ma_lop]
		                    ,[ten_lop]
		                    ,[Nganh].ten_nganh
		                    ,[KhoaHoc].ten_khoa_hoc
		                    ,[Khoa].ten_khoa
		                    ,[User].full_name
		                    ,[Lop].[ngay_tao]
	                    FROM [QLDoanVien].[dbo].[Lop]
	                    INNER JOIN [KhoaHoc] ON KhoaHoc.ma_khoa_hoc = [Lop].ma_khoa_hoc
	                    INNER JOIN [Nganh] ON [Nganh].ma_nganh = Lop.[ma_nganh]
	                    INNER JOIN [Khoa] ON Nganh.ma_khoa = Khoa.ma_khoa
	                    INNER JOIN [User] ON [User].user_name = [Lop].user_name";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetLopModel(dr));
                }
            }
            return list;
        }

        public List<LopModel> GetLopModels(int maKhoaHoc)
        {
            List<LopModel> list = new List<LopModel>();
            string query = @"SELECT TOP (1000) [ma_lop]
		                    ,[ten_lop]
		                    ,[Nganh].ten_nganh
		                    ,[KhoaHoc].ten_khoa_hoc
		                    ,[Khoa].ten_khoa
		                    ,[User].full_name
		                    ,[Lop].[ngay_tao]
	                    FROM [QLDoanVien].[dbo].[Lop]
	                    INNER JOIN [KhoaHoc] ON KhoaHoc.ma_khoa_hoc = [Lop].ma_khoa_hoc
	                    INNER JOIN [Nganh] ON [Nganh].ma_nganh = Lop.[ma_nganh]
	                    INNER JOIN [Khoa] ON Nganh.ma_khoa = Khoa.ma_khoa
	                    INNER JOIN [User] ON [User].user_name = [Lop].user_name
	                    WHERE KhoaHoc.ma_khoa_hoc= @maKhoaHoc ";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetLopModel(dr));
                }
            }
            return list;
        }

        public List<LopModel> GetLopModels(int maKhoaHoc, int maKhoa)
        {
            List<LopModel> list = new List<LopModel>();
            string query = @"SELECT TOP (1000) [ma_lop]
		                    ,[ten_lop]
		                    ,[Nganh].ten_nganh
		                    ,[KhoaHoc].ten_khoa_hoc
		                    ,[Khoa].ten_khoa
		                    ,[User].full_name
		                    ,[Lop].[ngay_tao]
	                    FROM [QLDoanVien].[dbo].[Lop]
	                    INNER JOIN [KhoaHoc] ON KhoaHoc.ma_khoa_hoc = [Lop].ma_khoa_hoc
	                    INNER JOIN [Nganh] ON [Nganh].ma_nganh = Lop.[ma_nganh]
	                    INNER JOIN [Khoa] ON Nganh.ma_khoa = Khoa.ma_khoa
	                    INNER JOIN [User] ON [User].user_name = [Lop].user_name
	                    WHERE KhoaHoc.ma_khoa_hoc = @maKhoaHoc AND Khoa.ma_khoa = @maKhoa ";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetLopModel(dr));
                }
            }
            return list;
        }

        public List<LopModel> GetLopModels(int maKhoaHoc, int maKhoa, int maNganh)
        {
            List<LopModel> list = new List<LopModel>();
            string query = @"SELECT TOP (1000) [ma_lop]
		                    ,[ten_lop]
		                    ,[Nganh].ten_nganh
		                    ,[KhoaHoc].ten_khoa_hoc
		                    ,[Khoa].ten_khoa
		                    ,[User].full_name
		                    ,[Lop].[ngay_tao]
	                    FROM [QLDoanVien].[dbo].[Lop]
	                    INNER JOIN [KhoaHoc] ON KhoaHoc.ma_khoa_hoc = [Lop].ma_khoa_hoc
	                    INNER JOIN [Nganh] ON [Nganh].ma_nganh = Lop.[ma_nganh]
	                    INNER JOIN [Khoa] ON Nganh.ma_khoa = Khoa.ma_khoa
	                    INNER JOIN [User] ON [User].user_name = [Lop].user_name
	                    WHERE KhoaHoc.ma_khoa_hoc = @maKhoaHoc AND Khoa.ma_khoa = @maKhoa AND Nganh.ma_nganh = @maNganh ";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, maNganh });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetLopModel(dr));
                }
            }
            return list;
        }

        public int ThemLop(Lop lop)
        {
            string query = @"INSERT INTO [dbo].[Lop]
           ([ten_lop]
           ,[ma_nganh]
           ,[ma_khoa_hoc])
     VALUES
           ( @tenlop 
           , @manganh 
           , @makhoahoc )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { lop.tenLop, lop.maNganh, lop.maKhoaHoc });
        }

        public int SuaLop(Lop lop)
        {
            string query = @"UPDATE [dbo].[Lop]
   SET [ten_lop] = @tenlop 
      ,[ma_nganh] = @manganh 
      ,[ma_khoa_hoc] = @makhoahoc 
 WHERE [ma_lop] = @malop";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { lop.tenLop, lop.maNganh, lop.maKhoaHoc });
        }

        public int XoaLop(Lop lop)
        {
            string query = @"DELETE FROM [dbo].[Lop]
      WHERE [ma_lop] = @malop";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { lop.maLop });
        }

        private Lop GetLop(DataRow dr)
        {
            Lop lop = new Lop();
            lop.maNganh = int.Parse(dr["ma_nganh"].ToString());
            lop.maLop = int.Parse(dr["ma_lop"].ToString());
            lop.maKhoaHoc = int.Parse(dr["ma_khoa_hoc"].ToString());
            lop.tenLop = dr["ten_lop"].ToString();
            return lop;
        }

        private LopModel GetLopModel(DataRow dr)
        {
            LopModel lop = new LopModel();
            lop.ma_lop = int.Parse(dr["ma_lop"].ToString());
            lop.ten_lop = dr["ten_lop"].ToString();
            lop.ten_nganh = dr["ten_nganh"].ToString();
            lop.ten_khoa_hoc = dr["ten_khoa_hoc"].ToString();
            lop.ten_khoa = dr["ten_khoa"].ToString();
            lop.full_name = dr["full_name"].ToString();
            lop.ngay_tao = DateTime.Parse(dr["ngay_tao"].ToString());
            return lop;
        }

    }
}
