using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.VACCINE
{
    public class Vaccine
    {
        //attributes
        private string _maVC, _tenVC;
        private int _soLuongVC;

        //methods
        public Vaccine(string maVC, string tenVC, int soLuongVC)
        {
            _maVC = maVC;
            _tenVC = tenVC;
            _soLuongVC = soLuongVC;
        }

        public string MaVC { get => _maVC; set => _maVC = value; }
        public string TenVC { get => _tenVC; set => _tenVC = value; }
        public int SoLuongVC { get => _soLuongVC; set => _soLuongVC = value; }

    }
}
