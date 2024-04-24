using KBStarCoreApp.Data.EF.Extensions;
using KBStarCoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Data.EF.Configurations
{
    public class AdvertistmentPageConfiguration:DbEntityConfiguration<AdvertistmentPage>
    {

        public override void Configure(EntityTypeBuilder<AdvertistmentPage> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired().HasColumnType("varchar(20)");
            // etc.
        }
    }
}
