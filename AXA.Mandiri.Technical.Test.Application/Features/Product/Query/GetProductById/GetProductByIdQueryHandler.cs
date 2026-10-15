using AXA.Mandiri.Technical.Test.Application.Contracts;
using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Query.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
        }
    }
}
