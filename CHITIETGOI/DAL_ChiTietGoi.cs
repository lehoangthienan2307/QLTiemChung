using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTK2.GOITIEMCHUNG;
using System.Data.SqlClient;

namespace PTTK2.CHITIETGOI
{
    public class DAL_ChiTietGoi
    {
        public static SqlDataReader getChiTietGoi(GoiTiemChung goiTiemChung)
        {
            SqlConnector._conn.Open();

            SqlCommand command = new SqlCommand("Select * from CHITIETGOI where MaGoi = " + "'" + goiTiemChung.MaGoi + "'", SqlConnector._conn);

            return command.ExecuteReader();
        }
    }
}
