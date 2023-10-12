using CatalogWeb.Domain.Entities;
using CatalogWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogWeb.Infrastructure.Data
{
    public class CatalogWebDbContextSeed
    {
        public static async Task SeedAsyncData(CatalogWebDbContext catalogContext, ILogger logger, int retry = 0)
        {
            var retryForAvailbility = retry;

            try
            {
                if (!await catalogContext.Products.AnyAsync())
                {
                    await catalogContext.Products.AddRangeAsync(GetPreConfiguredProducts());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailbility >= 10) throw;
                {
                    retryForAvailbility++;

                    logger.LogError(ex.Message);
                    await SeedAsyncData(catalogContext, logger, retryForAvailbility);
                }
                throw;
            }
        }

        private static IEnumerable<Category> GetPreConfiguredCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Category 1" },
                new Category { Name = "Category 2" },
                new Category { Name = "Category 3" },
                new Category { Name = "Category 4" },
                new Category { Name = "Category 5" }
            };
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            var categories = GetPreConfiguredCategories().ToList();
            return new List<Product>
            {
                new Product { Name = "Product 1", Price = 10.0M, Category = categories[0] },
                new Product { Name = "Product 2", Price = 15.0M, Category = categories[0] },
                new Product { Name = "Product 3", Price = 20.0M, Category = categories[0] },

                new Product { Name = "Product 4", Price = 25.0M, Category = categories[1] },
                new Product { Name = "Product 5", Price = 30.0M, Category = categories[1] },
                new Product { Name = "Product 6", Price = 35.0M, Category = categories[1] },

                new Product { Name = "Product 7", Price = 40.0M, Category = categories[2] },
                new Product { Name = "Product 8", Price = 45.0M, Category = categories[2] },

                new Product { Name = "Product 9", Price = 50.0M, Category = categories[3] },
                new Product { Name = "Product 10", Price = 55.0M, Category = categories[3] },

                new Product { Name = "Product 11", Price = 60.0M, Category = categories[4] }
            };
        }
    }
}
