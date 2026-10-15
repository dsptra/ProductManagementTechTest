using AXA.Mandiri.Technical.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Application.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> SearchAsync(string? name, decimal? minPrice, decimal? maxPrice, CancellationToken cancellationToken = default);
    }
}
