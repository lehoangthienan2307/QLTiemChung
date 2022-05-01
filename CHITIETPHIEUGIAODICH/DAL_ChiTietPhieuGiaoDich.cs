using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace PTTK2.CHITIETPHIEUGIAODICH
{
    public class DAL_ChiTietPhieuGiaoDich
    {
        /// <summary>
        /// Hàm overload để thêm list của các chi tiết giao dịch
        /// </summary>
        /// <param name="chiTietPhieuGiaoDichList"></param>
        public static void insert(List<ChiTietPhieuGiaoDich> chiTietPhieuGiaoDichList)
        {
            SqlConnector._conn.Open();

            SqlCommand command;

            foreach(ChiTietPhieuGiaoDich ch in chiTietPhieuGiaoDichList)
            {
                insert(ch);
            }
            SqlConnector._conn.Close();
        }


        /// <summary>
        /// Hàm thêm 1 chi tiết giao dịch
        /// </summary>
        /// <param name="chiTietPhieuGiaoDich"></param>
        public static void insert(ChiTietPhieuGiaoDich chiTietPhieuGiaoDich)
        {
            SqlCommand command = new SqlCommand("insert into chitietphieugiaodich values (@maPhieu,@maGoi,@soLuong)",SqlConnector._conn);
            command.Parameters.AddWithValue("maPhieu",chiTietPhieuGiaoDich.MaPhieu);
            command.Parameters.AddWithValue("maGoi",chiTietPhieuGiaoDich.MaGoi);
            command.Parameters.AddWithValue("soLuong",chiTietPhieuGiaoDich.SoLuong);

            int row = command.ExecuteNonQuery();
            if (row < 0)
            {
                MessageBox.Show("Thêm chi tiết phiếu với gói vaccine " + chiTietPhieuGiaoDich.MaGoi + " thất bại!", "Thông báo");
            }
        }

        public static void getChiTietPhieuGiaoDichTT(string maPhieu, ref DataTable dt)
        {
            SqlConnector._conn.Open();

            SqlCommand query = new SqlCommand("select ct.MaGoi, gtc.LoaiGoiTiemChung, ct.SoLuongGoi, ct.SoLuongGoi * gtc.TongTienGoi as TongTien from CHITIETPHIEUGIAODICH ct join GOITIEMCHUNG gtc on ct.MaGoi = gtc.MaGoi where ct.MaPhieu = @maPhieu"
                                , SqlConnector._conn);
            query.Parameters.AddWithValue("maPhieu", maPhieu);

            SqlDataAdapter adapter = new SqlDataAdapter(query);
            adapter.Fill(dt);
            SqlConnector._conn.Close();
        }
    }
}
