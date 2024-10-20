using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IBrandService
    {
        public Task<Brand> AddBrand(Brand brand);
    }
}
