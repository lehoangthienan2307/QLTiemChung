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
        /// Giao tiếp với database và thêm dữ liệu khách hàng mới
        /// </summary>
        /// <param name="kh"></param>
        public static bool insert(KhachHang kh)
        {
            string nextID = Bus_KhachHang.getNextID();
            SqlConnector._conn.Open();

            SqlCommand com = new SqlCommand("insert into khachhang values(@maKH,@hoTen,@gioiTinh,@ngaySinh,@SDT,@diaChi,@treEm,@maNGH,@quanHe)",
                SqlConnector._conn);
            com.Parameters.AddWithValue("maKH",nextID);
            com.Parameters.AddWithValue("hoTen",kh.HoTen);
            com.Parameters.AddWithValue("gioiTinh",kh.GioiTinh);
            com.Parameters.AddWithValue("ngaySinh",kh.NgaySinh);
            com.Parameters.AddWithValue("SDT",kh.SDTKH);
            com.Parameters.AddWithValue("diaChi",kh.DiaChi);
            com.Parameters.AddWithValue("treEm",kh.TreEm? 1:0);
            com.Parameters.AddWithValue("maNGH",DBNull.Value);
            com.Parameters.AddWithValue("quanHe",DBNull.Value);

            int row = com.ExecuteNonQuery();
            if (row < 0)
            {
                SqlConnector._conn.Close();
                return false;
            }
            else
            {
                SqlConnector._conn.Close();
                return true;
            }
        }

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

                SqlCommand query = new SqlCommand("select count(*) from khachhang where makh=@user and sdtkh=@pass and treem = 0;", SqlConnector._conn);
                // parameterized to avoid injection
                query.Parameters.AddWithValue("@user", user.ToUpper());
                query.Parameters.AddWithValue("@pass", pass);

                Int32 isValid = Convert.ToInt32(query.ExecuteScalar());
                SqlConnector._conn.Close();
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
            SqlConnector._conn.Open();
            SqlCommand command = new SqlCommand("select * from khachhang where makh = @kh",SqlConnector._conn);
            command.Parameters.AddWithValue("@kh", maKH);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Lấy tên người thân của người đang sử dụng hệ thống
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static SqlDataReader getChildrenName(string maKH)
        {
            SqlConnector._conn.Open();
            SqlCommand command = new SqlCommand("select hoten from khachhang where mangh = @kh", SqlConnector._conn);
            command.Parameters.AddWithValue("@kh", maKH);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Lấy toàn bộ thông tin của người thân của người dùng hiện tại
        /// </summary>
        /// <param name="name"></param>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static SqlDataReader getChildInfo(string name,string maKH)
        {
            SqlConnector._conn.Open();
            SqlCommand command = new SqlCommand("select * from khachhang where mangh = @kh and hoten = @name", SqlConnector._conn);
            command.Parameters.AddWithValue("@kh", maKH);
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            return reader; 
        }

        /// <summary>
        /// Lấy thông tin của các gói tiêm chủng
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader getGoiTiemChung()
        {
            SqlConnector._conn.Open();
            SqlCommand command = new SqlCommand("select * from khachhang where mangh = @kh and hoten = @name", SqlConnector._conn);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Lấy mã khách hàng mới tiếp theo
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader getNextID()
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("select top 1 makh from khachhang order by makh desc", SqlConnector._conn);

            return command.ExecuteReader();
        }
    }
}

