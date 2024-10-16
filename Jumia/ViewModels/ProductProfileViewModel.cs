using Jumia.DTO;
using Jumia.Models;

namespace Jumia.ViewModels
{
    public class ProductProfileViewModel
    {
        public Product? Product { get; set; }
        public int AvailableQuantity { get; set; }
        public List<MaterialsCare>? ProductMaterialsCare { get; set; }
        //public List<Size>? Sizes { get; set; }
        //public List<Color>? Colors { get; set; }
        public List<ProductColorSize>? ColorSizes { get; set; }
        public List<ProductRateUser>? ProductRates { get; set; }
        public int ProductId { get; set; }
        public int ProductRateAverage { get; set; }
        public ProductRate NewRate { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
