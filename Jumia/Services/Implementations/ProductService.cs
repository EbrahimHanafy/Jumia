using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;
using Jumia.SharedRepositories;
using Jumia.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Services.Implementations
{
    public class ProductService(IMapper mapper ,IProductRepository productRepository) : IProductService
    {
        public async Task<List<Product>> GetProductsBySubCategory(int SubCategoryId)
        {
            var products = await productRepository.GetProductsBySubCategory(SubCategoryId);
            return mapper.Map<List<Product>>(products);
        }

        public async Task<List<Product>> GetTop10NewArrivalProducts()
        {
            var top10NewArrivalProducts = await productRepository.GetTop10NewArrivalProducts();
            return mapper.Map<List<Product>>(top10NewArrivalProducts);
        }

        public async Task<List<Product>> GetProductById(int productId)
        {
            var product = await productRepository.GetProductById(productId);
            return mapper.Map<List<Product>>(product);
        }
    }
}

