using AutoMapper;
using AutoMapper.QueryableExtensions;
using KBStarCoreApp.Application.Interfaces;
using KBStarCoreApp.Application.ViewModels.Product;
using KBStarCoreApp.Data.Entities;
using KBStarCoreApp.Data.Enums;
using KBStarCoreApp.Data.IRepositories;
using KBStarCoreApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KBStarCoreApp.Application.Implementation
{
    public class LINhVatTuService : ILINhVatTuService
    {
        private IRepository<LINhVatTu,string> _productCategoryRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LINhVatTuService(IRepository<LINhVatTu, string> productCategoryRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        

        public List<LINhVatTuViewModel> GetAll()
        {
            //var result = _productCategoryRepository.FindAll();
            var test = _productCategoryRepository.FindAll().OrderBy(x => x.Ma_Nh_Vt_Parent);
            var mapp = _mapper.ProjectTo<LINhVatTuViewModel>(test).ToList();
            return mapp;
        }

        public List<LINhVatTuViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _mapper.ProjectTo<LINhVatTuViewModel>(_productCategoryRepository.FindAll(x => x.Ten_Nh_Vt.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.Ma_Nh_Vt_Parent)).ToList();
            else
                return _mapper.ProjectTo<LINhVatTuViewModel>(_productCategoryRepository.FindAll().OrderBy(x => x.Ma_Nh_Vt_Parent))
                    .ToList();
        }

        public List<LINhVatTuViewModel> GetAllByParentId(string parentId)
        {
            return _mapper.ProjectTo<LINhVatTuViewModel>(_productCategoryRepository.FindAll(x => x.Status == Status.Active
            && x.Ma_Nh_Vt_Parent == parentId))
             .ToList();
        }

        public LINhVatTuViewModel GetById(string id)
        {
            var model = _productCategoryRepository.FindAll(x => x.Ma_Nh_Vt == id).FirstOrDefault();
            return _mapper.Map<LINhVatTu, LINhVatTuViewModel>(model);
        }

        public List<LINhVatTuViewModel> GetHomeCategories(int top)
        {
            var query = _mapper.ProjectTo<LINhVatTuViewModel>(_productCategoryRepository
                .FindAll(x => x.HomeFlag == true, c => c.LIVatTu)
                  .OrderBy(x => x.HomeOrder)
                  .Take(top));

            var categories = query.ToList();
            foreach (var category in categories)
            {
                //category.Products = _productRepository
                //    .FindAll(x => x.HotFlag == true && x.CategoryId == category.Id)
                //    .OrderByDescending(x => x.DateCreated)
                //    .Take(5)
                //    .ProjectTo<ProductViewModel>().ToList();
            }
            return categories;
        }
    }
}