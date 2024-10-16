using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IUserWishListService
    {
        public Task<List<WishList>> getByUSerCode(int Usercode);

    }
}
