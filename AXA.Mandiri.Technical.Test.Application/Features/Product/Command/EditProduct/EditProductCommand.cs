using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Command.EditProduct
{
    public class EditProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
