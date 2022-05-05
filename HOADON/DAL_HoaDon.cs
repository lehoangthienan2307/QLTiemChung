using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PTTK2.HOADON
{
    public class DAL_HoaDon
    {
        public static SqlDataReader getNextID()
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("select top 1 mahd from hoadon order by mahd desc", SqlConnector._conn);

            return command.ExecuteReader();
        }

        public static void insert(HoaDon hd)
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("Insert into hoadon(MaHD, LoaiHoaDon, NgayThanhToan, TongSoTien, PhuongThucThanhToan, MaPhieu) " +
                "values (@mahd, @loaiHoaDon,@ngayThanhToan,@tongTien,@phuongThuc, @maPhieu)", SqlConnector._conn);
            command.Parameters.AddWithValue("mahd", hd.MaHD);
            command.Parameters.AddWithValue("loaiHoaDon", hd.LoaiHD);
            command.Parameters.AddWithValue("ngayThanhToan", hd.NgayThanhToan);
            command.Parameters.AddWithValue("tongTien", hd.TongSoTien);
            command.Parameters.AddWithValue("phuongThuc", "Chuyển khoản");
            command.Parameters.AddWithValue("maPhieu", hd.MaPhieu);
            int row = command.ExecuteNonQuery();
           
            SqlConnector._conn.Close();
            
        }
    }
}
