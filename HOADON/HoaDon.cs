using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.HOADON
{
    //attributes
    
    public class HoaDon
    {
        private string _maHD, _loaiHD, _tongSoTien, _ngayThanhToan, _maBS, _maPhieu;
        public HoaDon(string _maHD, string _loaiHD, string _ngayThanhToan, string _tongSoTien, string _maBS, string _maPhieu)
        {
            MaHD = _maHD;
            LoaiHD = _loaiHD;
            NgayThanhToan = _ngayThanhToan;
            TongSoTien = _tongSoTien;
            MaBS = _maBS;
            MaPhieu = _maPhieu;
        }

        public string MaHD { get => _maHD; set => _maHD = value; }
        public string LoaiHD { get => _loaiHD; set => _loaiHD = value; }
        public string TongSoTien { get => _tongSoTien; set => _tongSoTien = value; }
        public string NgayThanhToan { get => _ngayThanhToan; set => _ngayThanhToan = value; }
        public string MaBS { get => _maBS; set => _maBS = value; }

        public string MaPhieu { get => _maPhieu; set => _maPhieu = value; }
    }


}
