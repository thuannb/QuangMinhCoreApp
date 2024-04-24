using Microsoft.AspNetCore.Mvc;

namespace KBStarCoreApp.Controllers
{
    public class AjaxContentController : Controller
    {
        public IActionResult HeaderCart()
        {
            return ViewComponent("HeaderCart");
        }
    }
}
