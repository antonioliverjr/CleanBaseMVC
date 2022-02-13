using CleanBase.API.ViewModels;
using CleanBase.Application.DTOs;
using CleanBase.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null) return NotFound("Não há categorias a retornar.");
            return Ok(categories);
        }
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetCategoryId(id);
            if (category == null) return NotFound("Não há categoria a retornar.");
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryInput categoryInput)
        {
            if (categoryInput == null) return BadRequest("Dados Invalidos");
            var category = new CategoryDTO { Name = categoryInput.Name };
            await _categoryService.Create(category);
            return Created("", new { Success = "Cadastrado com Sucesso", Category = category.Name });
        }
        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Put(int id, [FromBody] CategoryDTO category)
        {
            if (id != category.Id) return BadRequest("Id não confere.");
            if (category == null) return BadRequest("Dados Invalidos");
            await _categoryService.Update(category);
            return Ok(category);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetCategoryId(id);
            if (category == null) return NotFound("Categoria não localizada");
            await _categoryService.Delete(id);
            return Ok(category);
        }
    }
}
