using AutoMapper;
using KBStarCoreApp.Application.Interfaces;
using KBStarCoreApp.Application.ViewModels.Common;
using KBStarCoreApp.Application.ViewModels.Product;
using KBStarCoreApp.Data.Entities;
using KBStarCoreApp.Data.Enums;
using KBStarCoreApp.Infrastructure.Interfaces;
using KBStarCoreApp.Utilities.Constants;
using KBStarCoreApp.Utilities.Dtos;
using KBStarCoreApp.Utilities.Helpers;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KBStarCoreApp.Application.Implementation
{
    public class LIVatTuService : ILIVatTuService
    {
        private IRepository<LIVatTu, string> _productRepository;
        private IRepository<Tag_, string> _tagRepository;
        private IRepository<ProductTag_, int> _productTagRepository;
        private IRepository<ProductQuantity_, int> _productQuantityRepository;
        private IRepository<ProductImage_, int> _productImageRepository;
        private IRepository<WholePrice, int> _wholePriceRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public LIVatTuService(IRepository<LIVatTu, string> productRepository,
            IRepository<Tag_, string> tagRepository,
            IRepository<ProductQuantity_, int> productQuantityRepository,
            IRepository<ProductImage_, int> productImageRepository,
            IRepository<WholePrice, int> wholePriceRepository,
            IUnitOfWork unitOfWork,
            IRepository<ProductTag_, int> productTagRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _productQuantityRepository = productQuantityRepository;
            _productTagRepository = productTagRepository;
            _wholePriceRepository = wholePriceRepository;
            _productImageRepository = productImageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<LIVatTuViewModel> GetAll()
        {
            return _mapper.ProjectTo<LIVatTuViewModel>(_productRepository.FindAll(x => x.LINhVatTu)).ToList();
        }

        //Co dung
        public PagedResult<LIVatTuViewModel> GetAllPaging(string categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Ten_Vt.Contains(keyword));
            if (!string.IsNullOrEmpty(categoryId))
                query = query.Where(x => x.Ma_Nh_Vt == categoryId);

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = _mapper.ProjectTo<LIVatTuViewModel>(query).ToList();

            var paginationSet = new PagedResult<LIVatTuViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public LIVatTuViewModel GetById(string id)
        {
            return _mapper.Map<LIVatTu, LIVatTuViewModel>(_productRepository.FindById(id));
        }

        public List<ProductQuantityViewModel> GetQuantities(int productId)
        {
            return _mapper.ProjectTo<ProductQuantityViewModel>(_productQuantityRepository.FindAll(x => x.ProductId == productId))
                            .ToList();
        }


        //Co dung
        public List<ProductImageViewModel> GetImages(int productId)
        {
            return _mapper.ProjectTo<ProductImageViewModel>(_productImageRepository.FindAll(x => x.ProductId == productId)).ToList();
        }

        public void AddImages(int productId, string[] images)
        {
            _productImageRepository.RemoveMultiple(_productImageRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var image in images)
            {
                _productImageRepository.Add(new ProductImage_()
                {
                    Path = image,
                    ProductId = productId,
                    Caption = string.Empty
                });
            }
        }

        public void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices)
        {
            _wholePriceRepository.RemoveMultiple(_wholePriceRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var wholePrice in wholePrices)
            {
                _wholePriceRepository.Add(new WholePrice()
                {
                    ProductId = productId,
                    FromQuantity = wholePrice.FromQuantity,
                    ToQuantity = wholePrice.ToQuantity,
                    Price = wholePrice.Price
                });
            }
        }

        public List<WholePriceViewModel> GetWholePrices(int productId)
        {
            return _mapper.ProjectTo<WholePriceViewModel>(_wholePriceRepository.FindAll(x => x.ProductId == productId)).ToList();
        }

        public List<ProductViewModel> GetLastest(int top)
        {
            return _mapper.ProjectTo<ProductViewModel>(_productRepository.FindAll(x => x.Status == Status.Active).OrderByDescending(x => x.DateCreated)
                .Take(top)).ToList();
        }

        public List<ProductViewModel> GetHotProduct(int top)
        {
            return _mapper.ProjectTo<ProductViewModel>(_productRepository.FindAll(x => x.Status == Status.Active && x.HotFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(top))
                .ToList();
        }

        //Co dung
        public List<LIVatTuViewModel> GetRelatedProducts(string ma_Vt, int top)
        {
            var product = _productRepository.FindSingle(x => x.Ma_Vt == ma_Vt);
            return _mapper.ProjectTo<LIVatTuViewModel>(_productRepository.FindAll(x => x.Status == Status.Active
                && x.Ma_Vt != ma_Vt && x.Ma_Nh_Vt == product.Ma_Nh_Vt)
            .OrderByDescending(x => x.DateCreated)
            .Take(top))
            .ToList();
        }

        //Co dung
        public List<ProductViewModel> GetUpsellProducts(int top)
        {
            return _mapper.ProjectTo<ProductViewModel>(_productRepository.FindAll()
               .OrderByDescending(x => x.DateModified)
               .Take(top)).ToList();
            //return _mapper.ProjectTo<ProductViewModel>(_productRepository.FindAll(x => x.PromotionPrice != null)
            //   .OrderByDescending(x => x.DateModified)
            //   .Take(top)).ToList();
        }

        //Co dung
        public List<TagViewModel> GetProductTags(int productId)
        {
            var tags = _tagRepository.FindAll();
            var productTags = _productTagRepository.FindAll();

            var query = from t in tags
                        join pt in productTags
                        on t.Id equals pt.TagId
                        where pt.ProductId == productId
                        select new TagViewModel()
                        {
                            Id = t.Id,
                            Name = t.Name
                        };
            return query.ToList();
        }

        public bool CheckAvailability(int productId, int size, int color)
        {
            var quantity = _productQuantityRepository.FindSingle(x => x.ColorId == color && x.SizeId == size && x.ProductId == productId);
            if (quantity == null)
                return false;
            return quantity.Quantity > 0;
        }
    }
}