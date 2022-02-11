using CleanBase.Application.ProductsCQRS.Commands;
using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanBase.Application.ProductsCQRS.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductId(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Erro, produto não encontrado.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image
                    , request.CategoryId);
                return await _productRepository.Update(product);
            }
        }
    }
}
