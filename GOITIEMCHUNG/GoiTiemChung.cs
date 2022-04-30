using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.GOITIEMCHUNG
{
    public class GoiTiemChung
    {
        //attributes
        private string _maGoi, _tenLoai;
        private int _giaTien;

        //methods
        public GoiTiemChung(string maGoi, string tenLoai, int giaTien)
        {
            _maGoi = maGoi;
            _tenLoai = tenLoai;
            _giaTien = giaTien;
        }

        public string MaGoi { get => _maGoi; set => _maGoi = value; }
        public string TenLoai { get => _tenLoai; set => _tenLoai = value; }
        public int GiaTien { get => _giaTien; set => _giaTien = value; }
        
    }
}
