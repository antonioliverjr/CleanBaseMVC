using CleanBase.Application.DTOs;
using CleanBase.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanBase.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var category = await _categoryService.GetCategoryId(id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Create(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetCategoryId(id);

            if (category == null) return NotFound();

            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryService.GetCategoryId(id);

            if (category == null) return NotFound();

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
