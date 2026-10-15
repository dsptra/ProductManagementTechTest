using AXA.Mandiri.Technical.Test.Application.Contracts;
using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Command.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreatedAt = DateTime.UtcNow
            };

            await _productRepository.AddAsync(product, cancellationToken);
            return product.Id;
        }
    }
}
