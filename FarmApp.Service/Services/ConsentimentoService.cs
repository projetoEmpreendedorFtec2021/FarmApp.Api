using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ConsentimentoService : BaseService<ConsentimentoPoco>, IConsentimentoService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IConsentimentoRepository _consentimentoRepository;
        private const string Finalidade = "Coleta de dados de identificação pessoal";
        public ConsentimentoService(
            IConsentimentoRepository consentimentoRepository,
            IClienteRepository clienteRepository) : base(consentimentoRepository)
        {
            _consentimentoRepository = consentimentoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task AddConsentimento(int idCliente, string situacao)
        {
            var consentimento = ConsentimentoBuilder
                .Init(_clienteRepository)
                .SetFinalidade(Finalidade)
                .SetSituacao(situacao)
                .SetData(DateTime.Now)
                .SetIdCliente(idCliente)
                .Build();

            var consentimentoExistente = await _consentimentoRepository.ConsentimentoExists(Finalidade, situacao, idCliente);
            if(consentimentoExistente is null)
            {
                consentimentoExistente = await AddAsync<ConsentimentoValidator>(consentimento);
            }
        } 
    }
}
