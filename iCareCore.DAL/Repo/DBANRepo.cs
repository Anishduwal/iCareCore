using Dapper;
using iCareCore.Core.IRepo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCareCore.Infrasructure.Repo
{
    public class DBANRepo : IDBANRepo
    {
        private readonly string _connectionString;

        public DBANRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        //private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<object> GetDetails()
        {
            return 1;
        }
    }
}
