using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTK2.GOITIEMCHUNG;
using System.Data.SqlClient;

namespace PTTK2.CHITIETGOI
{
    public class Bus_ChiTietGoi
    {
        public static List<ChiTietGoi> getChiTietGoi(GoiTiemChung goiTiemChung)
        {
            List<ChiTietGoi> chiTietGoi = new List<ChiTietGoi>();
            SqlDataReader reader = DAL_ChiTietGoi.getChiTietGoi(goiTiemChung);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ChiTietGoi gtc = new ChiTietGoi(reader.GetString(1), reader.GetString(0), reader.GetInt32(2));
                    chiTietGoi.Add(gtc);
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            return chiTietGoi;
        }
    }
}
