using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using System.Threading.Tasks;

namespace PTTK2.GOITIEMCHUNG
{
    public class DAL_GoiTiemChung
    {
        public static SqlDataReader getGoiTiemChung()
        {
            SqlConnector._conn.Open();
            
            SqlCommand command = new SqlCommand("Select * from GOITIEMCHUNG",SqlConnector._conn);

            return command.ExecuteReader(); 
        }
    }
}
