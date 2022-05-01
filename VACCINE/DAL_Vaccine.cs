using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTK2.CHITIETGOI;
using System.Data.SqlClient;

namespace PTTK2.VACCINE
{
    public class DAL_Vaccine
    {
        public static SqlDataReader getVaccine(List<ChiTietGoi> chiTietGoi)
        {
            SqlConnector._conn.Open();
            SqlCommand command = new SqlCommand("Select * from VACCINE where MaVC in " + "(select MaVC from CHITIETGOI where MaGoi =  " + "'" + chiTietGoi[0].MaGoi + "'" + ")", SqlConnector._conn);

            return command.ExecuteReader();
        }
    }
}
