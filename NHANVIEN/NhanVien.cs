using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.NHANVIEN
{
    public class NhanVien
    {
        //attributes
        private string _maNV, _hoTen, _bangCap, _diaChi, _email;
        private int _luong;
        private string _ngaySinh, _SDT, _trungTamLamViec, _ViTri;
        private int _soNamKinhNghiem;
        private string _tenTrungTamLamViec;

        //methods
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="maNV"></param>
        /// <param name="hoTen"></param>
        /// <param name="bangCap"></param>
        /// <param name="diaChi"></param>
        /// <param name="email"></param>
        /// <param name="luong"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="sDT"></param>
        /// <param name="trungTamLamViec"></param>
        /// <param name="viTri"></param>
        /// <param name="soNamKinhNghiem"></param>
        /// <param name="tenTrungTamLamViec"></param>
        public NhanVien(string maNV, string hoTen, string bangCap, string diaChi,
            string email, int luong, string ngaySinh, string sDT, string trungTamLamViec,
            string viTri, int soNamKinhNghiem, string tenTrungTamLamViec)
        {
            MaNV = maNV;
            HoTen = hoTen;
            BangCap = bangCap;
            DiaChi = diaChi;
            Email = email;
            Luong = luong;
            NgaySinh = ngaySinh;
            SDT = sDT;
            TrungTamLamViec = trungTamLamViec;
            ViTri = viTri;
            SoNamKinhNghiem = soNamKinhNghiem;
            TenTrungTamLamViec = tenTrungTamLamViec;
        }

        public string MaNV { get => _maNV; set => _maNV = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public string BangCap { get => _bangCap; set => _bangCap = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string Email { get => _email; set => _email = value; }
        public int Luong { get => _luong; set => _luong = value; }
        public string NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string TrungTamLamViec { get => _trungTamLamViec; set => _trungTamLamViec = value; }
        public string ViTri { get => _ViTri; set => _ViTri = value; }
        public int SoNamKinhNghiem { get => _soNamKinhNghiem; set => _soNamKinhNghiem = value; }
        public string TenTrungTamLamViec { get => _tenTrungTamLamViec; set => _tenTrungTamLamViec = value; }

    }
}
