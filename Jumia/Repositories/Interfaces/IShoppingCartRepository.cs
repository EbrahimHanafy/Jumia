using Jumia.Models;
using Jumia.SharedRepositories;
using Jumia.ViewModels;

namespace Jumia.Repositories.Interfaces
{
	public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
	{   
        public Task<List<ShoppingCartProductViewModel>?> GetShoppingCartProducts(int UserCode);

        public Task<bool> IsShoppingCartExisted(int productId, int productColorSizeId, int userCode);
    }
}
