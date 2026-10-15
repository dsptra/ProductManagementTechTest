using AXA.Mandiri.Technical.Test.Application.Contracts;
using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

            await _productRepository.DeleteAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
