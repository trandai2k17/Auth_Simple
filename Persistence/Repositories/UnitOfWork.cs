using Application.Interfaces;
using Domain.Entities;
using Persistence.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDapperHelper _helper;
        public UnitOfWork(IDapperHelper helper)
        {
            _helper = helper;
        }

        IEmployeeRepository _employeeRepository;
        IAccountRepository _AccountRepo;
        private bool disposedValue;

        public IEmployeeRepository EmployeeRepository { get { return _employeeRepository ??= new EmployeeRepository(_helper); } }
        public IAccountRepository AccountRepo { get { return _AccountRepo ??= new AccountRepository(_helper); } }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
