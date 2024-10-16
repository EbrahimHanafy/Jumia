using AutoMapper;
using Jumia.Models;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Services.Implementations
{
    public class UserWishListService(IUnitOfWork unitOfWork, IMapper mapper, AppDBContext context) : IUserWishListService
    {
        public async Task<List<WishList>> getByUSerCode(int Usercode)
        {
            var wishlist = await context.WishLists.Where(s => s.UserCode == Usercode).Include(s => s.Product).ToListAsync();

            return mapper.Map<List<WishList>>(wishlist);
        }
    }
}
