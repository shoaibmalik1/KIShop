using KIShop.BLL.Service;
using KIShop.DAL.Repository;
using KIShop.DAL.Utils;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace KIShop.PL
{
    public static class AppConfigration
    {
        public static void Config(IServiceCollection Services)
        {
            Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Services.AddScoped<ICategoryService, CategoryService>();
            Services.AddScoped<IAuthenticationService, AuthenticationService>();
            Services.AddScoped<RoleSeedData>();
            Services.AddScoped<UserSeedData>();
            Services.AddTransient<IEmailSender, EmailSender>();


            Services.AddScoped<IFileService, FileService>();
            Services.AddScoped<IProductService, ProductService>();
            Services.AddTransient<IProductRepository, ProductRepository>();

        }
    }
}
