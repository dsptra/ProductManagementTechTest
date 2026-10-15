using AXA.Mandiri.Technical.Test.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> where TEntity : class
    {
        protected readonly TestContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(TestContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task<TEntity> EditAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task DeleteAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync([id], cancellationToken);
        }
    }
}
