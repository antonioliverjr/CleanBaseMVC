using CleanBase.Application.ProductsCQRS.Querys;
using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanBase.Application.ProductsCQRS.Handlers
{
    public class GetProductIdQueryHandler : IRequestHandler<GetProductIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductId(request.Id);
        }
    }
}
