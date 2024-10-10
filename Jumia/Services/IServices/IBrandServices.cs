using Jumia.Models;

namespace Jumia.Services.IServices
{
    public interface IBrandServices
    {
        public Task<Brand> AddBrand(Brand brand);

    }
}
