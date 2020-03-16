using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using freecodecampapi.Domain.Models;
using freecodecampapi.Domain.Repositories;
using freecodecampapi.Domain.Services;
using freecodecampapi.Services.Communication;
using Microsoft.AspNetCore.Mvc;

namespace freecodecampapi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await productRepository.ListAsync();
        }

        public async Task<ProductResponse> Delete(int id)
        {
            var existingProduct = await productRepository.FindByIdAsync(id);

            if (existingProduct == null)
            {
                return new ProductResponse("Product not found");
            }

            try
            {
                productRepository.Delete(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred during remove the product: {e.Message}");
            }

            return new ProductResponse(existingProduct);

        }

        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await productRepository.AddAsync(product);
                await unitOfWork.CompleteAsync();

                return new ProductResponse(product);

            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred during save the product: {e.Message}");
            }
        }

        public async Task<ProductResponse> Update(int id, Product product)
        {
            var existingProduct = await productRepository.FindByIdAsync(id);

            if (existingProduct == null)
            {
                return new ProductResponse("Product not found");
            }

            existingProduct.Name = product.Name;
            existingProduct.QuantityInPackage = product.QuantityInPackage;
            existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            existingProduct.CategoryId = product.CategoryId;

            try
            {
                productRepository.Update(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred during update the product: {e.Message}");
            }

            return new ProductResponse(existingProduct);
        }

        public async Task<ProductResponse> getAsync(int id)
        {
            var existingProduct = await productRepository.FindByIdAsync(id);

            if (existingProduct == null)
            {
                return new ProductResponse("Product not found. Wrong ID number");
            }

            return new ProductResponse(existingProduct);
        }
    }
}