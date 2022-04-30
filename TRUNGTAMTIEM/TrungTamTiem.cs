using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.TRUNGTAMTIEM
{
    public class TrungTamTiem
    {
        //attributes
        private string _maTT, _tenTT, _diaChi;

        // methods
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="maTT"></param>
        /// <param name="tenTT"></param>
        /// <param name="diaChi"></param>
        public TrungTamTiem(string maTT, string tenTT, string diaChi)
        {
            _maTT = maTT;
            _tenTT = tenTT;
            _diaChi = diaChi;
        }

        public string MaTT { get => _maTT; set => _maTT = value; }
        public string TenTT { get => _tenTT; set => _tenTT = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
    }
}
