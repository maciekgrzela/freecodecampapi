using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using freecodecampapi.Domain.Models;
using freecodecampapi.Domain.Repositories;
using freecodecampapi.Domain.Services;
using freecodecampapi.Services.Communication;

namespace freecodecampapi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found");
            }

            try
            {
                categoryRepository.Remove(existingCategory);
                await unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error occurred when deleting the category: {e.Message}");
            }

        }

        public async Task<CategoryResponse> getAsync(int id)
        {
            var existingCategory = await categoryRepository.FindByIdAsync(id);
            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found. Wrong ID Number");
            }
            return new CategoryResponse(existingCategory);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await categoryRepository.AddAsync(category);
                await unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error occurred when saving the category: {e.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found");
            }

            existingCategory.Name = category.Name;

            try
            {
                categoryRepository.Update(existingCategory);
                await unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error occurred when updating the category: ${e.Message}");
            }
        }
    }
}