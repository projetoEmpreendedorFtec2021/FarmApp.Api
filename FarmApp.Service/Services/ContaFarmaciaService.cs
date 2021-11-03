using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ContaFarmaciaService : BaseService<ContaFarmaciaPoco>, IContaFarmaciaService
    {
        private readonly IUfService _ufService;
        private readonly IBairroService _bairroService;
        private readonly ICidadeService _cidadeService;
        private readonly IEnderecoService _enderecoService;
        private readonly ICepService _cepService;
        private readonly IClienteService _clienteService;
        private readonly IContaFarmaciaRepository _contaFarmaciaRepository;
        private readonly IContaService _contaService;
        public ContaFarmaciaService(
            IContaFarmaciaRepository contaFarmaciaRepository,
            IUfService ufService,
            IBairroService bairroService,
            ICidadeService cidadeService,
            IEnderecoService enderecoService,
            ICepService cepService,
            IClienteService clienteService,
            IContaService contaService) : base(contaFarmaciaRepository)
        {
            _ufService = ufService;
            _bairroService = bairroService;
            _cidadeService = cidadeService;
            _enderecoService = enderecoService;
            _cepService = cepService;
            _contaFarmaciaRepository = contaFarmaciaRepository;
            _clienteService = clienteService;
            _contaService = contaService;
        }

        public async Task<bool> CadastraContaFarmaciaAsync(ContaFarmaciaDTO contaFarmaciaDTO)
        {
            if(contaFarmaciaDTO.IdCliente == 0)
            {
                throw new ArgumentNullException(nameof(contaFarmaciaDTO.IdCliente));
            }
            var idUf = await _ufService.GetIdUfAsync(contaFarmaciaDTO.Uf);
            var idBairro = await _bairroService.GetIdBairroAsync(contaFarmaciaDTO.Bairro);

            var idCidade = await _cidadeService.GetIdCidadeAsync(contaFarmaciaDTO.Cidade, idUf);

            var idEndereco = await _enderecoService.GetIdEnderecoAsync(
                contaFarmaciaDTO.Endereco,
                idCidade,
                idBairro);

            var idCep = await _cepService.GetIdCepAsync(contaFarmaciaDTO.CEP, idEndereco);

            var contaFarmacia = ContaFarmaciaBuilder
                .Init(_contaFarmaciaRepository)
                .SetRazaoSocial(contaFarmaciaDTO.RazaoSocial)
                .SetCnpj(contaFarmaciaDTO.Cnpj)
                .SetAlvara(contaFarmaciaDTO.Alvara)
                .SetNomeFantasia(contaFarmaciaDTO.NomeFantasia)
                .SetCelular(contaFarmaciaDTO.Celular)
                .SetEmail(contaFarmaciaDTO.Email)
                .SetNumeroEndereco(contaFarmaciaDTO.Numero)
                .SetIdCep(idCep)
                .SetSite(contaFarmaciaDTO.Site)
                .SetTelefone(contaFarmaciaDTO.Telefone)
                .Build();

            var contaFarmaciaCadastrada = await AddAsync<ContaFarmaciaValidator>(contaFarmacia);

            var cadastrouContaFarmacia = contaFarmaciaCadastrada != null;

            if (!cadastrouContaFarmacia)
            {
                return cadastrouContaFarmacia;
            }


            var cliente = await _clienteService.GetByIdAsync(contaFarmaciaDTO.IdCliente);

            if(cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            if (cliente.Idconta == 0)
            {
                throw new ArgumentNullException(nameof(cliente.Idconta));
            }

            cadastrouContaFarmacia &= await _contaService.IncludeIdContaFarmaciaAsync(
                cliente.Idconta.Value, 
                contaFarmaciaCadastrada.Id);

            return cadastrouContaFarmacia;

        }
    }
}
