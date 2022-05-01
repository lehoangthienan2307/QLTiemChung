using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.CHITIETGOI
{
    public class ChiTietGoi
    {
        //attributes
        private string _maVC, _MaGoi;
        private int _soLuongGoi;

        //methods
        public ChiTietGoi(string maVC, string maGoi, int soLuongGoi)
        {
            MaVC = maVC;
            MaGoi = maGoi;
            SoLuongGoi = soLuongGoi;
        }
        public string MaVC { get => _maVC; set => _maVC = value; }
        public string MaGoi { get => _MaGoi; set => _MaGoi = value; }
        public int SoLuongGoi { get => _soLuongGoi; set => _soLuongGoi = value; }
    }
}
