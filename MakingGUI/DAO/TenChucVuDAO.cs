using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingGUI.DAO
{
    public class TenChucVuDAO
    {
        public DataTable getAll()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(DBCommands.CHUCVU_QUERY_GETTENCHUCVU, DBConnect.GetConnection());
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
