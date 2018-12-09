using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DTO;
using DTO.ViewModels;
using System.Data;

namespace BUS
{
    public class SinhVienBus
    {
        private static SinhVienBus instance;

        public static SinhVienBus Instance
        {
            get { if (instance == null) instance = new SinhVienBus(); return SinhVienBus.instance; }
            private set { instance = value; }
        }
        /// <summary>
        /// Lấy về một danh sách các sinh viên là đoàn viên
        /// </summary>
        /// <param name="ma_sv"></param>
        /// <returns></returns>
        public SinhVien GetSinhVienDV(string ma_sv)
        {
            SinhVien sv = null;
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
      ,[la_doanvien]
      ,[la_hoivien]
      ,[da_xoa]
      ,[ma_lop]
      ,[role_id]
  FROM [QLDoanVien].[dbo].[SinhVien] where [ma_sv] = @ma_sv and da_xoa = 0";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { ma_sv });
            if (dt.Rows.Count > 0)
            {
                sv = GetSinhVien(dt.Rows[0]);
            }
            return sv;
        }

        /// <summary>
        /// Lay về danh sách các sinh viên là hội viên
        /// </summary>
        /// <param name="ma_sv">mã sinh viên</param>
        /// <returns></returns>
        public SinhVien GetSinhVienHV(string ma_sv)
        {
            SinhVien sv = null;
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
      ,[la_doanvien]
      ,[la_hoivien]
      ,[da_xoa]
      ,[ma_lop]
      ,[role_id]
  FROM [QLDoanVien].[dbo].[SinhVien] where [ma_sv] = @ma_sv and la_hoivien = 1 and da_xoa = 0";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { ma_sv });
            if (dt.Rows.Count > 0)
            {
                sv = GetSinhVien(dt.Rows[0]);
            }
            return sv;
        }

        /// <summary>
        /// lấy về tông số sinh viên là đoàn viên
        /// </summary>
        /// <returns></returns>
        public int CountDoanVien()
        {
            int result = 0;
            string query = @"select COUNT (*) as 'doanvien' from SinhVien where la_doanvien = 1";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }
            return result;
        }

