using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingGUI.DAO
{
    public class TenPhongDAO
    {
        public DataTable getAll()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(DBCommands.DEPARTMENT_QUERY_GETDEPARTMENTNAME, DBConnect.GetConnection());
                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            finally
            {
                DBConnect.CloseConnection();
            }
        }
    }
}
