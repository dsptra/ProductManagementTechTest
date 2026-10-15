using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Command.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
