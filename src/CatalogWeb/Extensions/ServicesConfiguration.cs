using CatalogWeb.BL.Services;
using CatalogWeb.Domain.Entities;
using CatalogWeb.Domain.IRepository;
using CatalogWeb.Domain.IService;
using CatalogWeb.Infrastructure.Data;

namespace CatalogWeb.Extensions
{
    public class ServicesConfiguration
    {
        public static void Configuration(
            IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
            services.AddScoped<IProductService<Product>, ProductService>();

        }
    }  
}