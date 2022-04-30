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
            SqlDataReader reader = DAL_KhachHang.getKhachHangInfo(maKH.ToUpper());

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return new KhachHang(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString(),
                        reader.GetString(4), reader.GetString(5), reader.GetBoolean(6),
                        reader[7] == DBNull.Value ? "null":reader.GetString(7), reader.GetString(8)); 
                }
            }
            return null;
        }
    }
}
