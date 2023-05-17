using Al.Core.IServices.Account;
using Al.Core.IServices.Admin;
using Al.Core.IServices.Home;
using Al.Core.IServices.Product;
using Al.Core.IServices.Profile;
using Al.Core.Services.Account;
using Al.Core.Services.Admin;
using Al.Core.Services.Home;
using Al.Core.Services.Product;
using Al.Core.Services.Profile;
using Al.Data.Repository.Admins.SlideBanner;
using Al.Data.Repository.Factors.Factor;
using Al.Data.Repository.Factors.Factor_Detail;
using Al.Data.Repository.Products.Color;
using Al.Data.Repository.Products.Country;
using Al.Data.Repository.Products.Discount;
using Al.Data.Repository.Products.Factory;
using Al.Data.Repository.Products.Group;
using Al.Data.Repository.Products.Image;
using Al.Data.Repository.Products.Product;
using Al.Data.Repository.Products.Year;
using Al.Data.Repository.User;
using Al.Domain.IRepository.Admins.SlideBanner;
using Al.Domain.IRepository.Factors.Factor;
using Al.Domain.IRepository.Factors.Factor_Detail;
using Al.Domain.IRepository.Products.Color;
using Al.Domain.IRepository.Products.Country;
using Al.Domain.IRepository.Products.Discount;
using Al.Domain.IRepository.Products.Factory;
using Al.Domain.IRepository.Products.Group;
using Al.Domain.IRepository.Products.Image;
using Al.Domain.IRepository.Products.Product;
using Al.Domain.IRepository.Products.Year;
using Al.Domain.IRepository.User;
using EP.Core.Tools.RenderViewToString;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProdcutService, ProductService>();
            services.AddScoped<IViewRenderService, RenderViewToString>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAdminFactorService, AdminFactorService>();
            services.AddScoped<IAdminUserService, AdminUserService>();
            services.AddScoped<IAdminProductService, AdminProductService>();
            services.AddScoped<IAdminGroupService, AdminGroupService>();
            services.AddScoped<IAdminCountryService, AdminCountryService>();
            services.AddScoped<IAdminFactoryService, AdminFactoryService>();
            services.AddScoped<IAdminColorService, AdminColorService>();
            services.AddScoped<IAdminYearService, AdminYearService>();
            services.AddScoped<IAdminDiscountService, AdminDiscountService>();
            services.AddScoped<IAdminBannerService, AdminBannerService>();
            services.AddScoped<IAdminSlideService, AdminSlideService>();

            #endregion

            #region Repositories

            services.AddScoped<IFactorRepository, FactorRepository>();
            services.AddScoped<IFactorDetailRepository, FactorDetailRepository>();
            services.AddScoped<IProdcutService, ProductService>();

            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IFactoryRepository, FactoryRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IYearRepository, YearRepository>();

            services.AddScoped<ISlideBannerRepository, SlideBannerRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}