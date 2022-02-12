using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using CleanBase.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> Create(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        //public async Task<Product> GetProductCategory(int? id)
        //{
        //    return await _productContext.Products.Include(x => x.Category).SingleOrDefaultAsync(p => p.CategoryId == id);
        //}

        public async Task<Product> GetProductId(int? id)
        {
            //return await _productContext.Products.FindAsync(id);
            return await _productContext.Products.Include(x => x.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> Update(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
