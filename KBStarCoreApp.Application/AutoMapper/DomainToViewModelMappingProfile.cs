using AutoMapper;
using KBStarCoreApp.Application.ViewModels.Blog;
using KBStarCoreApp.Application.ViewModels.Common;
using KBStarCoreApp.Application.ViewModels.Product;
using KBStarCoreApp.Application.ViewModels.System;
using KBStarCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory_, ProductCategoryViewModel>();
            CreateMap<Product_, ProductViewModel>();

            CreateMap<LINhVatTu, LINhVatTuViewModel>();
            CreateMap<LIVatTu, LIVatTuViewModel>();


            CreateMap<Announcement, AnnouncementViewModel>().MaxDepth(2);

            CreateMap<Function, FunctionViewModel>();
            CreateMap<SYSUser, AppUserViewModel>();
            CreateMap<SYSRole, AppRoleViewModel>();
            CreateMap<Bill, BillViewModel>();
            CreateMap<BillDetail, BillDetailViewModel>();
            CreateMap<Color, ColorViewModel>();
            CreateMap<Size, SizeViewModel>();
            CreateMap<ProductQuantity_, ProductQuantityViewModel>().MaxDepth(2);
            CreateMap<ProductImage_, ProductImageViewModel>().MaxDepth(2);
            CreateMap<WholePrice, WholePriceViewModel>().MaxDepth(2);

            CreateMap<Blog, BlogViewModel>().MaxDepth(2);
            CreateMap<BlogTag, BlogTagViewModel>().MaxDepth(2);
            CreateMap<Slide, SlideViewModel>().MaxDepth(2);
            CreateMap<SystemConfig, SystemConfigViewModel>().MaxDepth(2);
            CreateMap<Footer, FooterViewModel>().MaxDepth(2);

            CreateMap<Feedback, FeedbackViewModel>().MaxDepth(2);
            CreateMap<Contact, ContactViewModel>().MaxDepth(2);
            CreateMap<Page, PageViewModel>().MaxDepth(2);
        }
    }
}
