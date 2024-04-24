using KBStarCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KBStarCoreApp.WebApi.Controllers
{
	public class ProductController : BaseController
	{

		IProductCategoryService _productCategoryService;
		public ProductController(IProductCategoryService productCategoryService)
		{
			_productCategoryService = productCategoryService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return new OkObjectResult(_productCategoryService.GetAll());
		}
	}
}
