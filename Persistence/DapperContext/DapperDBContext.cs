using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Persistence.DapperContext
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectStr;

        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectStr = configuration.GetConnectionString("AppConn");
        }

        public IDbConnection Connection() => new SqlConnection(_connectStr);

        
    }
}
