using KBStarCoreApp.Application.ViewModels.Common;
using KBStarCoreApp.Application.ViewModels.Product;
using KBStarCoreApp.Data.Enums;
using System.Collections.Generic;
using System;
using System.Linq;
using KBStarCoreApp.Utilities.Extensions;

namespace KBStarCoreApp.Models
{
	public class CheckoutViewModel : BillViewModel
	{
		public List<ShoppingCartViewModel> Carts { get; set; }
		public List<EnumModel> PaymentMethods
		{
			get
			{
				return ((PaymentMethod[])Enum.GetValues(typeof(PaymentMethod)))
					.Select(c => new EnumModel
					{
						Value = (int)c,
						Name = c.GetDescription()
					}).ToList();
			}
		}
	}
}
