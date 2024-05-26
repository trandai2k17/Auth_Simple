using Application.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Persistence.DapperContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class DapperHelper : IDapperHelper
    {
        private readonly string _connectStr = string.Empty;
        public DapperHelper(IConfiguration configuration) {
            _connectStr = configuration.GetConnectionString("AppConn");
        }

        public void ExecuteNoReturn(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text)
        {
            using (var dbConnection = new SqlConnection(_connectStr))
            {
                dbConnection.Execute(query, parameters, commandType: commandTypes);
            }
        }
        public async Task ExecuteNoReturnAsync(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text)
        {
            using (var dbConnection = new SqlConnection(_connectStr))
            {
                await dbConnection.ExecuteAsync(query, parameters, commandType: commandTypes);
            }
        }

        public async Task<IEnumerable<T>> ExecuteQueryIEnumerableAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text)
        {
            using(var dbConnection = new SqlConnection(_connectStr))
            {
                return await dbConnection.QueryAsync<T>(query, parameters, commandType: commandType);
            }    
        }

        public async Task<List<T>> ExecuteQueryListAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text)
        {
            using (var dbConnection = new SqlConnection(_connectStr))
            {
                return (List<T>) await dbConnection.QueryAsync<T>(query, parameters, commandType: commandType);
            }
        }

        public async Task<T> ExecuteQueryFirstAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text)
        {
            using (var dbConnection = new SqlConnection(_connectStr))
            {
                var result = await dbConnection.QueryFirstOrDefaultAsync<T>(query, parameters, commandType: commandType);
                return result;
            }
        }

        

        public T ExecuteQueryFirst<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text)
        {
            using (var dbConnection = new SqlConnection(_connectStr))
            {
                return dbConnection.QueryFirstOrDefault<T>(query, parameters, commandType: commandType);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text)
        {
            using (var dbConnection = new SqlConnection(_connectStr))
            {
                var result = await dbConnection.ExecuteScalarAsync(query,parameters,commandType: commandTypes);
                if(Convert.IsDBNull(result) || result == null)
                {
                    return default(T);
                }    
                return (T)Convert.ChangeType(result, typeof(T));
            }
        }
    }
}
