using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DTO;
using DTO.ViewModels;

namespace BUS
{
    public class EventsBus
    {
        private static EventsBus instance;

        public static EventsBus Instance
        {
            get { if (instance == null) instance = new EventsBus(); return EventsBus.instance; }
            private set { instance = value; }
        }

        public List<SuKienModel> DanhSachSuKien()
        {
            List<SuKienModel> events = new List<SuKienModel>();

            string query = @"SELECT [ma_sk]
                              ,[tieu_de]
                              ,[noi_dung]
                              ,[dia_diem]
                              ,[thoi_gian]
                              ,[thoi_gian_tao]
	                          ,[User].[full_name]
                          FROM [dbo].[SuKien]
                          INNER JOIN [dbo].[User] ON [SuKien].[user_name] = [User].[user_name] ";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            if(data.Rows.Count>0)
            {
                foreach(DataRow row in data.Rows)
                {
                    events.Add(GetEvent(row));
                }
                return events.OrderByDescending(x=>x.thoi_gian).ToList();
            }
            else
            {
                return null;
            }
            
        }

        private SuKienModel GetEvent(DataRow row)
        {
            SuKienModel temp = new SuKienModel();
            temp.ma_sk = int.Parse(row["ma_sk"].ToString());
            temp.tieu_de = row["tieu_de"].ToString();
            temp.dia_diem = row["dia_diem"].ToString();
            temp.noi_dung = row["noi_dung"].ToString();
            temp.thoi_gian = DateTime.Parse(row["thoi_gian"].ToString());
            temp.thoi_gian_tao = DateTime.Parse(row["thoi_gian_tao"].ToString());
            temp.full_name = row["full_name"].ToString();
            return temp;
        }

        public int ThemSuKien(Events events)
        {
            string query = @"INSERT INTO [dbo].[SuKien]
           ( [tieu_de]
           ,[dia_diem]
           ,[noi_dung]
           ,[thoi_gian]
           ,[user_name]
           ,[thoi_gian_tao] )
     VALUES
           ( @tieu_de , @dia_diem , @noi_dung , @thoi_gian , @user_name , @thoi_gian_tao )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { events.tieu_de, events.dia_diem, events.noi_dung, events.thoi_gian, events.user_name, events.thoi_gian_tao });
        }

        public int SuaSuKien(Events events)
        {
            string query = @"UPDATE [dbo].[SuKien] SET tieu_de = @tieu_de , dia_diem = @dia_diem , noi_dung = @noi_dung , thoi_gian = @thoi_gian , user_name = @user_name WHERE ma_sk = @ma_sk ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { events.tieu_de, events.dia_diem, events.noi_dung, events.thoi_gian, events.user_name, events.ma_sk });
        }

        public int XoaSuKien(Events events)
        {
            string query = @"DELETE FROM [dbo].[SuKien] WHERE ma_sk = @ma_sk";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { events.ma_sk });
        }

        public Events GetEvents(int ma_sk)
        {
            string query = @"SELECT * FROM [QLDoanVien].[dbo].[SuKien] Where ma_sk = @ma_sk ";
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExcuteQuery(query, new object[] { ma_sk });
            if(data.Rows.Count > 0)
            {
                return GetEvents(data.Rows[0]);
            }
            return null;
            
        }

        private Events GetEvents(DataRow row)
        {
            Events temp = new Events();
            temp.ma_sk = int.Parse(row["ma_sk"].ToString());
            temp.tieu_de = row["tieu_de"].ToString();
            temp.dia_diem = row["dia_diem"].ToString();
            temp.noi_dung = row["noi_dung"].ToString();
            temp.thoi_gian = DateTime.Parse(row["thoi_gian"].ToString());
            temp.thoi_gian_tao = DateTime.Parse(row["thoi_gian_tao"].ToString());
            temp.user_name = row["user_name"].ToString();
            return temp;
        }

    }
}
