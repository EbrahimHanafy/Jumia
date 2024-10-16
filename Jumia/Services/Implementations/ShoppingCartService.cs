using AutoMapper;
using Jumia.Models;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;

namespace Jumia.Services.Implementations
{
    public class ShoppingCartService(IUnitOfWork _unitOfWork, IMapper mapper) : IShoppingCartServices
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
    }
}
