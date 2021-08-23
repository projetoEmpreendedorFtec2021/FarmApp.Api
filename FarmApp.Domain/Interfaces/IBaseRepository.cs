using FarmApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        Task InsertAsync(TEntity obj);

        Task UpdateAsync(TEntity obj);

        Task DeleteAsync(int id);

        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);
    }
}
