using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        protected readonly DbSet<Color> _colors;
        private readonly DbSet<ProductColorSize> _productColorSize;

        public ColorRepository(AppDBContext context) : base(context)
        {
            _colors = context.Set<Color>();
            _productColorSize = context.Set<ProductColorSize>();
        }

        public async Task<List<Color>> GetColorByProductAndSize(int productId)
        {
            var Colors = await (from color in _colors
                               join productColorSize in _productColorSize on color.ColorId equals productColorSize.ColorId
                               where productColorSize.ProductId == productId
                               select color)
                              .Distinct()
                              .ToListAsync();
            return Colors;
        }

        public async Task<List<Color>> GetColorsBySize(int productId, int sizeId)
        {
            var colors = await _context.ProductColorSizes
                                       .Where(pcs => pcs.ProductId == productId && pcs.SizeId == sizeId)
                                       .Select(pcs => pcs.Color) // Select the actual Color object
                                       .Distinct() // To avoid duplicate colors, if applicable
                                       .ToListAsync();
            return colors;
        }
    }
}