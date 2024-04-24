using KBStarCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KBStarCoreApp.Controllers.Components
{
    //Ten view component phai giong moi chay duoc. Bo tien to ViewComponent di
    public class MobileMenuViewComponent:ViewComponent
    {
        private ILINhVatTuService _productCategoryService;

        public MobileMenuViewComponent(ILINhVatTuService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCategory = _productCategoryService.GetAll();
            return View(productCategory);
        }
    }
}
