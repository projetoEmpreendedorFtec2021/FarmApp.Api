using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        private readonly Db_FarmAppContext _db_FarmAppContext;
        public BaseRepository(Db_FarmAppContext db_FarmAppContext)
        {
            _db_FarmAppContext = db_FarmAppContext;
        }

        public async Task DeleteAsync(int id)
        {
            _db_FarmAppContext.Set<TEntity>().Remove(await GetByIdAsync(id));
           await _db_FarmAppContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync() => await _db_FarmAppContext.Set<TEntity>().ToListAsync();
        public async Task<TEntity> GetByIdAsync(int id) => await _db_FarmAppContext.Set<TEntity>().FindAsync(id);

        public async Task InsertAsync(TEntity obj)
        {
           _db_FarmAppContext.Set<TEntity>().Add(obj);
           await _db_FarmAppContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            _db_FarmAppContext.Entry(obj).State = EntityState.Modified;
            await _db_FarmAppContext.SaveChangesAsync();
        }
    }
}
