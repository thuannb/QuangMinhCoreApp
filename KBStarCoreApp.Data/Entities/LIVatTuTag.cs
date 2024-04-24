using KBStarCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KBStarCoreApp.Data.Entities
{
    [Table("LIVatTuTags")]
    public class LIVatTuTag : DomainEntity<int>
    {
        //DomainEntity<int> --> Mặc định cột khóa chính là Id kiểu dữ liệu là int
        public string Ma_Vt { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string TagId { set; get; }

        [ForeignKey("Ma_Vt")]
        public virtual LIVatTu Product { set; get; }

        [ForeignKey("TagId")]
        public virtual LITag Tag { set; get; }
    }

}
