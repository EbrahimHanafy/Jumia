using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IUserORderService 
    {
        public Task<List<Order>> getByUSerCode(int Usercode);
    }
}
