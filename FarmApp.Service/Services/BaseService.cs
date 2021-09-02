using FarmApp.Domain.Interfaces;
using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseModel
    {
        private readonly IBaseRepository<TEntity> _repository;
        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task<TEntity> AddAsync<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            try
            {
                Validate(obj, Activator.CreateInstance<TValidator>());
                await _repository.InsertAsync(obj);
                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<IList<TEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<TEntity> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<TEntity> UpdateAsync<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
           await _repository.UpdateAsync(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if(obj == null)
            {
                throw new Exception("Registros não encontrados!");
            }

            validator.ValidateAndThrow(obj);
        }
    }
}
