using KBStarCoreApp.Data.EF.Extensions;
using KBStarCoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Data.EF.Configurations
{
    public class LINhVatTuConfiguration : DbEntityConfiguration<LINhVatTu>
    {
        public override void Configure(EntityTypeBuilder<LINhVatTu> entity)
        {
            //Định nghĩa khóa chính của Tag có kiểu dữ liệu varchar(50)
            //entity.Property(c => c.Id).HasColumnName("Ma_Nh_Vt").HasColumnType("varchar(20)");

        }
    }
}
