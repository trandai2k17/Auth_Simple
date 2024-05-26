using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDapperHelper
    {
        void ExecuteNoReturn(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text);
        Task ExecuteNoReturnAsync(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text);
        //Task<T> ExecuteQueryFirst<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        T ExecuteQueryFirst<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        Task<T> ExecuteQueryFirstAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        Task<IEnumerable<T>> ExecuteQueryIEnumerableAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        Task<List<T>> ExecuteQueryListAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        Task<T> ExecuteScalarAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text);


        //Task<IEnumerable<T>> ExecuteQuerySql<T>(string sql, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        //Task<IEnumerable<T>> ExecuteQuerySqlAsync<T>(string sql, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        //Task<IEnumerable<T>> ExecuteStoreProcedure<T>(string sql, DynamicParameters? parameters = null, CommandType commandType = CommandType.StoredProcedure);
        //Task<IEnumerable<T>> ExecuteStoreProcedureAsync<T>(string sql, DynamicParameters? parameters = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
