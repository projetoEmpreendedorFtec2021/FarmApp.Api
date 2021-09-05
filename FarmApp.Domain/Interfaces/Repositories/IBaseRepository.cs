using FarmApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        Task<int> InsertAsync(TEntity obj);

        Task UpdateAsync(TEntity obj);

        Task DeleteAsync(int id);

        Task<IList<TEntity>> GetAllAsync();

        Task<IList<TEntity>> GetAllPaginatedAsync<T>(T paginatedObject) where T : BaseModelPaginated;

        Task<TEntity> GetByIdAsync(int id);
    }
}
