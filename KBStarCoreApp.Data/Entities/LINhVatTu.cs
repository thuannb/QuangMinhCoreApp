using KBStarCoreApp.Data.Enums;
using KBStarCoreApp.Data.Interfaces;
using KBStarCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KBStarCoreApp.Data.Entities
{
    [Table("LINhVatTu")]
    public class LINhVatTu : DomainEntity<string>,
        IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public LINhVatTu()
        {
            LIVatTu = new List<LIVatTu>();
        }

        public LINhVatTu(string name, string description, string parentId, int? homeOrder,
            string image, bool? homeFlag, int sortOrder, Status status, string seoPageTitle, string seoAlias,
            string seoKeywords, string seoDescription)
        {
            Ten_Nh_Vt = name;
            Description = description;
            Ma_Nh_Vt_Parent = parentId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
        }

        public string Ma_Nh_Vt { get; set; }

        public string Ten_Nh_Vt { get; set; }

        public string Description { get; set; }

        public string Ma_Nh_Vt_Parent { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }

        public DateTime DateModified { set; get; }

        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }

        public virtual ICollection<LIVatTu> LIVatTu { set; get; }
    }
}