using KBStarCoreApp.Application.ViewModels.Common;
using KBStarCoreApp.Application.ViewModels.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace KBStarCoreApp.Models.ProductViewModels
{
    public class DetailViewModel
    {
        public LIVatTuViewModel Product { get; set; }

        public bool Available { set; get; }

        public List<LIVatTuViewModel> RelatedProducts { get; set; }

        public LINhVatTuViewModel Category { get; set; }

        public List<ProductImageViewModel> ProductImages { set; get; }

        public List<LIVatTuViewModel> UpsellProducts { get; set; }

        public List<LIVatTuViewModel> LastestProducts { get; set; }

        public List<TagViewModel> Tags { set; get; }

        public List<SelectListItem> Colors { set; get; }

        public List<SelectListItem> Sizes { set; get; }
    }
}
