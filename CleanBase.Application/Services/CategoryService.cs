using AutoMapper;
using CleanBase.Application.DTOs;
using CleanBase.Application.Interfaces;
using CleanBase.Domain.Entities;
using CleanBase.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryId(int? id)
        {
            var categoryEntity = await _categoryRepository.GetCategoryId(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Create(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.Create(categoryEntity);
        }

        public async Task Update(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task Delete(int? id)
        {
            var categoryEntity = _categoryRepository.GetCategoryId(id).Result;
            await _categoryRepository.Delete(categoryEntity);
        }
    }
}
