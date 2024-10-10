using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        protected readonly DbSet<Color> _colors;
        public ColorRepository(AppDBContext context) : base(context)
        {
            _colors = context.Set<Color>();
        }
    }
}
