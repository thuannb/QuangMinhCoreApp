using AutoMapper;
using KBStarCoreApp.Application.AutoMapper;
using KBStarCoreApp.Application.Dapper.Implementation;
using KBStarCoreApp.Application.Dapper.Interfaces;
using KBStarCoreApp.Application.Implementation;
using KBStarCoreApp.Application.Interfaces;
using KBStarCoreApp.Authorization;
using KBStarCoreApp.Data.EF;
using KBStarCoreApp.Data.EF.Repositories;
using KBStarCoreApp.Data.Entities;
using KBStarCoreApp.Data.IRepositories;
using KBStarCoreApp.Extensions;
using KBStarCoreApp.Helpers;
using KBStarCoreApp.Infrastructure.Interfaces;
using KBStarCoreApp.Services;
using KBStarCoreApp.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using System;

namespace KBStarCoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext to services
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    o => o.MigrationsAssembly("KBStarCoreApp.Data.EF"));
            });

            services.AddMemoryCache();

            //Dùng để nén html lại
            services.AddMinResponse();

            services.AddIdentity<SYSUser, SYSRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            //Recapcha
            services.AddRecaptcha(new RecaptchaOptions()
            {
                SiteKey = Configuration["Recaptcha:SiteKey"],
                SecretKey = Configuration["Recaptcha:SecretKey"]
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
            });

            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());

            //Login external
            services.AddAuthentication()
              .AddFacebook(facebookOpts =>
              {
                  facebookOpts.AppId = Configuration["Authentication:Facebook:AppId"];
                  facebookOpts.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
              })
            .AddGoogle(googleOpts =>
             {
                 googleOpts.ClientId = Configuration["Authentication:Google:ClientId"];
                 googleOpts.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
             });

            // Add application services.
            services.AddScoped<UserManager<SYSUser>, UserManager<SYSUser>>();
            services.AddScoped<RoleManager<SYSRole>, RoleManager<SYSRole>>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IViewRenderService, ViewRenderService>();

            services.AddTransient<DbInitializer>();
            services.AddScoped<IUserClaimsPrincipalFactory<SYSUser>, CustomUserClaimsPrincipalFactory>();

            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 60
                    });
                options.CacheProfiles.Add("Never",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            })
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "Resources"; }
                )
            .AddDataAnnotationsLocalization()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithOrigins("http://localhost:4000")
                       .AllowCredentials();
               }));

            services.AddRazorPages();

            //UnitOfWork & Repository
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

            //Repositories: Truong hop trong Repository co trien khai them phuong thuc thi khai bao o day
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            //Serrvices

            services.AddTransient<ILIVatTuService, LIVatTuService>();
            services.AddTransient<ILINhVatTuService, LINhVatTuService>();

            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();

            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IPageService, PageService>();
			services.AddTransient<IReportService, ReportService>();

			services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //Dung de ghi log file. Thu vien Serilog.Extensions.Logging.File
            loggerFactory.AddFile("Logs/kbstar-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Nén html lại
            app.UseMinResponse();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //Muon su dung no. Khi tao 1 task nao do thi no se luu vao Annoucment.
                //Tham khao trong Area/Admin/Controller/UserController
                endpoints.MapHub<KBStarHub>("/kbstarHub");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}