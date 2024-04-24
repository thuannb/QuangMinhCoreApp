using KBStarCoreApp.Application.ViewModels.Product;

namespace KBStarCoreApp.Models
{
	public class ShoppingCartViewModel
	{
		public ProductViewModel Product { set; get; }

		public int Quantity { set; get; }

		public decimal Price { set; get; }

		public ColorViewModel Color { get; set; }

		public SizeViewModel Size { get; set; }
	}
}
