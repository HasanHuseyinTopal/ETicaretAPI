using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking=true);
        Task<T> GetOne(Expression<Func<T, bool>> filter, bool tracking=true);
        Task<T> GetByIDAsync(string id, bool tracking=true);
    }
}
