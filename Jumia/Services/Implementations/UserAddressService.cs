using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Implementation;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Services.Implementations
{
    public class UserAddressService(IUnitOfWork unitOfWork, IMapper mapper, AppDBContext context) : IUserAddressService
    {
        
        public async Task <List<UserAddress>> getall(int Usercode)
        {
            //var addresslist = unitOfWork.Repository<UserAddress>().GetAllAsync();
           var    Address = await context.UserAddresses
                                 .Where(s => s.UserCode == Usercode)
                                 .Include(s=>s.Country)
                                 .Include(s => s.Governorate)
                                 .Include(s => s.City)
                                 .ToListAsync();

            return mapper.Map<List<UserAddress>>(Address);
        }
    }

}
