﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace DAL
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { instance = value; }
        }

        private string stringConnection = @"Data Source=DESKTOP-PN5O7NM;Initial Catalog=QLDoanVien;Integrated Security=True";

        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable da = new DataTable();

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                if (parameter != null)
                {
                    string[] listPar = query.Split(' ');

                    int index = 0;

                    foreach (string item in listPar)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[index]);
                            index++;
                        }
                    }
                }

                adapter.Fill(da);

                connection.Close();
            }
            return da;
        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int result = -1;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPar = query.Split(' ');

                    int index = 0;

                    foreach (string item in listPar)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[index]);
                            index++;
                        }
                    }
                }

                result = command.ExecuteNonQuery();
            }
            return result;
        }
    }
}
