using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PTTK2.NHANVIEN
{
    public class DAL_NhanVien
    {

        /// <summary>
        /// Đọc thông tin nhân viên và trả các thông tin liên quan đến nhân viên được cung cấp thông qua mã nhân viên
        /// </summary>
        /// <param name="maNV"></param>
        /// <returns></returns>
        public static SqlDataReader getNhanVien(string maNV)
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("select manv,hoten,bangcap,nv.diachi,email,luong,ngaysinh,sdtnv,trungtamlamviec,vitri,sonamkinhnghiem,tt.tentrungtam "+
                                                "from nhanvien nv, TRUNGTAM tt "+
                                                "where TrungTamLamViec = tt.matt and manv = @maNV",SqlConnector._conn);
            command.Parameters.AddWithValue("maNV", maNV);
            return command.ExecuteReader();
        }

        /// <summary>
        /// Nếu thông tin đăng nhập chính xác có trong database thì đăng nhập hợp lệ
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static int login(string user, string pass)
        {
            try
            {
                SqlConnector._conn.Open();

                SqlCommand query = new SqlCommand("select count(*) from nhanvien where manv=@user and sdtnv=@pass;", SqlConnector._conn);
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

        public static void getWorkDate(string maNV, ref DataTable dt)
        {
            SqlConnector._conn.Open();

            SqlCommand query = new SqlCommand("select llv.MaCa,llv.MaNV,clv.CaLamViec,clv.Thu,clv.Buoi from lichlamviec llv,calamviec clv " +
                                                "where llv.manv = @maNV and llv.MaCa = clv.maca ", SqlConnector._conn);
            query.Parameters.AddWithValue("maNV", maNV);

            SqlDataAdapter adapter = new SqlDataAdapter(query);
            adapter.Fill(dt);
        }
    }
}
