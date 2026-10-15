using AXA.Mandiri.Technical.Test.Application.Contracts;
using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Query.SearchProduct
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IProductRepository _productRepository;

        public SearchProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.SearchAsync(request.Name, request.MinPrice, request.MaxPrice, cancellationToken);
        }
    }
}
