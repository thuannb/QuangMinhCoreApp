using KBStarCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KBStarCoreApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        /// <summary>
        /// Trang con truyen them tham so
        /// </summary>
        /// <param name="result">Du lieu cua phan trang</param>
        /// <returns></returns>
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
