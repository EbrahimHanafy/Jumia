using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Jumia.ViewModels;

namespace Jumia.Services.Implementations
{
    public class ShoppingCartService(IUnitOfWork _unitOfWork, IMapper mapper, IShoppingCartRepository shoppingCartRepository) : IShoppingCartServices
    {
        public async Task<ShoppingCart> AddToCart(ShoppingCart shoppingCart)
        {
            var newShopping = mapper.Map<ShoppingCart>(shoppingCart);
            try 
            {
                await _unitOfWork.Repository<ShoppingCart>().InsertAsync(shoppingCart);
                await _unitOfWork.Save();
            }
            catch (Exception ex) 
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new Exception("An error occured while creating the shopping cart");

            }

            return mapper.Map<ShoppingCart>(newShopping);
        }

        public async Task<List<ShoppingCartProductViewModel>?> GetShoppingCartProducts(int userCode)
        {
            var shoppingCartProducts = await shoppingCartRepository.GetShoppingCartProducts(userCode);
            return mapper.Map<List<ShoppingCartProductViewModel>?>(shoppingCartProducts);
        }

        public async Task RemoveProductFromCart(int shoppingCartId)
        {
            try
            {
                await _unitOfWork.Repository<ShoppingCart>().DeleteAsync(shoppingCartId);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new Exception("An error occured while deleting the shopping cart");

            }
        }

        //public async Task<ShoppingCart> GetShoppingCartById(int shoppingCartId)
        //{
        //    var shoppingCart = await shoppingCartRepository.GetByIdAsync(shoppingCartId);
        //    return shoppingCart;
        //}
        public async Task<bool> IsShoppingCartExisted(int productId, int productColorSizeId, int userCode)
        {
            return await shoppingCartRepository.IsShoppingCartExisted(productId, productColorSizeId, userCode);
        }
    }
}