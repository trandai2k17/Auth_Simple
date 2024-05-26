using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository <T> where T : class
    {
        //IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        //T GetFirstOrDefault(Expression<Func<T, bool>>? filter, string? includeProperties = null);
        //void Add(T entity);
        //bool Any(Expression<Func<T, bool>> filter);
        //void Remove(T entity);

        Task<List<T>> GetListAsync(string query, DynamicParameters parameters, CommandType commandType = CommandType.Text);
        Task<IEnumerable<T>> GetIEnumerableAsync(string query, DynamicParameters parameters, CommandType commandType = CommandType.Text);
        //Task<int> CreateAsync(T entity);
        //Task<int> UpdateAsync(T entity);
        //Task<int> DeleteAsync(T entity);

        //Task CreateData(string query, DynamicParameters parameters);
        //Task DeleteData(string query, int id);
        //Task<T> GetDataById<T>(string query, int id);
        //Task<IEnumerable<T>> GetData<T>(string SQL);
        //Task UpdateData(string query, DynamicParameters parameters);
    }
}
