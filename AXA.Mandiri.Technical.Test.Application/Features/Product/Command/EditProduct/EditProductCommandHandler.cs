using AXA.Mandiri.Technical.Test.Application.Contracts;
using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Command.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public EditProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            await _productRepository.EditAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
