﻿using Jumia.Models;
using Jumia.SharedRepositories;

namespace Jumia.Repositories.Interfaces
{
	public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
	{
        Task AddProductToCart(int productId, int quantity, int ProductColorSizeId);
        Task IncreaseItemQty(int productId, int quantity);
        Task DecreaseItemQty(int productId, int quantity);
        Task RemoveItem(int productId);
        Task<ShoppingCart> GetCartProducts(int userCode);
        
    }
}