        /// <summary>
        /// lấy về tổng số sinh viên là hội viên
        /// </summary>
        /// <returns></returns>
        public int CountHoiVien()
        {
            int result = 0;
            string query = @"select COUNT (*) as 'hoi_vien' from SinhVien where la_hoivien = 1";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                result = int.Parse(dt.Rows[0][0].ToString());
            }
            return result;
        }

        public int ThemSinhVien(SinhVien sinhVien)
        {
            string query = @"INSERT INTO [dbo].[SinhVien]
           ([ma_sv]
           ,[ho_ten]
           ,[pass]
           ,[dia_chi]
           ,[sdt]
           ,[la_doanvien]
           ,[la_hoivien]
           ,[da_xoa]
           ,[ma_lop]
           ,[role_id]
           ,[da_dong_hp_dp])
     VALUES
           ( @masv 
           , @pass 
           , @hoten 
           , @diachi 
           , @sdt 
           , @doanvien 
           , @hoivien 
           , @daxoa 
           , @malop 
           , @role 
           , @tinhtrang )";

            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { sinhVien.ma_sv, sinhVien.ho_ten, sinhVien.pass, sinhVien.dia_chi
            , sinhVien.sdt, sinhVien.la_doanvien, sinhVien.la_hoivien, sinhVien.da_xoa, sinhVien.ma_lop, sinhVien.role_id, sinhVien.da_dong});
        }

        public DataResult ThemSinhVien(SinhVien sinhVien, DataResult result, bool is_doanvien = true)
        {
            SinhVien temp = null;
            if (is_doanvien)
            {
                temp = GetSinhVienDV(sinhVien.ma_sv);
                if (temp == null)
                {
                    if (ThemSinhVien(sinhVien) > 0)
                    {
                        result.successItem++;
                    }
                    else
                    {
                        result.errorItem++;
                    }
                }
                else
                {
                    result.duplicateItem++;
                }
            }
            else
            {
                temp = GetSinhVienHV(sinhVien.ma_sv);
                if (temp != null)
                {
                    if (ThemSinhVien(sinhVien) > 0)
                    {
                        result.successItem++;
                    }
                    else
                    {
                        result.errorItem++;
                    }
                }
                else
                {
                    result.duplicateItem++;
                }
            }

            return result;
        }

        public int SuaSinhVien(SinhVien sinhVien)
        {
            string query = @"UPDATE [dbo].[SinhVien]
   SET [ho_ten] = @hoten 
      ,[dia_chi] = @dia_chi 
      ,[sdt] = @sdt 
      ,[la_doanvien] = @la_doanvien 
      ,[la_hoivien] = @la_hoivien 
      ,[ma_lop] = @ma_lop 
      ,[da_dong_hp_dp] = @tinhtrang
 WHERE [ma_sv] = @masv ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { sinhVien.ho_ten, sinhVien.dia_chi, sinhVien.sdt
            ,sinhVien.la_doanvien, sinhVien.la_hoivien, sinhVien.ma_lop, sinhVien.da_dong, sinhVien.ma_sv});
        }


        /// <summary>
        /// Xóa sinh viên nhưng không xóa hẳn khỏi database
        /// </summary>
        /// <param name="masv"></param>
        /// <returns></returns>
        public int XoaSinhVien(string masv)
        {
            string query = @"UPDATE [dbo].[SinhVien]
   SET [da_xoa] = 1 
 WHERE [ma_sv] = @masv ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { masv });
        }


        /// <summary>
        /// lấy về danh sách của tất cả sinh viên
        /// </summary>
        /// <returns></returns>
        public List<SinhVien> GetSinhViens()
        {
            List<SinhVien> list = new List<SinhVien>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
      ,[la_doanvien]
      ,[la_hoivien]
      ,[da_xoa]
      ,[ma_lop]
      ,[role_id]
  FROM [QLDoanVien].[dbo].[SinhVien] where da_xoa = 0";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVien(dr));
                }
            }
            return list;
        }


        /// <summary>
        /// Lấy về danh sách hiển thị thông tin của sinh viên
        /// </summary>
        /// <returns></returns>
        public List<SinhVienModel> GetSinhVienModels()
        {
            List<SinhVienModel> list = new List<SinhVienModel>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModel(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy ra 1 danh sách sinh viên là đoàn viên
        /// </summary>
        /// <returns></returns>
        public List<SinhVienModel> GetSinhVienDVModels()
        {
            List<SinhVienModel> list = new List<SinhVienModel>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModel(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy ra danh sách đoàn viên theo tình trạng đã đóng đoàn phí hay chưa?
        /// </summary>
        /// <returns></returns>
        public List<SinhVienModelExtent> GetSinhVienDVModelExtent()
        {
            List<SinhVienModelExtent> list = new List<SinhVienModelExtent>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModelExtent(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy ra danh sách sinh viên là đoàn viên với tình trạng đoàn phí
        /// </summary>
        /// <param name="maKhoaHoc"></param>
        /// <param name="maKhoa"></param>
        /// <param name="manganh"></param>
        /// <param name="maLop"></param>
        /// <param name="tt_doanPhi">Lọc theo "đã đóng - 1"/"chưa đóng = 0"/"tất cả = -1"</param>
        /// <returns></returns>
        public List<SinhVienModelExtent> GetSinhVienDVModelExtent(int maKhoaHoc = 0, int maKhoa = 0, int manganh = 0, int maLop = 0, int tt_doanPhi = 0)
        {
            List<SinhVienModelExtent> list = new List<SinhVienModelExtent>();
            string query = string.Empty;
            DataTable dt = null;

            if (maKhoaHoc > 0)
            {
                if(maKhoa > 0)
                {
                    if(manganh > 0)
                    {
                        if (maLop > 0)
                        {
                            query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1 
and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh and Lop.ma_lop = @malop";
                            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, manganh, maLop });
                        }
                        else
                        {
                            query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1 and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh";
                            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, manganh });
                        }
                    }
                    else
                    {
                        query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1 and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa";
                        dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa });
                    }
                }
                else
                {
                    query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1 and Lop.ma_khoa_hoc = @makhoahoc";
                    dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc });
                }
            }
            else
            {
                query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1";
                dt = DataProvider.Instance.ExcuteQuery(query);
            }

            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModelExtent(dr));
                }
            }

            if(tt_doanPhi == -1)
            {
                return list;
            }else if(tt_doanPhi == 0)
            {
                return list.Where(x => !x.da_dong_doan_phi).ToList();
            }
            else
            {
                return list.Where(x => x.da_dong_doan_phi).ToList();
            }
        }

        /// <summary>
        /// Lấy ra danh sách sinh viên là Hội viên với tình trạng hội phí
        /// </summary>
        /// <param name="maKhoaHoc"></param>
        /// <param name="maKhoa"></param>
        /// <param name="manganh"></param>
        /// <param name="maLop"></param>
        /// <param name="tt_doanPhi">Lọc theo "đã đóng - 1"/"chưa đóng = 0"/"tất cả = -1"</param>
        /// <returns></returns>
        public List<SinhVienModelExtent> GetSinhVienHVModelExtent(int maKhoaHoc = 0, int maKhoa = 0, int manganh = 0, int maLop = 0, int tt_doanPhi = 0)
        {
            List<SinhVienModelExtent> list = new List<SinhVienModelExtent>();
            string query = string.Empty;
            DataTable dt = null;

            if (maKhoaHoc > 0)
            {
                if (maKhoa > 0)
                {
                    if (manganh > 0)
                    {
                        if (maLop > 0)
                        {
                            query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 
and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh and Lop.ma_lop = @malop";
                            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, manganh, maLop });
                        }
                        else
                        {
                            query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh";
                            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, manganh });
                        }
                    }
                    else
                    {
                        query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa";
                        dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa });
                    }
                }
                else
                {
                    query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc";
                    dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc });
                }
            }
            else
            {
                query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1";
                dt = DataProvider.Instance.ExcuteQuery(query);
            }


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModelExtent(dr));
                }
            }

            if (tt_doanPhi == -1)
            {
                return list;
            }
            else if (tt_doanPhi == 0)
            {
                return list.Where(x => !x.da_dong_doan_phi).ToList();
            }
            else
            {
                return list.Where(x => x.da_dong_doan_phi).ToList();
            }
        }

        /// <summary>
        /// Lấy về 1 danh sách sinh viên là hội viên để hiển thị
        /// </summary>
        /// <param name="maKhoaHoc"></param>
        /// <param name="maKhoa"></param>
        /// <param name="manganh"></param>
        /// <param name="maLop"></param>
        /// <returns></returns>
        public List<SinhVienModelExtent> GetSinhVienHVModel(int maKhoaHoc = 0, int maKhoa = 0, int manganh = 0, int maLop = 0)
        {
            List<SinhVienModelExtent> list = new List<SinhVienModelExtent>();
            string query = string.Empty;
            DataTable dt = null;

            if (maKhoaHoc > 0)
            {
                if (maKhoa > 0)
                {
                    if (manganh > 0)
                    {
                        if (maLop > 0)
                        {
                            query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 
and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh and Lop.ma_lop = @malop";
                            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, manganh, maLop });
                        }
                        else
                        {
                            query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh";
                            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, manganh });
                        }
                    }
                    else
                    {
                        query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa";
                        dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa });
                    }
                }
                else
                {
                    query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc";
                    dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc });
                }
            }
            else
            {
                query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1";
                dt = DataProvider.Instance.ExcuteQuery(query);
            }


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModelExtent(dr));
                }
            }

            return list;
        }

        public List<SinhVienModel> GetSinhVienHVModels(int maKhoaHoc = 0, int maKhoa = 0, int manganh = 0, int maLop = 0)
        {
            List<SinhVienModel> list = new List<SinhVienModel>();
            string query = string.Empty;
            DataTable dt = null;

            if (maKhoaHoc > 0)
            {
                if (maKhoa > 0)
                {
                    if (manganh > 0)
                    {
                        if (maLop > 0)
                        {
                            query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 
and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh and Lop.ma_lop = @malop";
                            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, manganh, maLop });
                        }
                        else
                        {
                            query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh";
                            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa, manganh });
                        }
                    }
                    else
                    {
                        query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa";
                        dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, maKhoa });
                    }
                }
                else
                {
                    query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1 and Lop.ma_khoa_hoc = @makhoahoc";
                    dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc });
                }
            }
            else
            {
                query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
      ,da_dong_hp_dp as 'doan_phi'
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1";
                dt = DataProvider.Instance.ExcuteQuery(query);
            }


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModelExtent(dr));
                }
            }

            return list;
        }

        /// <summary>
        /// Lấy ra danh sách đoàn viên theo Mã Khóa Học
        /// </summary>
        /// <param name="maKhoaHoc"></param>
        /// <returns></returns>
        public List<SinhVienModel> GetSinhVienDVModels(int maKhoaHoc)
        {
            List<SinhVienModel> list = new List<SinhVienModel>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1 and Lop.ma_khoa_hoc = @makhoahoc";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModel(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy ra danh sách đoàn viên theo Mã Khoá Học, Mã Khoa
        /// </summary>
        /// <param name="maKhoaHoc"></param>
        /// <param name="makhoa"></param>
        /// <returns></returns>
        public List<SinhVienModel> GetSinhVienDVModels(int maKhoaHoc, int makhoa)
        {
            List<SinhVienModel> list = new List<SinhVienModel>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1 
and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, makhoa });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModel(dr));
                }
            }
            return list;
        }


        /// <summary>
        /// Lấy ra danh sách các đoàn viên  theo Mã Khóa Học, Mã Khoa, Mã Ngành
        /// </summary>
        /// <param name="maKhoaHoc"></param>
        /// <param name="makhoa"></param>
        /// <param name="maNganh"></param>
        /// <returns></returns>
        public List<SinhVienModel> GetSinhVienDVModels(int maKhoaHoc, int makhoa, int maNganh)
        {
            List<SinhVienModel> list = new List<SinhVienModel>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1 
and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, makhoa, maNganh });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModel(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// lấy ra danh sách các đoàn viên theo Mã Khóa Học,
        /// Mã Khoa, Mã Ngành & Mã Lớp
        /// </summary>
        /// <param name="maKhoaHoc"></param>
        /// <param name="makhoa"></param>
        /// <param name="maNganh"></param>
        /// <param name="maLop"></param>
        /// <returns></returns>
        public List<SinhVienModel> GetSinhVienDVModels(int maKhoaHoc, int makhoa, int maNganh, int maLop)
        {
            List<SinhVienModel> list = new List<SinhVienModel>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_doanvien = 1 
and Lop.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @makhoa and Nganh.ma_nganh = @manganh and Lop.ma_lop = @malop";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { maKhoaHoc, makhoa, maNganh, maLop });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModel(dr));
                }
            }
            return list;
        }


        /// <summary>
        /// Lấy ra danh sách các hội viên
        /// </summary>
        /// <returns></returns>
        public List<SinhVienModel> GetSinhVienHVModels()
        {
            List<SinhVienModel> list = new List<SinhVienModel>();
            string query = @"SELECT [ma_sv]
      ,[pass]
      ,[ho_ten]
      ,[dia_chi]
      ,[sdt]
	  , ten_lop
	  ,ten_nganh
	  ,Khoa.ten_khoa as 'khoa'
	  ,KhoaHoc.ten_khoa_hoc
  FROM [QLDoanVien].[dbo].[SinhVien]
  inner join Lop on Lop.ma_lop = SinhVien.ma_lop
  inner join Nganh on Lop.ma_nganh = Nganh.ma_nganh
  inner join Khoa on Khoa.ma_khoa = Nganh.ma_khoa
  inner join KhoaHoc on Lop.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc where SinhVien.la_hoivien = 1";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetSinhVienViewModel(dr));
                }
            }
            return list;
        }

        private SinhVien GetSinhVien(DataRow dr)
        {
            SinhVien sv = new SinhVien();
            sv.ma_sv = dr["ma_sv"].ToString();
            sv.ho_ten = dr["ho_ten"].ToString();
            sv.dia_chi = dr["dia_chi"].ToString();
            sv.pass = dr["pass"].ToString();
            sv.sdt = dr["sdt"].ToString();
            sv.la_doanvien = bool.Parse(dr["la_doanvien"].ToString());
            sv.la_hoivien = bool.Parse(dr["la_hoivien"].ToString());
            sv.ma_lop = int.Parse(dr["ma_lop"].ToString());
            sv.role_id = int.Parse(dr["role_id"].ToString());
            sv.da_xoa = bool.Parse(dr["da_xoa"].ToString());
            return sv;
        }

        private SinhVienModel GetSinhVienViewModel(DataRow dr)
        {
            SinhVienModel sv = new SinhVienModel();
            sv.ma_sv = dr["ma_sv"].ToString();
            sv.ho_ten = dr["ho_ten"].ToString();
            sv.dia_chi = dr["dia_chi"].ToString();
            sv.sdt = dr["sdt"].ToString();
            sv.lop = dr["ten_lop"].ToString();
            sv.nganh = dr["ten_nganh"].ToString();
            sv.khoa = dr["khoa"].ToString();
            sv.khoa_hoc = dr["ten_khoa_hoc"].ToString();
            return sv;
        }

        private SinhVienModelExtent GetSinhVienViewModelExtent(DataRow dr)
        {
            SinhVienModelExtent sv = new SinhVienModelExtent();
            sv.ma_sv = dr["ma_sv"].ToString();
            sv.ho_ten = dr["ho_ten"].ToString();
            sv.dia_chi = dr["dia_chi"].ToString();
            sv.sdt = dr["sdt"].ToString();
            sv.lop = dr["ten_lop"].ToString();
            sv.nganh = dr["ten_nganh"].ToString();
            sv.khoa = dr["khoa"].ToString();
            sv.da_dong_doan_phi = bool.Parse(dr["doan_phi"].ToString());
            sv.khoa_hoc = dr["ten_khoa_hoc"].ToString();
            return sv;
        }
    }
}
