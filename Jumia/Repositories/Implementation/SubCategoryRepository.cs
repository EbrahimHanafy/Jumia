using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.SharedRepositories;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Repositories.Implementation
{
	public class SubCategoryRepository: GenericRepository<SubCategory> , ISubCategoryRepository
	{
		protected readonly DbSet<SubCategory> _subCategories;

		public SubCategoryRepository(AppDBContext context) : base(context) 
		{
			_subCategories = context.Set<SubCategory>();
		}
	}
}
