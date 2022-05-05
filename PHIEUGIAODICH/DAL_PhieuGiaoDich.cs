using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.PHIEUGIAODICH
{
    public class DAL_PhieuGiaoDich
    {
        /// <summary>
        /// Nhận object PhieuGiaoDich từ tầng Business và giao tiếp với Database để thêm thông tin mới vào bảng Phiếu giao dịch
        /// </summary>
        /// <param name="pgd"></param>
        public static string insert(PhieuGiaoDich pgd)
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("Insert into phieugiaodich values (@maPGH, @loaiPhieu,@trangThai,@ngayTiem,@maKH)", SqlConnector._conn);
            command.Parameters.AddWithValue("maPGH", pgd.MaPhieu);
            command.Parameters.AddWithValue("loaiPhieu", pgd.LoaiPhieu);
            command.Parameters.AddWithValue("trangThai", pgd.TrangThai);
            command.Parameters.AddWithValue("ngayTiem", pgd.NgayTiem);
            command.Parameters.AddWithValue("maKH", pgd.MaKH);
            int row = command.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Đăng ký phiếu tiêm thành công", "Alert");
                SqlConnector._conn.Close();
                return pgd.MaPhieu;
            }
            SqlConnector._conn.Close();
            return null;
        }

        public static string insertDatMua(PhieuGiaoDich pgd)
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("insert into phieugiaodich(MaPhieu, LoaiPhieu, TrangThai, MaKH) values (@maPGH, @loaiPhieu,@trangThai,@maKH)", SqlConnector._conn);
            command.Parameters.AddWithValue("maPGH", pgd.MaPhieu);
            command.Parameters.AddWithValue("loaiPhieu", pgd.LoaiPhieu);
            command.Parameters.AddWithValue("trangThai", pgd.TrangThai);
            command.Parameters.AddWithValue("maKH", pgd.MaKH);
            int row = command.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Đặt mua thành công", "Alert");
                SqlConnector._conn.Close();
                return pgd.MaPhieu;
            }
            SqlConnector._conn.Close();
            return null;
        }

        public static SqlDataReader getPhieuGiaoDich(string maKH)
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("Select * from PHIEUGIAODICH where MaKH = " + "'" + maKH + "'" + " and (TrangThai like N'Chưa thanh toán' or TrangThai like N'Trả góp')", SqlConnector._conn);

            return command.ExecuteReader();
        }

        public static void updateTrangThai(string maPhieu)
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("update PHIEUGIAODICH set TrangThai = 'Đã thanh toán' where MaPhieu = " + "'" + maPhieu + "'" , SqlConnector._conn);
            int row = command.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Thanh toán thành công", "Alert");
               
                
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại", "Alert");
            }    
            SqlConnector._conn.Close();
            
        }

        /// <summary>
        /// Lấy mã phiếu giao dịch tiếp theo mới nhất
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader getNextID()
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("select top 1 maphieu from phieugiaodich order by maphieu desc", SqlConnector._conn) ;

            return command.ExecuteReader();
        }
    }
}
