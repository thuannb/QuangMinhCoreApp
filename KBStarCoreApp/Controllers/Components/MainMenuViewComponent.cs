using KBStarCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KBStarCoreApp.Controllers.Components
{
    //Ten view component phai giong moi chay duoc. Bo tien to ViewComponent di
    public class MainMenuViewComponent:ViewComponent
    {
        private ILINhVatTuService _productCategoryService;

        public MainMenuViewComponent(ILINhVatTuService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = _productCategoryService.GetAll();
            return View(product);
        }
    }
}
