using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;

namespace Jumia.Services.Implementations
{
    public class BrandServices(IUnitOfWork _unitOfWork, IMapper mapper) : IBrandServices
    {
        private readonly List<Brand> _brands = new List<Brand>();
        public async Task<Brand> AddBrand(Brand brand)
        {
            var newBrand = mapper.Map<Brand>(brand);

            var trans = await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _unitOfWork.Repository<Brand>().InsertAsync(newBrand);
                await _unitOfWork.Save();

                await _unitOfWork.CommitTransactionAsync();

                _brands.Add(newBrand);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new Exception("An error occured while creating the brand");
            }

            return mapper.Map<Brand>(newBrand);
        }
    }
}