using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IUserAddressService
    {
        public Task <List<UserAddress>> getall(int Usercode);

    }
}
