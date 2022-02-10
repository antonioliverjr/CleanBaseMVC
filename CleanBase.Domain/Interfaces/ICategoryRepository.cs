using CleanBase.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryId(int? id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(Category category);
    }
}
