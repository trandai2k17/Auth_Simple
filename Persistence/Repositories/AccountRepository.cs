using Application.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DapperContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDapperHelper dapper;
        public AccountRepository(IDapperHelper dapper) {
            this.dapper = dapper;
        }

        public async Task<List<SYSUserTable>> AccountsAsync()
        {

            string query = @"SELECT * FROM [MyDB1021].[dbo].[HR_Employee]";
            return await dapper.ExecuteQueryListAsync<SYSUserTable>(query, null, CommandType.Text);

        }

    }
}
