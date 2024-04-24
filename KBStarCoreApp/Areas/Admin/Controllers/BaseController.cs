using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KBStarCoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]//Bat buoc phai dang nhap moi thuc hien duoc API
    public class BaseController : Controller
    {
    }
}
