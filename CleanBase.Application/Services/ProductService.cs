using AutoMapper;
using CleanBase.Application.DTOs;
using CleanBase.Application.Interfaces;
using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetProductId(int? id)
        {
            var productEntity = await _productRepository.GetProductId(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = await _productRepository.GetProductCategory(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Create(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _productRepository.Create(productEntity);
        }

        public async Task Update(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _productRepository.Update(productEntity);
        }

        public async Task Delete(int? id)
        {
            var productEntity = _productRepository.GetProductId(id).Result;
            await _productRepository.Delete(productEntity);
        }
    }
}
