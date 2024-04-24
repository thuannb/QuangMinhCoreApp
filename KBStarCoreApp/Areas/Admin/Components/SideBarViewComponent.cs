using KBStarCoreApp.Application.Interfaces;
using KBStarCoreApp.Application.ViewModels.System;
using KBStarCoreApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KBStarCoreApp.Areas.Admin.Components
{
    public class SideBarViewComponent: ViewComponent
    {
        IFunctionService _functionService;
        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains("Admin"))
            {
                functions = await _functionService.GetAll(string.Empty);
            }
            else
            {
                functions = await _functionService.GetAll(string.Empty);
            }

            return View(functions);
        }
    }
}
