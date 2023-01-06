using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CMS.Core.Data;
using CMS.Core.Helper;
using CMS.Core.Makers.Implementations;
using CMS.Core.Makers.Interface;
using CMS.Core.Repository.Interface;
using CMS.Core.Repository.Repo;
using CMS.Core.Service.Implementation;
using CMS.Core.Service.Interface;
using CMS.User.Data;
using CMS.User.Library;
using CMS.User.Makers.Implementations;
using CMS.User.Makers.Interface;
using CMS.User.Repository.Interface;
using CMS.User.Repository.Repo;
using CMS.User.Service.Implementations;
using CMS.User.Service.Interface;
using CMS.Web.Helpers;
using CMS.Web.LEPagination;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CMS.Web
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CMS.User"));
                options.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
            });

            services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CMS.Core")));

            registerElements(services);
            services.AddAuthentication("userDetails")
               .AddCookie("userDetails", options =>
               {
                   // Cookie settings
                   options.Cookie.HttpOnly = false;
                   //  options.Cookie.Expiration = TimeSpan.FromDays(30);
                   options.LoginPath = "/account/login";
                   options.LogoutPath = "/account/logout";
                   options.AccessDeniedPath = "/error";

               });
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

                options.Filters.Add(new RequireHttpsAttribute());

            }).AddControllersAsServices()
              .AddJsonOptions(jsonOptions =>
              {
                  //jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

              }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (t, f) => f.Create(typeof(SharedResource)));

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            Mapper.Initialize(x =>
            {
                x.AddProfile<Areas.Core.AutomapperProfiles.DomainProfile>();
                x.AddProfile<Areas.User_management.AutomapperProfiles.DomainProfile>();
                x.AddProfile<CMS.Web.AutomapperProfiles.DomainProfile>();
            });

            services.AddAutoMapper();
            services.AddResponseCaching();
            //for compressing data
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "imagejpeg", "png", "jpeg", "jpg" });
            });
            services.AddSession();

            services.Configure<GzipCompressionProviderOptions>(option =>
            option.Level = System.IO.Compression.CompressionLevel.Optimal);

            services.Configure<RequestLocalizationOptions>(
      opts =>
      {
          var supportedCultures = new List<CultureInfo>
          {

                new CultureInfo("en"),
                new CultureInfo("ne-NP"),
          };

          opts.DefaultRequestCulture = new RequestCulture("en");
          // Formatting numbers, dates, etc.
          opts.SupportedCultures = supportedCultures;
          // UI strings that we have localized.
          opts.SupportedUICultures = supportedCultures;
      });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error/{0}");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true
            });
            app.UseResponseCaching();
            app.UseStaticFiles();
            app.UseResponseCompression();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(name: "areaRoute", areaName: "areaRoute", pattern: "{area:exists}/{controller=Page}/{action=Index}/{id?}");
            });


        }
      

        private void registerElements(IServiceCollection services)
        {
            registerServices(services);
            registerRepos(services);
            registerMakers(services);
            registerHelpers(services);
            registerLibraries(services);

        }

        private void registerLibraries(IServiceCollection services)
        {
            registerUserLibraries(services);
            services.AddSingleton<PaginatedMetaService, PaginatedMetaServiceImpl>();
        }

        private void registerUserLibraries(IServiceCollection services)
        {
            services.AddScoped<EncryptDecrypt, EncryptDecryptImpl>();
            services.AddScoped<PasswordHash, PasswordHashImpl>();
        }

        private void registerHelpers(IServiceCollection services)
        {
            services.AddScoped<FileHelper, FileHelperImpl>();
            services.AddScoped<TransactionManager, TransactionManagerImpl>(); services.AddScoped(typeof(DetailsEncoder<>), typeof(DetailsEncoderImpl<>));
            services.AddScoped<HtmlEncodingClassHelper, HtmlEncodingClassHelperImpl>();
            services.AddScoped<SlugGenerator, SlugGeneratorImpl>();
            registerUserHelpers(services);

        }

        private void registerUserHelpers(IServiceCollection services)
        {
            services.AddScoped<CMS.User.Helper.TransactionManager, CMS.User.Helper.TransactionManagerImpl>();
        }

        private void registerMakers(IServiceCollection services)
        {
            registerUserMakers(services);
            registerCoreMakers(services);
        }

        private void registerCoreMakers(IServiceCollection services)
        {
            services.AddScoped<PageCategoryMaker, PageCategoryMakerImpl>();
            services.AddScoped<PageMaker, PageMakerImpl>();
            services.AddScoped<OutletMaker, OutletMakerImpl>();
            services.AddScoped<NoticeMaker, NoticeMakerImpl>();
            services.AddScoped<GalleryMaker, GalleryMakerImpl>();
            services.AddScoped<TestimonialMaker, TestimonialMakerImpl>();
            services.AddScoped<ReceivedEmailMaker, ReceivedEmailMakerImpl>();
            services.AddScoped<DesignationMaker, DesignationMakerImpl>();
            services.AddScoped<EventMaker, EventMakerImpl>();
            services.AddScoped<DetailsMaker, DetailsMakerImpl>();
            services.AddScoped<BlogMaker, BlogMakerImpl>();
            services.AddScoped<BlogCommentMaker, BlogCommentMakerImpl>();
            services.AddScoped<GalleryMaker, GalleryMakerImpl>();
            services.AddScoped<GalleryImageMaker, GalleryImageMakerImpl>();
            services.AddScoped<EmailSetupMaker, EmailSetupMakerImpl>();
            services.AddScoped<VideoMaker, VideoMakerImpl>();
            services.AddScoped<ServicesMaker, ServicesMakerImpl>();
            services.AddScoped<FranchiseModelMaker, FranchiseModelMakerImpl>();
            services.AddScoped<EnquiryMaker, EnquiryMakerImpl>();
            services.AddScoped<ServicesMaker, ServicesMakerImpl>();
            services.AddScoped<ServicesCategoryMaker, ServicesCategoryMakerImpl>();
            services.AddScoped<PlayerProfileMaker, PlayerProfileMakerImpl>();
            services.AddScoped<PictureMaker, PictureMakerImpl>();
        }

        private void registerUserMakers(IServiceCollection services)
        {
            services.AddScoped<AuthenticationMaker, AuthenticationMakerImpl>();
            services.AddScoped<LoginSessionMaker, LoginSessionMakerImpl>();
            services.AddScoped<UserMaker, UserMakerImpl>();
        }

        private void registerRepos(IServiceCollection services)
        {
            registerUserRepos(services);
            registerCoreRepos(services);
        }



        private void registerServices(IServiceCollection services)
        {
            registerUserServices(services);
            registerCoreServices(services);
        }



        private void registerUserRepos(IServiceCollection services)
        {
            services.AddScoped<AuthenticationRepository, AuthenticationRepositoryImpl>();
            services.AddScoped<LoginSessionRepository, LoginSessionRepositoryImpl>();
            services.AddScoped<RolePermissionMapRepository,
            RolePermissionMapRepositoryImpl>();
            services.AddScoped<UserRepository, UserRepositoryImpl>();
            services.AddScoped<UserRoleRepository, UserRoleRepositoryImpl>();
            services.AddScoped<RoleRepository, RoleRepositoryImpl>();
            services.AddScoped(typeof(User.Repository.Interface.BaseRepository<>), typeof(User.Repository.Repo.BaseRepositoryImpl<>));
        }

        private void registerCoreRepos(IServiceCollection services)
        {
            services.AddScoped<PageRepository, PageRepositoryImpl>();
            services.AddScoped<PageCategoryRepository, PageCategoryRepositoryImpl>();
            services.AddScoped<OutletRepository, OutletRepositoryImpl>();
            services.AddScoped<NoticeRepository, NoticeRepositoryImpl>();
            services.AddScoped<SetupRepository, SetupRepositoryImpl>();
            services.AddScoped<GalleryRepository, GalleryRepositoryImpl>();
            services.AddScoped<TestimonialRepository, TestimonialRepositoryImpl>();
            services.AddScoped<ReceivedEmailRepository, ReceivedEmailRepositoryImpl>();
            services.AddScoped<DesignationRepository, DesignationRepositoryImpl>();
            services.AddScoped<EventRepository, EventRepositoryImpl>();
            services.AddScoped<DetailsRepository, DetailsRepositoryImpl>();
            services.AddScoped<BlogRepository, BlogRepositoryImpl>();
            services.AddScoped<BlogCommentRepository, BlogCommentRepositoryImpl>();
            services.AddScoped<EmailsetupRepository, EmailsetupRepositoryImpl>();
            services.AddScoped<GalleryRepository, GalleryRepositoryImpl>();
            services.AddScoped<GalleryImageRepository, GalleryImageRepositoryImpl>();
            services.AddScoped<VideoRepository, VideoRepositoryImpl>();
            services.AddScoped<ServicesRepository, ServicesRepositoryImpl>();
            services.AddScoped<FranchiseModelRepository, FranchiseModelRepositoryImpl>();
            services.AddScoped<EnquiryRepository, EnquiryRepositoryImpl>();
            services.AddScoped<PlayerProfileRepository, PlayerProfileRepositoryImpl>();
            services.AddScoped<ServicesRepository, ServicesRepositoryImpl>();
            services.AddScoped<ServicesCategoryService, ServicesCategoryServiceImpl>();
            services.AddScoped<PictureRepository, PictureRepositoryImpl>();
            services.AddScoped(typeof(Core.Repository.Interface.BaseRepository<>), typeof(Core.Repository.Repo.BaseRepositoryImpl<>));
        }

        private void registerUserServices(IServiceCollection services)
        {
            services.AddScoped<AuthenticationService, AuthenticationServiceImpl>();
            services.AddScoped<LoginSessionService, LoginSessionServiceImpl>();
            services.AddScoped<RolePermissionMapService,
        RolePermissionMapServiceImpl>();
            services.AddScoped<UserRoleService, UserRoleServiceImpl>();
            services.AddScoped<RoleService, RoleServiceImpl>();
            services.AddScoped<UserService, UserServiceImpl>();
        }
        private void registerCoreServices(IServiceCollection services)
        {
            services.AddScoped<SlugGenerator, SlugGeneratorImpl>();
            services.AddScoped<PageCategoryService, PageCategoryServiceImpl>();
            services.AddScoped<PageService, PageServiceImpl>();
            services.AddScoped<OutletService, OutletServiceImpl>();
            services.AddScoped<GalleryService, GalleryServiceImpl>();
            services.AddScoped<NoticeService, NoticeServiceImpl>();
            services.AddScoped<SetupService, SetupServiceImpl>();
            services.AddScoped<TestimonialService, TestimonialServiceImpl>();
            services.AddScoped<EmailSenderService, EmailSenderServiceImpl>();
            services.AddScoped<DesignationService, DesignationServiceImpl>();
            services.AddScoped<EventService, EventServiceImpl>();
            services.AddScoped<DetailsService, DetailsServiceImpl>();
            services.AddScoped<BlogService, BlogServiceImpl>();
            services.AddScoped<PlayerProfileService, PlayerProfileServiceImpl>();
            services.AddScoped< BlogCommentService, BlogCommentServiceImpl>();
            services.AddScoped<EmailSetupService, EmailSetupServiceImpl>();
            services.AddScoped<GalleryService, GalleryServiceImpl>();
            services.AddScoped<GalleryImageService, GalleryImageServiceImpl>();
            services.AddScoped<VideoService, VideoServiceImpl>();
            services.AddScoped<FranchiseModelService, FranchiseModelServiceImpl>();
            services.AddScoped<EnquiryService, EnquiryServiceImpl>();
            services.AddScoped<ServicesCategoryService, ServicesCategoryServiceImpl>();
            services.AddScoped<PictureService, PictureServiceImpl>();
            services.AddScoped<ServicesService, ServicesServiceImpl>();
        }
    }
}
