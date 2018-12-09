using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class RoleBus
    {
        private static RoleBus instance;

        public static RoleBus Instance
        {
            get { if (instance == null) instance = new RoleBus(); return RoleBus.instance; }
            private set { instance = value; }
        }

        public Role GetRole(int roleId)
        {
            string query = @"SELECT [role_id]
      ,[role_name]
  FROM [dbo].[Role] where [role_id] = @roleid";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { roleId });
            if(dt.Rows.Count > 0)
            {
                return GetRole(dt.Rows[0]);
            }
            return null;
        }

        public List<Role> GetRoles()
        {
            List<Role> list = new List<Role>();
            string query = @"SELECT [role_id]
      ,[role_name]
  FROM [dbo].[Role]";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    list.Add(GetRole(row));
                }
            }
            return list;
        }

        private Role GetRole(DataRow row)
        {
            Role role = new Role();
            role.roldID = int.Parse(row["role_id"].ToString());
            role.roleName = row["role_name"].ToString();
            return role;
        }
    }
}
