using MediatR;

namespace AXA.Mandiri.Technical.Test.Application.Features.Product.Query.SearchProduct
{
    public class SearchProductQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
