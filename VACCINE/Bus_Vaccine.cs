using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTK2.CHITIETGOI;
using System.Data.SqlClient;

namespace PTTK2.VACCINE
{
    public class Bus_Vaccine
    {

        public static List<Vaccine> getVaccine(List<ChiTietGoi> chiTietGoi)
        {
            List<Vaccine> vaccine = new List<Vaccine>();
            SqlDataReader reader = DAL_Vaccine.getVaccine(chiTietGoi);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Vaccine vc = new Vaccine(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                    vaccine.Add(vc);
                }
            }
            reader.Close();
            SqlConnector._conn.Close();
            return vaccine;
        }
    }
}
