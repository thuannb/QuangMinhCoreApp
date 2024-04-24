using KBStarCoreApp.Models;
using KBStarCoreApp.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KBStarCoreApp.Controllers.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var session = HttpContext.Session.GetString(CommonConstants.CartSession);
            var cart = new List<ShoppingCartViewModel>();
            if (session != null)
                cart = JsonConvert.DeserializeObject<List<ShoppingCartViewModel>>(session);
            return View(cart);
        }
    }
}
