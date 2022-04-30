using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.TRUNGTAMTIEM
{
    public class Bus_TrungTamTiem
    {

        /// <summary>
        /// Gọi xuống DAL để lấy kết quả truy cập database lấy thông tin trung tâm
        /// </summary>
        /// <returns></returns>
        public static List<TrungTamTiem> GetTrungTamTiem()
        {
            SqlDataReader reader = DAL_TrungTamTiem.getTrungTamTiem();
            List<TrungTamTiem> trungTamTiems = new List<TrungTamTiem>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TrungTamTiem ttt = new TrungTamTiem(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    trungTamTiems.Add(ttt);
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            return trungTamTiems;
        }
    }
}
