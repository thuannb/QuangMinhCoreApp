﻿using KBStarCoreApp.Application.Interfaces;
using KBStarCoreApp.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KBStarCoreApp.Controllers
{
    public class ProductController : Controller
    {
        ILIVatTuService _productService;
        IBillService _billService;
        ILINhVatTuService _productCategoryService;
        IConfiguration _configuration;
        public ProductController(ILIVatTuService productService, IConfiguration configuration,
            IBillService billService,
            ILINhVatTuService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _configuration = configuration;
            _billService = billService;
        }
        [Route("products.html")]
        public IActionResult Index()
        {
            var categories = _productCategoryService.GetAll();
            return View(categories);
        }

        [Route("{alias}-c.{id}.html")]
        public IActionResult Catalog(string id, int? pageSize, string sortBy, int page = 1)
        {
            var catalog = new CatalogViewModel();
            ViewData["BodyClass"] = "shop_grid_full_width_page";
            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(id, string.Empty, page, pageSize.Value);
            catalog.Category = _productCategoryService.GetById(id);

            return View(catalog);
        }


        [Route("search.html")]
        public IActionResult Search(string keyword, int? pageSize, string sortBy, int page = 1)
        {
            var catalog = new SearchResultViewModel();
            ViewData["BodyClass"] = "shop_grid_full_width_page";
            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            //catalog.Data = _productService.GetAllPaging(null, keyword, page, pageSize.Value);
            catalog.Keyword = keyword;

            return View(catalog);
        }

        [Route("{alias}-p.{id}.html", Name = "ProductDetail")]
        public IActionResult Details(string id)
        {
            ViewData["BodyClass"] = "product-page";
            var model = new DetailViewModel();
            model.Product = _productService.GetById(id);
            model.Category = _productCategoryService.GetById(model.Product.Ma_Nh_Vt);
            model.RelatedProducts = _productService.GetRelatedProducts(id, 9);
            //model.UpsellProducts = _productService.GetUpsellProducts(6);
            //model.ProductImages = _productService.GetImages(id);
            //model.Tags = _productService.GetProductTags(id);

            //model.Colors = _billService.GetColors().Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList();
            //model.Sizes = _billService.GetSizes().Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList();

            return View(model);
        }

    }
}
