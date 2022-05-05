using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PTTK2.PHIEUGIAODICH;

namespace PTTK2.HOADON
{
    public class Bus_HoaDon
    {
        public static void insert(string tongTien, PhieuGiaoDich phieu)
        {
            

            string nextID = getNextID();
            string date = DateTime.Now.ToString("M/d/yyyy");
            HoaDon hd = new HoaDon(nextID, phieu.LoaiPhieu, date, tongTien, "", phieu.MaPhieu);

            DAL_HoaDon.insert(hd);
           
        }
        public static string getNextID()
        {
            SqlDataReader reader = DAL_HoaDon.getNextID();
            int currentID = -1;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    currentID = Algorithm.myAtoi(reader.GetString(0)) + 1;
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            if (currentID < 0)
            {
                return null;
            }

            // thêm 0 trước mã ID <100
            if (currentID < 100) { return "HD0" + currentID.ToString(); }
            return "HD" + currentID.ToString();
        }
    }
}
