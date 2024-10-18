using Jumia.Models;

namespace Jumia.ViewModels
{
    public class ShoppingCartProductViewModel
    {
        public ShoppingCart shoppingCart { get; set; }
        public Product product { get; set; }
        public ProductImage image { get; set; }
        public Color color { get; set; }
        public Size size { get; set; }
    }
}
