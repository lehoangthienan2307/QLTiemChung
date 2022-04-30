using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2.TRUNGTAMTIEM  
{
    public class DAL_TrungTamTiem
    {
        /// <summary>
        /// Truy cập database để lấy thông tin trung tâm
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader getTrungTamTiem()
        {
            SqlConnector._conn.Open();
            SqlCommand command = new SqlCommand("select * from trungtam", SqlConnector._conn);

            return command.ExecuteReader();
        }
    }
}
