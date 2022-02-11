using CleanBase.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductId(int? id);
        Task<ProductDTO> GetProductCategory(int? id);
        Task Create(ProductDTO product);
        Task Update(ProductDTO product);
        Task Delete(int? id);
    }
}
