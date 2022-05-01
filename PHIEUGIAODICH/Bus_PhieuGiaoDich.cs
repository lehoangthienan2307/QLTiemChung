using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTK2.TRUNGTAMTIEM;
using PTTK2.KHACHHANG;
using PTTK2.GOITIEMCHUNG;
using System.Data.SqlClient;

namespace PTTK2.PHIEUGIAODICH
{
    public class Bus_PhieuGiaoDich
    {
        /// <summary>
        /// Nhận dữ liệu từ tầng GUI và xử lí ở tầng nghiệp vụ
        /// Xử lí logic để gọi xuống tầng DAL thêm vào Database
        /// Trả kết quả string là null nếu đăng ký phiếu thất bại
        /// Trả kết quả là mã phiếu mới nhất được thêm vào
        /// </summary>
        /// <param name="ttt"></param>
        /// <param name="datePicked"></param>
        /// <param name="checkedListBox"></param>
        public static string insert(TrungTamTiem ttt, DateTime datePicked, string maKh)
        {
            if (!Bus_KhachHang.isValidPickedDate(datePicked))
            {
                MessageBox.Show("Ngày chọn không hợp lệ","Alert");
                return null;
            }

            string nextID = getNextID();

            PhieuGiaoDich ph = new PhieuGiaoDich(nextID, "Tiêm", "Chưa thanh toán",datePicked.ToString("MM/dd/yyyy"),maKh);

            string result = DAL_PhieuGiaoDich.insert(ph);
            if(result== null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public static string insertDatMua(IDictionary<GoiTiemChung, int> gioHang, string maKh)
        {

            if (gioHang.Count == 0)
            {
                return null;
            }
            else
            {
                string nextID = getNextID();

                PhieuGiaoDich ph = new PhieuGiaoDich(nextID, "Đặt mua", "Chưa thanh toán", "", maKh);

                string result = DAL_PhieuGiaoDich.insertDatMua(ph);
                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// Truy cập tầng DAL để lấy mã phiếu cuối cùng trong bảng phiếu giao dịch
        /// </summary>
        /// <returns></returns>
        public static string getNextID()
        {
            SqlDataReader reader = DAL_PhieuGiaoDich.getNextID();
            int currentID = -1;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    currentID = Algorithm.myAtoi(reader.GetString(0))+1;
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            if (currentID < 0)
            {
                return null;
            }

            // thêm 0 trước mã ID <100
            if (currentID < 100) { return "PGD0" + currentID.ToString(); }
            return "PGD"+ currentID.ToString();
        }
    }
}
