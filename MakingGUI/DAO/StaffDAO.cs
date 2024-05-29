using MakingGUI.DTO;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingGUI.DAO
{
    public class StaffDAO
    {
        SqlCommand cmd = null;

        public DataTable getAll()
        {
            try
            {
                cmd = new SqlCommand(DBCommands.STAFF_QUERY_GETALL, DBConnect.GetConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            finally
            {
                DBConnect.CloseConnection();
            }
        }

        public bool saveStaff(DTO_Staff staff)
        {
            try
            {
                string sql = string.Format(DBCommands.STARR_QUERY_ADD, staff.Name.ToString().Trim(), staff.YoB.ToString("yyyyMMdd"), (staff.Gender == true) ? 1 : 0, staff.PhoneNumber.ToString(), staff.HeSoLuong.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), staff.MaPhong.ToString().Trim(), staff.MaChucVu.ToString().Trim());
                cmd = new SqlCommand(sql, DBConnect.GetConnection());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(cmd != null)
                {
                    cmd.Dispose();
                }
                DBConnect.CloseConnection();
            }

            return false;
        }

        public bool updateStaff(DTO_Staff staff)
        {
            try
            {
                string sql = string.Format(DBCommands.STAFF_QUERY_UPDATE, staff.Id.ToString(), staff.Name.ToString(), staff.YoB.ToString("yyyyMMdd"), (staff.Gender == true) ? 1 : 0, staff.PhoneNumber.ToString(), staff.HeSoLuong.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), staff.MaPhong.ToString(), staff.MaChucVu.ToString());
                cmd = new SqlCommand(sql, DBConnect.GetConnection());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
                if(cmd != null)
                {
                    cmd.Dispose();
                }
                DBConnect.CloseConnection();
            }

            return false;
        }

        public bool deleteStaff(int MaNV) 
        {
            try
            {
                string sql = string.Format(DBCommands.STAFF_QUERY_DELETE, MaNV);
                cmd = new SqlCommand(sql, DBConnect.GetConnection());

                if(cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            } catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(cmd != null)
                {
                    cmd.Dispose();
                }
                DBConnect.CloseConnection();
            }

            return false;
        }

        public bool thongkeStaff()
        {

        }
    }
}
