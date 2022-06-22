using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddListAsync(List<T> entity);
        bool Remove(T Entity);
        Task<bool> RemoveAsync(string id);
        bool RmoveList(List<T> Entity);
        bool Update(T Entity);
        Task<int> SaveAsync();
    }
}
