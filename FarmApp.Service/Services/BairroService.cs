﻿using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class BairroService : BaseService<Bairro>, IBairroService
    {
        private readonly IBairroRepository _bairroRepository;
        public BairroService(IBairroRepository bairroRepository) : base(bairroRepository)
        {
            _bairroRepository = bairroRepository;
        }

        public async Task<int> GetIdBairroAsync(string nomeBairro)
        {
            Bairro bairro = BairroBuilder
                .Init()
                .SetNomeBairro(nomeBairro)
                .Build();

            var bairroExistente = await _bairroRepository.GetBairroIfExists(nomeBairro);

            if(bairroExistente is null)
            {
                bairroExistente = await AddAsync<BairroValidator>(bairro);
            }

            return bairroExistente.Id;
        }
    }
}
