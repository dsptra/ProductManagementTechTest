using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Query.GetProductById
{
    public class GetProductByIdQuery : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
    }
}
