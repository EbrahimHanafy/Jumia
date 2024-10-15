namespace Jumia.DTO
{
	public class ProductRateUser
	{
		public int ProductRateId { get; set; }
		public int ProductId { get; set; }
		public int Rate { get; set; }
		public string? Review { get; set; } 
		public DateTime RateDate { get; set; }
		public int UserCode { get; set; }
		public string UserName { get; set; } = string.Empty;
		public string UserEmail { get; set; } = string.Empty;

    }
}
