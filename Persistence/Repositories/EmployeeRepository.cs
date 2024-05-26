using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDapperHelper _dapper;
        public EmployeeRepository(IDapperHelper dapper)
        {
            _dapper = dapper;
        }
        public async Task<List<Employee>> EmployeesAsync()
        {
            string query = @"SELECT * FROM [MyDB1021].[dbo].[HR_Employee]";
            return await _dapper.ExecuteQueryListAsync<Employee>(query, null, CommandType.Text);
        }
    }
}
