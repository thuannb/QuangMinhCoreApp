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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory_>()
                .ConstructUsing(c => new ProductCategory_(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag,
                c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<ProductViewModel, Product_>()
           .ConstructUsing(c => new Product_(c.Name, c.CategoryId, c.Image, c.Price, c.OriginalPrice,
           c.PromotionPrice, c.Description, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Unit, c.Status,
           c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<LINhVatTuViewModel, LINhVatTu>()
                .ConstructUsing(c => new LINhVatTu(c.Ten_Nh_Vt, c.Description, c.Ma_Nh_Vt_Parent, c.HomeOrder, c.Image, c.HomeFlag,
                c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            //CreateMap<LINhVatTuViewModel, LINhVatTu>().DisableCtorValidation();

            CreateMap<LIVatTuViewModel, LIVatTu>().DisableCtorValidation();

            //CreateMap<LIVatTuViewModel, LIVatTu>()
            //       .ConstructUsing(c => new LIVatTu(c.Ten_Vt, c.Ma_Nh_Vt, c.Image, c.Price, c.OriginalPrice,
            //       c.PromotionPrice, c.Description, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Dvt, c.Status,
            //       c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<AppUserViewModel, SYSUser>()
            .ConstructUsing(c => new SYSUser(c.Id, c.FullName, c.UserName,
            c.Email, c.PhoneNumber, c.Avatar, c.Status));

            CreateMap<PermissionViewModel, Permission>()
            .ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete));



            CreateMap<BillViewModel, Bill>()
              .ConstructUsing(c => new Bill(c.Id, c.CustomerName, c.CustomerAddress,
              c.CustomerMobile, c.CustomerMessage, c.BillStatus,
              c.PaymentMethod, c.Status, c.CustomerId));

            CreateMap<BillDetailViewModel, BillDetail>()
              .ConstructUsing(c => new BillDetail(c.Id, c.BillId, c.ProductId,
              c.Quantity, c.Price, c.ColorId, c.SizeId));


            CreateMap<ContactViewModel, Contact>()
                .ConstructUsing(c => new Contact(c.Id, c.Name, c.Phone, c.Email, c.Website, c.Address, c.Other, c.Lng, c.Lat, c.Status));

            CreateMap<FeedbackViewModel, Feedback>()
                .ConstructUsing(c => new Feedback(c.Id, c.Name, c.Email, c.Message, c.Status));

            CreateMap<PageViewModel, Page>()
                .ConstructUsing(c => new Page(c.Id, c.Name, c.Alias, c.Content, c.Status));

            CreateMap<AnnouncementViewModel, Announcement>()
                .ConstructUsing(c => new Announcement(c.Title, c.Content, c.UserId, c.Status));

            CreateMap<AnnouncementUserViewModel, AnnouncementUser>()
                .ConstructUsing(c => new AnnouncementUser(c.AnnouncementId, c.UserId, c.HasRead));
        }
    }
}
