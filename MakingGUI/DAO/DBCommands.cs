using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingGUI.DAO
{
    public class DBCommands
    {
        public static readonly string STAFF_QUERY_GETALL = "SELECT * FROM DSNV";
        public static readonly string DEPARTMENT_QUERY_GETDEPARTMENTNAME = "SELECT MaPhong, TenPhong FROM DMPHONG";
        public static readonly string CHUCVU_QUERY_GETTENCHUCVU = "SELECT MaChucVu, TenChucVu FROM CHUCVU";
        public static readonly string STARR_QUERY_ADD = "INSERT DSNV(HoTen, NgaySinh, GioiTinh, SoDT, HeSoLuong, MaPhong, MaChucVu)\r\nVALUES(N'{0}', '{1}', {2}, '{3}', {4}, '{5}', '{6}')";
        public static readonly string STAFF_QUERY_UPDATE = "UPDATE DSNV SET HoTen = N'{1}', NgaySinh = '{2}', GioiTinh = {3}, SoDT = '{4}', HeSoLuong = {5},\r\nMaPhong = '{6}', MaChucVu = '{7}' WHERE MaNV = {0}";
        public static readonly string STAFF_QUERY_DELETE = "DELETE FROM DSNV WHERE MaNV = {0}";
        public static readonly string STAFF_QUERY_THONGKE = "SELECT MaPhong, TenPhong, COUNT(nv.MaNV) AS SoLuongNhanVien FROM DMPHONG LEFT JOIN DSNV nv ON MaPhong = MaPhong GROUP BY MaPhong, TenPhong ORDER BY dp.TenPhong";
    }
}
