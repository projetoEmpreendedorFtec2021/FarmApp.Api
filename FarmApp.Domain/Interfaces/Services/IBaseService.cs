using FarmApp.Domain.Models;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> AddAsync<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        Task DeleteAsync(int id);

        Task<IList<TEntity>> GetAllAsync();

        Task<IList<TEntity>> GetAllPaginatedAsync<T>(T paginatedObject) where T : BaseModelPaginated;

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> UpdateAsync<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
