using CleanBase.API.ViewModels;
using CleanBase.Application.DTOs;
using CleanBase.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();
            if (products == null) return NotFound("Não há produtos a listar.");
            return Ok(products);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productService.GetProductId(id);
            if (product == null) return NotFound("Produto não existe.");
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductInput productInput)
        {
            if (productInput == null) return BadRequest("Dados Invalidos");
            var product = new ProductDTO
            {
                Name = productInput.Name,
                Description = productInput.Description,
                Price = productInput.Price,
                Stock = productInput.Stock,
                Image = productInput.Image,
                CategoryId = productInput.CategoryId
            };
            await _productService.Create(product);
            return Created("", new { Success = "Cadastrado com Sucesso", Product = productInput });
        }
        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Put(int id, [FromBody] ProductDTO product)
        {
            if (id != product.Id) return BadRequest("Id não confere.");
            if (product == null) return BadRequest("Dados Invalidos");
            await _productService.Update(product);
            return Ok(product);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var product = await _productService.GetProductId(id);
            if (product == null) return NotFound("Produto não localizada");
            await _productService.Delete(id);
            return Ok(product);
        }
    }
}
