using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ContaService : BaseService<Conta>, IContaService
    {
        private readonly IContaRepository _contaRepository;
        public ContaService(IContaRepository contaRepository) : base(contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<int> GetIdContaAsync(int idContaPessoal)
        {
            Conta conta = ContaBuilder
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
