using KBStarCoreApp.Application.ViewModels.Blog;
using KBStarCoreApp.Application.ViewModels.Common;
using KBStarCoreApp.Application.ViewModels.Product;
using System.Collections.Generic;

namespace KBStarCoreApp.Models
{
    public class HomeViewModel
    {
        public List<BlogViewModel> LastestBlogs { get; set; }
        public List<SlideViewModel> HomeSlides { get; set; }
        public List<ProductViewModel> HotProducts { get; set; }
        public List<ProductViewModel> TopSellProducts { get; set; }

        public List<ProductCategoryViewModel> HomeCategories { set; get; }

        public string Title { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
    }
}
