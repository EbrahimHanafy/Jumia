﻿using Jumia.Models;
using Jumia.SharedRepositories;
using Jumia.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Jumia.Repositories.Implementation
{
	public class ProductRateRepository: GenericRepository<ProductRate>, IProductRateRepository
	{
		protected readonly DbSet<ProductRate> _productRates;
		
		public ProductRateRepository(AppDBContext context) : base(context) 
		{
			_productRates = context.Set<ProductRate>();
		}
	}
}
