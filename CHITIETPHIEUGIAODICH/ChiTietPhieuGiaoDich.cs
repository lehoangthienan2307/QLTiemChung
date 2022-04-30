using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.CHITIETPHIEUGIAODICH
{
    public class ChiTietPhieuGiaoDich
    {
        //attributes
        private string _maPhieu, _MaGoi;
        private int _soLuong;

        //methods
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="maPhieu"></param>
        /// <param name="maGoi"></param>
        /// <param name="soLuong"></param>
        public ChiTietPhieuGiaoDich(string maPhieu, string maGoi, int soLuong)
        {
            MaPhieu = maPhieu;
            MaGoi = maGoi;
            SoLuong = soLuong;
        }

        public string MaPhieu { get => _maPhieu; set => _maPhieu = value; }
        public string MaGoi { get => _MaGoi; set => _MaGoi = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
    }
}
