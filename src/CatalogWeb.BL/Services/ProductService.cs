using CatalogWeb.Domain.Entities;
using CatalogWeb.Domain.IService;
using CatalogWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogWeb.BL.Services
{
    public class ProductService: IProductService<Product>
    {
        private readonly CatalogWebDbContext _context;

        public ProductService(CatalogWebDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            var listOfProducts = await _context.Products
                .Include(p => p.Category)
                .ToListAsync(cancellationToken);

            return listOfProducts;
        }
    }
}
