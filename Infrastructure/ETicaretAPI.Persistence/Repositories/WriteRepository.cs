using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETicaretDbContext _context;
        public WriteRepository(ETicaretDbContext context)
        {
            _context=context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entry= await Table.AddAsync(entity);
            return entry.State==EntityState.Added;
        }

        public async Task<bool> AddListAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }

        public bool Remove(T Entity)
        {
            EntityEntry<T> entry = Table.Remove(Entity);
            return entry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model=await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return Remove(model);
        }
        public bool RmoveList(List<T> Entity)
        {
            Table.RemoveRange(Entity);
            return true;
        }

        public async Task<int> SaveAsync()
        =>
            await  _context.SaveChangesAsync();

        public bool Update(T Entity)
        {

            EntityEntry<T> entry = Table.Update(Entity);
            return entry.State == EntityState.Modified;
        }
    }
}
