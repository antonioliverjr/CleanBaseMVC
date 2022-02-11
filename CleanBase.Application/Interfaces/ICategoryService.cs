using CleanBase.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryId(int? id);
        Task Create(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Delete(int? id);
    }
}
