﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MakingGUI.DAO
{
    public class DBConnect
    {
        private static SqlConnection _conn = null;

        private static void InitConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["nguyenphuocthuan"].ConnectionString;
                _conn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlConnection GetConnection()
        {
            if (_conn == null)
            {
                try
                {
                    InitConnection();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            _conn.Open();
            return _conn;
        }

        public static void CloseConnection()
        {
            if (_conn != null)
            {
                _conn.Close();
            }
        }
    }
}
