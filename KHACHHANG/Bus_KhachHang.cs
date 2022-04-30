using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.KHACHHANG
{
     public class Bus_KhachHang
    {
        public static int login(string user, string pass)
        {
            return DAL_KhachHang.loginVerification(user.ToUpper(), pass);
        }


        /// <summary>
        /// Call DAL to get sqldatareader, parse the result to KhachHang object
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static KhachHang getInfo(string maKH)
        {
            KhachHang kh = null;
            SqlDataReader reader = DAL_KhachHang.getKhachHangInfo(maKH.ToUpper());

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    kh  = new KhachHang(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString("dd/MM/yyyy"),
                        reader.GetString(4), reader.GetString(5), reader.GetBoolean(6),
                        reader[7] == DBNull.Value ? "null":reader.GetString(7), reader.GetString(8));
               
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            return kh;
        }

        /// <summary>
        /// Lấy danh sách tên trẻ em của người đăng ký
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static List<string> getChildrenName(string maKH)
        {
            SqlDataReader reader = DAL_KhachHang.getChildrenName(maKH.ToUpper());
            List<String> childrenName = new List<String>();

            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    childrenName.Add(reader.GetString(0));
                }
            }
            reader.Close();
            SqlConnector._conn.Close();

            return childrenName;
        }

        /// <summary>
        /// Xử lí data từ tầng DAL để tạo thành object KhachHang
        /// </summary>
        /// <param name="name"></param>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static KhachHang getChildInfo(string name, string maKH)
        {
            SqlDataReader reader = DAL_KhachHang.getChildInfo(name,maKH.ToUpper());
            KhachHang kh = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    kh = new KhachHang(reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDateTime(3).ToString("dd/MM/yyyy"),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetBoolean(6),
                        reader[7] == DBNull.Value ? "null" : reader.GetString(7),
                        reader[8] == DBNull.Value ? "null" :reader.GetString(8));
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            return kh;
        }
    }
}
