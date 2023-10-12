using CatalogWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CatalogWeb.Extensions
{
    public static class MigrationsConfiguration
    {
        public static async Task<IApplicationBuilder> RunDbContextMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var logger = serviceProvider.GetRequiredService<ILogger<CatalogWebDbContextSeed>>();

                logger.LogInformation("Database migration running...");

                try
                {
                    var context = serviceProvider.GetRequiredService<CatalogWebDbContext>();
                    context.Database.Migrate();
                    await CatalogWebDbContextSeed.SeedAsyncData(context, logger);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            return app;
        }
    }
}
