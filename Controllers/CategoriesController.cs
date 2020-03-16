using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using freecodecampapi.Domain.Models;
using freecodecampapi.Domain.Services;
using freecodecampapi.Extensions;
using freecodecampapi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace freecodecampapi.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> getAllAsync()
        {
            var categories = await categoryService.ListAsync();
            var resources = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getAsync(int id)
        {
            var result = await categoryService.getAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(result.Category);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await categoryService.SaveAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await categoryService.UpdateAsync(id, category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await categoryService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

    }
}