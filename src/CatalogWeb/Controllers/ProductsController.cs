using CatalogWeb.Domain.Entities;
using CatalogWeb.Domain.IService;
using Microsoft.AspNetCore.Mvc;

namespace CatalogWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService<Product> _productService;

        public ProductsController(IProductService<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            var productsWithCategories = await _productService.GetAllProductsAsync(cancellationToken);

            return productsWithCategories == 
                null ? NotFound("Data is empty") :
                       View("ProductsList", productsWithCategories);
        }
    }
}
