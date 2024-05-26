using Application.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDapperHelper _helper;
        public Repository(IDapperHelper helper) {
            _helper = helper;
        }

        public async Task<IEnumerable<T>> GetIEnumerableAsync(string query, DynamicParameters parameters, CommandType commandType = CommandType.Text)
        {
            return await _helper.ExecuteQueryIEnumerableAsync<T>(query, parameters, commandType);
        }

        public async Task<List<T>> GetListAsync(string query, DynamicParameters parameters, CommandType commandType = CommandType.Text)
        {
            return await _helper.ExecuteQueryListAsync<T>(query, parameters, commandType);
        }
    }
}
