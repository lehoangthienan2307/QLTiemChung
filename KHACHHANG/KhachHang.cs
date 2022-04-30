using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.KHACHHANG
{
    public class KhachHang
    {
        //attributes
        private string _maKH;
        private string _hoTen;
        private string _gioiTinh;
        private string _diaChi;
        private string _ngaySinh;
        private string _SDTKH;
        private bool _treEm;
        private string _maNGH;
        private string _quanHe;

        //methods
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="maKH"></param>
        /// <param name="hoTen"></param>
        /// <param name="gioiTinh"></param>
        /// <param name="diaChi"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="sDTKH"></param>
        /// <param name="treEm"></param>
        /// <param name="maNGH"></param>
        /// <param name="quanHe"></param>
        public KhachHang(string maKH, string hoTen, string gioiTinh,  string ngaySinh, string sDTKH, string diaChi, bool treEm, string maNGH, string quanHe)
        {
            _maKH = maKH;
            _hoTen = hoTen;
            _gioiTinh = gioiTinh;
            _diaChi = diaChi;
            _ngaySinh = ngaySinh;
            _SDTKH = sDTKH;
            _treEm = treEm;
            _maNGH = maNGH;
            _quanHe = quanHe;
        }

        //encapsulate field
        public string MaKH { get => _maKH; set => _maKH = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string SDTKH { get => _SDTKH; set => _SDTKH = value; }
        public bool TreEm { get => _treEm; set => _treEm = value; }
        public string MaNGH { get => _maNGH; set => _maNGH = value; }
        public string QuanHe { get => _quanHe; set => _quanHe = value; }
    }
}
