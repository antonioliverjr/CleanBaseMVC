using AutoMapper;
using CleanBase.Application.DTOs;
using CleanBase.Application.Interfaces;
using CleanBase.Application.ProductsCQRS.Commands;
using CleanBase.Application.ProductsCQRS.Querys;
//using CleanBase.Domain.Entities;
//using CleanBase.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.Application.Services
{
    public class ProductService : IProductService
    {
        // ALTERANDO COMPORTAMENTO DA CLASSE PARA UTILIZAÇÃO DO MEDIATOR
        //private IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(/*IProductRepository productRepository*/ IMediator mediator, IMapper mapper)
        {
            //_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            //var productsEntity = await _productRepository.GetProducts();
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
            {
                throw new Exception("Entidade não carregada.");
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(/*productsEntity*/ result);
        }

        public async Task<ProductDTO> GetProductId(int? id)
        {
            //var productEntity = await _productRepository.GetProductId(id);
            var productQuery = new GetProductIdQuery(id.Value);
            if (productQuery == null)
            {
                throw new Exception("Entidade não carregada.");
            }
            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    //var productEntity = await _productRepository.GetProductCategory(id);
        //    var productQuery = new GetProductIdQuery(id.Value);
        //    if (productQuery == null)
        //    {
        //        throw new Exception("Entidade não carregada.");
        //    }
        //    var result = await _mediator.Send(productQuery);
        //    return _mapper.Map<ProductDTO>(productQuery);
        //}

        public async Task Create(ProductDTO product)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(product);
            //await _productRepository.Create(productEntity);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO product)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);
            //await _productRepository.Update(productEntity);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            //var productEntity = _productRepository.GetProductId(id).Result;
            //await _productRepository.Delete(productEntity);
            var productDeleteCommand = new ProductDeleteCommand(id.Value);
            if (productDeleteCommand == null)
            {
                throw new Exception("Entidade não carregada.");
            }
            await _mediator.Send(productDeleteCommand);
        }
    }
}
