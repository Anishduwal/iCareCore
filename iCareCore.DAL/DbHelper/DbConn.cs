using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace iCareCore.Infrastructure.DbHelper
{
    public static class DbConn
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public static string DBANUsername { get; set; } = string.Empty;
        public static string DBANPassword { get; set; } = string.Empty;
    }

}
