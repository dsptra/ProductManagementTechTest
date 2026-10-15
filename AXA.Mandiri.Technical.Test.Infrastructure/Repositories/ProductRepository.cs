using AXA.Mandiri.Technical.Test.Application.Contracts;
using AXA.Mandiri.Technical.Test.Domain.Entities;
using AXA.Mandiri.Technical.Test.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace AXA.Mandiri.Technical.Test.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(TestContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> SearchAsync(string? name, decimal? minPrice, decimal? maxPrice, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
