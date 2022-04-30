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
        /// <summary>
        /// tạo object KhachHang để gọi hàm insert xuống tầng DAL
        /// </summary>
        /// <param name="maKH"></param>
        /// <param name="hoTen"></param>
        /// <param name="gioiTinh"></param>
        /// <param name="dob"></param>
        /// <param name="SDT"></param>
        /// <param name="diaChi"></param>
        public static bool insert(string hoTen, string gioiTinh, DateTime dob, string SDT, string diaChi)
        {
            if (isValidBornDate(dob))
            {
                KhachHang newKH = new KhachHang(null, hoTen, gioiTinh, dob.ToString("MM/dd/yyyy"), SDT, diaChi, false, null, null);
                if (DAL_KhachHang.insert(newKH))
                {
                    MessageBox.Show("Đăng ký khách hàng mới thành công", "Thông báo");
                    return true;
                }
                else
                {
                    MessageBox.Show("Đăng ký khách hàng thất bại", "Thông báo");
                    return false;
                }
            }
            MessageBox.Show("Xuất hiện sự cố khi đăng ký khách hàng", "Thông báo");
            return false;
        }


        /// <summary>
        /// gọi kiểm tra đăng nhập xuống tầng DAL
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
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
                    kh = new KhachHang(reader.GetString(0),
                         reader.GetString(1),
                         reader.GetString(2),
                         reader.GetDateTime(3).ToString("dd/MM/yyyy"),
                         reader.GetString(4),
                         reader.GetString(5),
                         reader.GetBoolean(6),
                         reader[7] == DBNull.Value ? "null" : reader.GetString(7),
                         reader[8] == DBNull.Value ? "null" : reader.GetString(8));
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

        /// <summary>
        /// Kiểm tra xem ngày hẹn có phải chọn ngày trong quá khứ hay ngày hiện tại
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static bool isValidPickedDate(DateTime d1)
        {
            if (d1<= DateTime.Now)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra ngày sinh của người dùng phải trên 16 tuổi mới được phép đăng ký
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static bool isValidBornDate(DateTime d1)
        {
            if ( DateTime.Now.Year - d1.Year < 16)
            {
                MessageBox.Show("Khách hàng trên 16 tuổi mới được phép đăng ký", "Thông báo");
                return false;
            }
            else if (DateTime.Now.Year  - d1.Year > 120)
            {
                MessageBox.Show("Ngày sinh không hợp lệ (số tuổi >120)", "Thông báo");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Lấy mã khách hàng tiếp theo để thêm
        /// </summary>
        /// <returns></returns>
        public static string getNextID() {

            SqlDataReader reader = DAL_KhachHang.getNextID();
            int currentID = -1;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    currentID = Algorithm.myAtoi(reader.GetString(0)) + 1;
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            if (currentID < 0)
            {
                return null;
            }

            // thêm 0 trước mã ID <100
            if (currentID < 100) { return "KH0" + currentID.ToString(); }
            return "KH" + currentID.ToString();
        }

    }
}
