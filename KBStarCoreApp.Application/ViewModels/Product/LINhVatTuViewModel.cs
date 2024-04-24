using KBStarCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace KBStarCoreApp.Application.ViewModels.Product
{
    public class LINhVatTuViewModel
    {
        public string Id { get; set; }

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

        public ICollection<LIVatTuViewModel> LIVatTu { set; get; }
    }
}