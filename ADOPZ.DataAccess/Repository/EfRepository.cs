using ADOPZ.DataAccess.Interface;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ADOPZ.DataAccess.Repository
{
    public class IEfRepository<T> : RepositoryBase<T>, Interface.IEfRepository<T> where T : class
    {
       private readonly QuotationsDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public IEfRepository(QuotationsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        

        public async Task BeginTransactionAsync()
        {
            if(_transaction != null)
            {
                _transaction = await DbContext.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTAsync()
        {
           if( _transaction == null)
            {
                return;
            }
           await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            await _dbContext.SaveChangesAsync();
            _transaction = null;
        }

        public async Task RollbackTAsync()
        {
            if (_transaction == null)
            {
                return;
            }
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    internal class QuotationsDbContext
    {
        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
