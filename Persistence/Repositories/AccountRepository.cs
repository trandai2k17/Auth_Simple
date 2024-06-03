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
            string query = @"SELECT U.EmployeeID, U.EmplName, U.UserName, U.NormalizedUserName, U.NormalizedEmail, U.Email FROM MyDB1021.dbo.Web_User U
OUTER APPLY (SELECT * FROM MyDB1021.dbo.HR_Employee WHERE U.EmployeeID=EmployeeID ) H ";
            return await dapper.ExecuteQueryListAsync<SYSUserTable>(query, null, CommandType.Text);
        }

    }
}
