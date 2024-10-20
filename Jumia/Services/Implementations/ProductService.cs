using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;
using Jumia.SharedRepositories;
using Jumia.UnitOfWorks;
using Jumia.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Services.Implementations
{
    public class ProductService(IUnitOfWork unitOfWork,IMapper mapper ,IProductRepository productRepository) : IProductService
    {
        public async Task<List<Product>> GetProductsBySubCategory(int SubCategoryId)
        {
            var products = await productRepository.GetProductsBySubCategory(SubCategoryId);
            return mapper.Map<List<Product>>(products);
        }
        public async Task<List<Product>> GetProductsByBrand(int BrandId)
        {
            var products = await productRepository.GetProductsByBrand(BrandId);
            return mapper.Map<List<Product>>(products);
        }
        public async Task<List<Product>> GetTop10NewArrivalProducts()
        {
            var top10NewArrivalProducts = await productRepository.GetTop10NewArrivalProducts();
            return mapper.Map<List<Product>>(top10NewArrivalProducts);
        }

        public async Task<Product> GetProductById(int productId)
        {
            var product = await productRepository.GetProductById(productId);
            return mapper.Map<Product>(product);
        }

        public async Task<int> GetAvailableQunitityOfProductById(int productId)
        {
            var avilableQuantity = await productRepository.GetAvailableQunitityOfProductById(productId);
            return avilableQuantity;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var products = await unitOfWork.Repository<Product>().GetAllAsync();
            return mapper.Map<List<Product>>(products);
        }
        public async Task<List<WishListProductViewModel>> GetWishListPeoducts(int Usercode)
        {
            var wishListproducts = await productRepository.GetWishListProducts(Usercode);
            return mapper.Map<List<WishListProductViewModel>>(wishListproducts);
        }
    }
}

