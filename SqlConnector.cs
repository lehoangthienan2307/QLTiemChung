using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK2
{
    public static class SqlConnector
    {
        // edit your server name & saPass here
        private static string _saPass = "kashima";
        private static string _serverName = "NMKHA";
        ///////////////////////////////////////////

        static string connectionStr = "Data Source = " + _serverName + ";Initial Catalog = DB_PTTK; User ID = sa; Password = " + _saPass;
        public static SqlConnection _conn = new SqlConnection(connectionStr);
    }
}
