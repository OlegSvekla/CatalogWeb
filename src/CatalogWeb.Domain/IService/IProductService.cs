using CatalogWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogWeb.Domain.IService
{
    public interface IProductService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllProductsAsync(CancellationToken cancellationToken = default);
    }
}
