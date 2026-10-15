using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Application.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> EditAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }

}
