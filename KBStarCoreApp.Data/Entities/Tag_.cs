using KBStarCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KBStarCoreApp.Data.Entities
{
    [Table("Tags")]
    public class Tag_ : DomainEntity<string>
    {
        //Mặc định DomainEntity<string> cột khóa chính là Id kiểu string.
        //Tuy nhiên không biết được là nvarchar(max) hay là kiểu var chả gì.
        //Nên phải cấu hình khai báo kiểu dữ liệu cho dạng string này từ Data.EF (entity framework) TagConfiguration

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
    }
}
