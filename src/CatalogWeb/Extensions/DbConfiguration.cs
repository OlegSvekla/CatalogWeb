using CatalogWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CatalogWeb.Extensions
{
    public static class DbConfiguration
    {
        public static void Configuration(
            IConfiguration configuration,
            IServiceCollection services)
        {
            services.AddDbContext<CatalogWebDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CatalogWebDbConnection")));
        }
    }
}