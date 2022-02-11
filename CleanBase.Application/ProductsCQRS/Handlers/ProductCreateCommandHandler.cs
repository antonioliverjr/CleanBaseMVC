using CleanBase.Application.ProductsCQRS.Commands;
using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanBase.Application.ProductsCQRS.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);
            if (product == null)
            {
                throw new ApplicationException("Erro ao criar Entidade");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.Create(product);
            }
        }
    }
}
