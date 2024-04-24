using KBStarCoreApp.Data.EF.Configurations;
using KBStarCoreApp.Data.Entities;
using KBStarCoreApp.Data.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using KBStarCoreApp.Data.EF.Extensions;
using Azure;
using System.Reflection.Emit;

namespace KBStarCoreApp.Data.EF
{
    public class AppDbContext : IdentityDbContext<SYSUser, SYSRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Language> Languages { set; get; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Function> Functions { get; set; }

        public DbSet<SYSUser> SYSUsers { get; set; }
        public DbSet<SYSRole> SYSRoles { get; set; }
        public DbSet<Announcement> Announcements { set; get; }
        public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }

        public DbSet<Bill> Bills { set; get; }
        public DbSet<BillDetail> BillDetails { set; get; }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<BlogTag> BlogTags { set; get; }
        public DbSet<Color> Colors { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Page> Pages { set; get; }

        public DbSet<LIVatTu> LIVatTu { set; get; }
        public DbSet<LINhVatTu> LINhVatTu { set; get; }
        //public DbSet<ProductImage_> ProductImages { set; get; }
        //public DbSet<ProductQuantity_> ProductQuantities { set; get; }
        public DbSet<LIVatTuTag> LIVatTuTags { set; get; }

        public DbSet<Product_> Products { set; get; }
        public DbSet<ProductCategory_> ProductCategories { set; get; }
        public DbSet<ProductImage_> ProductImages { set; get; }
        public DbSet<ProductQuantity_> ProductQuantities { set; get; }
        public DbSet<ProductTag_> ProductTags { set; get; }

        public DbSet<Size> Sizes { set; get; }
        public DbSet<Slide> Slides { set; get; }

        public DbSet<LITag> LITags { set; get; }
        public DbSet<Tag_> Tags_ { set; get; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<WholePrice> WholePrices { get; set; }

        public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
        public DbSet<Advertistment> Advertistments { get; set; }
        public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config

            builder.Entity<IdentityUserClaim<string>>().ToTable("SYSUserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<string>>().ToTable("SYSRoleClaims").HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<string>>().ToTable("SYSUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<string>>().ToTable("SYSUserRoles").HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityUserToken<string>>().ToTable("SYSUserTokens").HasKey(x => new { x.UserId });

            #endregion Identity Config
            builder.Entity<LINhVatTu>().HasKey(x => new { x.Ma_Nh_Vt });

            builder.Entity<LIVatTu>().HasKey(x => new { x.Ma_Vt });

            //builder.AddConfiguration(new LINhVatTuConfiguration());

            builder.AddConfiguration(new TagConfiguration());
            builder.AddConfiguration(new BlogTagConfiguration());
            builder.AddConfiguration(new ContactConfiguration());
            builder.AddConfiguration(new FooterConfiguration());
            builder.AddConfiguration(new PageConfiguration());
            builder.AddConfiguration(new FooterConfiguration());
            builder.AddConfiguration(new ProductTagConfiguration());
            builder.AddConfiguration(new SystemConfigConfiguration());
            builder.AddConfiguration(new AdvertistmentPositionConfiguration());

            //base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
