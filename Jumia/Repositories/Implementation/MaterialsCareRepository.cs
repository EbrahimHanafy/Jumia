using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class MaterialsCareRepository : GenericRepository<MaterialsCare>, IMaterialsCareRepository
    {
        protected readonly DbSet<MaterialsCare> _materialsCares;
        private readonly DbSet<Product> _products;
        private readonly DbSet<ProductMaterialsCare> _productMaterialsCare;
        private readonly DbSet<MaterialsCare> _materialsCare;

        public MaterialsCareRepository(AppDBContext context) : base(context)
        {
            _materialsCares = context.Set<MaterialsCare>();
            _products = context.Set<Product>();
            _productMaterialsCare = context.Set<ProductMaterialsCare>();
            _materialsCare = context.Set<MaterialsCare>();
        }
        public async Task<List<MaterialsCare>> GetMaterialByProduct(int productId)
        {
            return await (from p in _products
                          join pm in _productMaterialsCare on p.ProductId equals pm.ProductId
                          join m in _materialsCare on pm.MaterialsCareId equals m.MaterialsCareId
                          where p.ProductId == productId
                          select m).ToListAsync();
        }
    }
}
