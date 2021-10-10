﻿using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ContaService : BaseService<ContaPoco>, IContaService
    {
        private readonly IContaRepository _contaRepository;
        public ContaService(IContaRepository contaRepository) : base(contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<int> GetIdContaFromContaPessoalAsync(int idContaPessoal)
        {
            var conta = ContaBuilder
                .Init()
                .SetDataCriacao(DateTime.Now)
                .SetIdContaPessoal(idContaPessoal)
                .Build();

            var contaExistente = await _contaRepository.GetContaPorIdContaPessoalAsync(idContaPessoal);
            if(contaExistente is null)
            {
                contaExistente = await AddAsync<ContaValidator>(conta);
            }
            return contaExistente.Id;
        }
    }
}
