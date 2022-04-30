using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PTTK2.GOITIEMCHUNG
{
    public class Bus_GoiTiemChung
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<GoiTiemChung> getGoiTiemChung()
        {
            List<GoiTiemChung> goiTiemChung = new List<GoiTiemChung>();
            SqlDataReader reader = DAL_GoiTiemChung.getGoiTiemChung();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    GoiTiemChung gtc = new GoiTiemChung(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                    goiTiemChung.Add(gtc);
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            return goiTiemChung;
        }
    }
}
