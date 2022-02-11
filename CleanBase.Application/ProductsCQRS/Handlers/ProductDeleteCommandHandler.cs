using CleanBase.Application.ProductsCQRS.Commands;
using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanBase.Application.ProductsCQRS.Handlers
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductId(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Erro, produto não encontrado.");
            }
            else
            {
                var result = await _productRepository.Delete(product);
                return result;
            }
        }
    }
}
