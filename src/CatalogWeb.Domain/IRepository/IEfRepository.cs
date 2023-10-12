using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogWeb.Domain.IRepository
{
    public interface IEfRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllByAsync(Func<IQueryable<T>,
             IIncludableQueryable<T, object>>? include = null,
             Expression<Func<T, bool>>? expression = null,
             CancellationToken cancellationToken = default);
    }
}
