using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTK2.GOITIEMCHUNG;
using System.Data;

namespace PTTK2.CHITIETPHIEUGIAODICH
{
    public class Bus_ChiTietPhieuGiaoDich
    {
        /// <summary>
        /// Thêm chi tiết phiếu giao dịch, xử lí trả ra List các object chi tiết phiếu giao dịch
        /// Sau đó gọi xuống tầng DAL để thêm vào database
        /// </summary>
        /// <param name="checkedListBox"></param>
        /// <param name="gtc"></param>
        /// <param name="maKH"></param>
        /// <param name="maPhieu"></param>
        public static void insert(CheckedListBox checkedListBox, List<GoiTiemChung> gtc, string maKH,string maPhieu)
        {
            List<ChiTietPhieuGiaoDich> ctpgdList = new List<ChiTietPhieuGiaoDich>();

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemChecked(i) == true)
                {
                    ChiTietPhieuGiaoDich chiTietPhieuGiaoDich = new ChiTietPhieuGiaoDich(
                                                                    maPhieu, gtc[i].MaGoi, 1
                                                                    );
                    ctpgdList.Add(chiTietPhieuGiaoDich);
                }
            }


            // gọi tầng DAL để thêm vào database
            DAL_ChiTietPhieuGiaoDich.insert(ctpgdList);
        }

        public static void insertDatMua(IDictionary<GoiTiemChung, int> gioHang, string maKH, string maPhieu)
        {
            List<ChiTietPhieuGiaoDich> ctpgdList = new List<ChiTietPhieuGiaoDich>();

            for (int i = 0; i < gioHang.Count; i++)
            {
                
                ChiTietPhieuGiaoDich chiTietPhieuGiaoDich = new ChiTietPhieuGiaoDich(
                                                                    maPhieu, gioHang.ElementAt(i).Key.MaGoi, gioHang.ElementAt(i).Value
                                                                    );
                ctpgdList.Add(chiTietPhieuGiaoDich);
                
            }


            // gọi tầng DAL để thêm vào database
            DAL_ChiTietPhieuGiaoDich.insert(ctpgdList);
        }

        public static DataTable getChiTietPhieuGiaoDichTT(string maPhieu)
        {
            DataTable dt = new DataTable();
            DAL_ChiTietPhieuGiaoDich.getChiTietPhieuGiaoDichTT(maPhieu, ref dt);
            return dt;
        }

        public static int tinhTongTien(DataTable dt)
        {
            int sum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sum += (int)dt.Rows[i][3];
            }
            return sum;
        }
    }
}
