using Jumia.SharedRepositories;
using Jumia.Models;

namespace Jumia.Repositories.Interfaces
{
	public interface ISizeRepository : IGenericRepository<Size>
	{
		public Task<List<Size>>  GetSizesByProduct(int productId);
	}
}
