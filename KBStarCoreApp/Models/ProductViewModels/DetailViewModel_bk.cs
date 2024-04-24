using KBStarCoreApp.Application.ViewModels.Common;
using KBStarCoreApp.Application.ViewModels.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace KBStarCoreApp.Models.ProductViewModels
{
    public class DetailViewModel_bk
    {
        public ProductViewModel Product { get; set; }

        public bool Available { set; get; }

        public List<ProductViewModel> RelatedProducts { get; set; }

        public ProductCategoryViewModel Category { get; set; }

        public List<ProductImageViewModel> ProductImages { set; get; }

        public List<ProductViewModel> UpsellProducts { get; set; }

        public List<ProductViewModel> LastestProducts { get; set; }

        public List<TagViewModel> Tags { set; get; }

        public List<SelectListItem> Colors { set; get; }

        public List<SelectListItem> Sizes { set; get; }
    }
}
