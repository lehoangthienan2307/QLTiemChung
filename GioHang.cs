using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTK2.GOITIEMCHUNG;

namespace PTTK2
{
    public static class GioHang
    {
        public static int themGioHang(IDictionary<GoiTiemChung, int> gioHang, GoiTiemChung goiTiemChung)
        {
            int tongTien = 0;
            if (gioHang.ContainsKey(goiTiemChung))
            {
                gioHang[goiTiemChung] = gioHang[goiTiemChung] + 1;
            }
            else
            {
                gioHang.Add(goiTiemChung, 1);
            }
            for (int i = 0; i < gioHang.Count; i++)
            {
                tongTien += gioHang.ElementAt(i).Key.GiaTien * gioHang.ElementAt(i).Value;
                
            }
            return tongTien;
        }

        public static int xoaGioHang(IDictionary<GoiTiemChung, int> gioHang, GoiTiemChung goiTiemChung)
        {
            int tongTien = 0;
            if (gioHang.ContainsKey(goiTiemChung))
            {
                gioHang[goiTiemChung] = gioHang[goiTiemChung] - 1;
                if (gioHang[goiTiemChung] == 0)
                {
                    gioHang.Remove(goiTiemChung);
                }
                for (int i = 0; i < gioHang.Count; i++)
                {
                    tongTien += gioHang.ElementAt(i).Key.GiaTien * gioHang.ElementAt(i).Value;

                }
            }
            return tongTien;

        }
    }
}
