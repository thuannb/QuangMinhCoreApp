using KBStarCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KBStarCoreApp.Data.Entities
{
    [Table("ProductTags")]
    public class ProductTag_ : DomainEntity<int>
    {
        //DomainEntity<int> --> Mặc định cột khóa chính là Id kiểu dữ liệu là int
        public int ProductId { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string TagId { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product_ Product { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag_ Tag { set; get; }
    }

}
