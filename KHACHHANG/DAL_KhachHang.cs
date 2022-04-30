using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.KHACHHANG
{
    public class DAL_KhachHang
    {

        /// <summary>
        /// Access Database to verify login
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static int loginVerification(string user, string pass)
        {
            try
            {
                SqlConnector._conn.Open();

                SqlCommand query = new SqlCommand("select count(*) from khachhang where makh=@user and sdtkh=@pass;", SqlConnector._conn);
                // parameterized to avoid injection
                query.Parameters.AddWithValue("@user", user.ToUpper());
                query.Parameters.AddWithValue("@pass", pass);

                Int32 isValid = Convert.ToInt32(query.ExecuteScalar());
                return isValid;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// Access database to get a customer info
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static SqlDataReader getKhachHangInfo(string maKH)
        {
            SqlCommand  command = new SqlCommand("select * from khachhang where makh = @kh",SqlConnector._conn);
            command.Parameters.AddWithValue("@kh", maKH);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}

