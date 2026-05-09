using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
namespace ADOPZ.DataAccess.Interface
{
    internal interface IEfRepository<T> : IRepositoryBase<T> where T : class
    {
        Task BeginTransactionAsync();
        Task CommitTAsync();
        Task RollbackTAsync();
    }
}
