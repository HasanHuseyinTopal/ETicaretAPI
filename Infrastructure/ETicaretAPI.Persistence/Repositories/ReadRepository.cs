using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretDbContext _context;
        public DbSet<T> Table => _context.Set<T>();
        public ReadRepository(ETicaretDbContext context)
        {
            _context = context;
        }
 
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking=true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            if (filter==null)
                return query;
            else
                return query.Where(filter);
        }

        public async Task<T> GetByIDAsync(string id,bool tracking=true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(x=> x.Id==Guid.Parse(id));
        }

        public async Task<T> GetOne(Expression<Func<T, bool>> filter, bool tracking=true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }


    }
}
