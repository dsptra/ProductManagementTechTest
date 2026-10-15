using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
