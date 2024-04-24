using KBStarCoreApp.Data.Enums;
using KBStarCoreApp.Data.Interfaces;
using KBStarCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace KBStarCoreApp.Data.Entities
{
    [Table("LIVatTu")]
    public class LIVatTu : DomainEntity<string>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        public LIVatTu()
        {
            LIVatTuTags= new List<LIVatTuTag>();
        }

        public LIVatTu(string name, string categoryId, string thumbnailImage,
            decimal price, decimal originalPrice, decimal? promotionPrice,
            string description, string content, bool? homeFlag, bool? hotFlag,
            string tags, string unit, Status status, string seoPageTitle,
            string seoAlias, string seoMetaKeyword,
            string seoMetaDescription)
        {
            Ten_Vt = name;
            Ma_Nh_Vt = categoryId;
            Image = thumbnailImage;
            Price = price;
            //OriginalPrice = originalPrice;
            //PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Dvt = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            LIVatTuTags = new List<LIVatTuTag>();

        }

        public LIVatTu(string id, string name, string categoryId, string thumbnailImage,
             decimal price, decimal originalPrice, decimal? promotionPrice,
             string description, string content, bool? homeFlag, bool? hotFlag,
             string tags, string unit, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription)
        {
            Ma_Vt = id;
            Ten_Vt = name;
            Ma_Nh_Vt = categoryId;
            Image = thumbnailImage;
            Price = price;
            //OriginalPrice = originalPrice;
            //PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Dvt = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            LIVatTuTags = new List<LIVatTuTag>();

        }

        [Key]
        [Column(TypeName = "varchar(20)")]
        public string Ma_Vt { get; set; }

        [StringLength(255)]
        [Required]
        public string Ten_Vt { get; set; }

        [Required]
        public string Ma_Nh_Vt { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        [StringLength(15)]
        public string Dvt { get; set; }

        [ForeignKey("Ma_Nh_Vt")]
        public virtual LINhVatTu LINhVatTu { set; get; }

        public virtual ICollection<LIVatTuTag> LIVatTuTags { set; get; }

        public string SeoPageTitle { set; get; }

        //[Column(TypeName = "varchar(255)")]
        //[StringLength(255)]
        public string SeoAlias { set; get; }

        public string SeoKeywords { set; get; }

        public string SeoDescription { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public Status Status { set; get; }
    }
}
