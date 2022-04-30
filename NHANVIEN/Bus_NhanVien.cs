using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace PTTK2.NHANVIEN
{
    public class Bus_NhanVien
    {
        /// <summary>
        /// Lấy thông tin từ tầng DAL và parse thành object NhanVien
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static NhanVien GetNhanVien(string maNV)
        {
            SqlDataReader reader = DAL_NhanVien.getNhanVien(maNV.ToUpper());
            NhanVien newNV = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newNV = new NhanVien(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                                         reader.GetString(3), reader.GetString(4), reader.GetInt32(5),
                                         reader.GetDateTime(6).ToString("MM/dd/yyyy"), reader.GetString(7),
                                         reader.GetString(8), reader.GetString(9),
                                         reader[10] == DBNull.Value ? 0 : reader.GetInt32(10),reader.GetString(11));
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            return newNV;
        }

        /// <summary>
        /// gọi tầng DAL để truy cập database và kiểm tra đăng nhập
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static int login(string user,string pass)
        {
            return DAL_NhanVien.login(user.ToUpper(), pass);
        }

        /// <summary>
        /// Tạo object DataTable sau khi đã truy vấn lịch làm việc + ca làm việc ở tầng DAL
        /// </summary>
        /// <param name="maNV"></param>
        /// <returns></returns>
        public static DataTable getWorkDate(string maNV)
        {
            DataTable dt = new DataTable();
            DAL_NhanVien.getWorkDate(maNV.ToUpper(),ref dt);
            return dt;
        }
    }
}
