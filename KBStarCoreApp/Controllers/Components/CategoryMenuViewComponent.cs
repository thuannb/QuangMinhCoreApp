using KBStarCoreApp.Application.Interfaces;
using KBStarCoreApp.Application.ViewModels.Product;
using KBStarCoreApp.Data.Entities;
using KBStarCoreApp.Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KBStarCoreApp.Controllers.Components
{
    //Ten view component phai giong moi chay duoc. Bo tien to ViewComponent di
    public class CategoryMenuViewComponent : ViewComponent
    {
        private IMemoryCache _memoryCache;
        private ILINhVatTuService _productCategoryService;
        public CategoryMenuViewComponent(ILINhVatTuService productCategoryService, IMemoryCache memoryCache)
        {
            _productCategoryService = productCategoryService;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCategory = _memoryCache.GetOrCreate(CacheKeys.ProductCategories, entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromHours(2);
                    return _productCategoryService.GetAll();
                });

            return View(productCategory);
        }
    }
}
