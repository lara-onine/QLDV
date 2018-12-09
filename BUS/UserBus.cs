using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DAL;

namespace BUS
{
    public class UserBus
    {
        private static UserBus instance;
        
        public static UserBus Instance
        {
            get { if (instance == null) instance = new UserBus(); return UserBus.instance; }
            private set { instance = value; }
        }

        public List<User> GetUsers()
        {
            List<User> list = new List<User>();
            string query = @"SELECT [user_name]
      ,[pass]
      ,[full_name]
      ,[address]
      ,[phone]
      ,[User].[role_id],[role_name]
  FROM [QLDoanVien].[dbo].[User]
  inner join Role on Role.role_id = [User].role_id";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    list.Add(GetUser(row));
                }
            }
            return list;
        }

        public int KiemTraTaiKhoan(User user, out User data)
        {
            string query = @"SET Rowcount 1;  SELECT [user_name]
      ,[pass]
      ,[full_name]
      ,[address]
      ,[phone]
      ,[User].[role_id],[role_name]
  FROM [QLDoanVien].[dbo].[User]
  inner join Role on Role.role_id = [User].role_id Where [user_name] = @username";

            int result = -1;

            DataTable table = DataProvider.Instance.ExcuteQuery(query, new object[] { user.user_name });
            User us = null;
            if (table.Rows.Count > 0)
            {
                
                foreach (DataRow row in table.Rows)
                {

                    us = GetUser(row);
                }
                if (us.pass.Equals(user.pass))
                {
                    
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            data = us;
            return result;

        }

        public User GetUser(string username)
        {
            string query = @"SELECT [user_name]
      ,[pass]
      ,[full_name]
      ,[address]
      ,[phone]
      ,[User].[role_id],[role_name]
  FROM [QLDoanVien].[dbo].[User]
  inner join Role on Role.role_id = [User].role_id where [user_name] = @username";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { username });
            if(dt.Rows.Count > 0)
            {
                return GetUser(dt.Rows[0]);
            }
            return null;
        }

        public int DoiMatKhau(string username, string pass)
        {
            string query = @"UPDATE [dbo].[User]
   SET [pass] = @pass 
 WHERE [user_name] = @username";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { pass, username });
        }

        public int SuaQuyen(string username, int roleID)
        {
            string query = @"UPDATE [dbo].[User]
   SET [role_id] = @roleid 
 WHERE [user_name] = @userna ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { roleID, username });
        }

        public int ThemNguoiDung(User user)
        {
            string query = @"INSERT INTO [dbo].[User]
           ([user_name]
           ,[pass]
           ,[full_name]
           ,[address]
           ,[phone]
           ,[role_id])
     VALUES
           ( @username 
           , @pass 
           , @fullname 
           , @address 
           , @phone 
           , @role )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { user.user_name, user.pass, user.full_name, user.address, user.phone, user.role_id });
        }

        public int SuaNguoiDung(User user)
        {
            string query = @"UPDATE [dbo].[User]
   SET [full_name] = @fullname 
      ,[address] = @address 
      ,[phone] = @phone 
 WHERE [user_name] = @username ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { user.full_name, user.address, user.phone, user.user_name });
        }

        public int XoaNguoiDung(string user_name)
        {
            string query = @"DELETE FROM [dbo].[User]
      WHERE [user_name] = @username";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { user_name });
        }

        private User GetUser(DataRow row)
        {
            User us = new User();
            us.user_name = row["user_name"].ToString();
            us.full_name = row["full_name"].ToString();
            us.address = row["address"].ToString();
            us.phone = row["phone"].ToString();
            us.pass = row["pass"].ToString().Trim();
            us.role_id = int.Parse(row["role_id"].ToString());
            us.role_name = row["role_name"].ToString();
            return us;
        }
    }
}
