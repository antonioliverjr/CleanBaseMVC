using CleanBase.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductId(int? id);
        Task<Product> GetProductCategory(int? id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(Product product);
    }
}
