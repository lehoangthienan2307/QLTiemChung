using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.PHIEUGIAODICH
{
    public class PhieuGiaoDich
    {
        //attributes
        private string _maPhieu, _loaiPhieu, _trangThai, _ngayTiem, _maKH;

        public PhieuGiaoDich(string maPhieu, string loaiPhieu, string trangThai, string ngayTiem, string maKH)
        {
            MaPhieu = maPhieu;
            LoaiPhieu = loaiPhieu;
            TrangThai = trangThai;
            NgayTiem = ngayTiem;
            MaKH = maKH;
        }

        public string MaPhieu { get => _maPhieu; set => _maPhieu = value; }
        public string LoaiPhieu { get => _loaiPhieu; set => _loaiPhieu = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
        public string NgayTiem { get => _ngayTiem; set => _ngayTiem = value; }
        public string MaKH { get => _maKH; set => _maKH = value; }
    }
}
