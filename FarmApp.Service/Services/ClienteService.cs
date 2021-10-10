using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ClienteService : BaseService<ClientePoco>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly ICepService _cepService;
        private readonly IUfService _ufService;
        private readonly IBairroService _bairroService;
        private readonly ICidadeService _cidadeService;
        private readonly IContaPessoalService _contaPessoalService;
        private readonly IContaService _contaService;
        private readonly IEnderecoContaPessoalService _enderecoContaPessoalService;
        private readonly IConsentimentoService _consentimentoService;
        private readonly IMailService _mailService;
        public const int IdTipoEnderecoResidencial = 1;
        public const int ValidaEmail = 1;

        public ClienteService(
            IClienteRepository clienteRepository,
            IEnderecoService enderecoService,
            ICepService cepService,
            IUfService ufService,
            IBairroService bairroService,
            ICidadeService cidadeService,
            IContaPessoalService contaPessoalService,
            IContaService contaService,
            IEnderecoContaPessoalService enderecoContaPessoalService,
            IConsentimentoService consentimentoService,
            IMailService mailService) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoService = enderecoService;
            _cepService = cepService;
            _ufService = ufService;
            _bairroService = bairroService;
            _cidadeService = cidadeService;
            _contaPessoalService = contaPessoalService;
            _contaService = contaService;
            _enderecoContaPessoalService = enderecoContaPessoalService;
            _consentimentoService = consentimentoService;
            _mailService = mailService;
        }
        public async Task<bool> CadastraCliente(ClienteDTO clienteDTO)
        {
            var idUf = await _ufService.GetIdUfAsync(clienteDTO.Uf);
            var idBairro = await _bairroService.GetIdBairroAsync(clienteDTO.Bairro);
           
            var idCidade = await _cidadeService.GetIdCidadeAsync(clienteDTO.Cidade, idUf);
           
            var idEndereco = await _enderecoService.GetIdEnderecoAsync(
                clienteDTO.Endereco,
                idCidade,
                idBairro);

            var idCep = await _cepService.GetIdCepAsync(clienteDTO.CEP, idEndereco);

            var idContaPessoal = await _contaPessoalService.GetIdContaPessoalAsync();

            var idConta = await _contaService.GetIdContaFromContaPessoalAsync(idContaPessoal);
            
            await _enderecoContaPessoalService.GetIdEnderecoContaPessoalAsync(
                IdTipoEnderecoResidencial,
                idCep,
                clienteDTO.Numero,
                clienteDTO.Complemento,
                idContaPessoal);

            var cliente = ClienteBuilder
                .Init(_clienteRepository)
                .SetNome(clienteDTO.Nome)
                .SetLogin(clienteDTO.Email)
                .SetSenha(clienteDTO.Senha, clienteDTO.RepeteSenha)
                .SetCPF(clienteDTO.CPF)
                .SetDataNascimento(clienteDTO.DataNascimento)
                .SetCelular(clienteDTO.Celular)
                .SetIdConta(idConta)
                .Build();

            var clienteCadastrado = await AddAsync<ClienteValidator>(cliente);

            var cadastrouCliente = clienteCadastrado != null;

            if (cadastrouCliente)
            {
                await _consentimentoService.AddConsentimento(clienteCadastrado.Id, clienteDTO.SituacaoConsentimento);
                var emailRequest = MontaEmailParaEnvio(cliente.Login, cliente.Id);
                await _mailService.SendEmailAsync(emailRequest);
            }

            return cadastrouCliente;
        }
        public async Task<bool> VerificaEmail(int idCliente)
        {
            var cliente = await GetByIdAsync(idCliente);

            if(cliente.ValidaEmail is null)
            {
                cliente.ValidaEmail = ValidaEmail;
            }
            
            await UpdateAsync<ClienteValidator>(cliente);

            return cliente.ValidaEmail == ValidaEmail;
        }

        private EmailRequest MontaEmailParaEnvio(string email, int idCliente)
        {
            return new EmailRequest()
            {
                ToEmail = email,
                Subject = "FarmApp - Verificação de e-mail",
                Body = @$"Clique no link para verificação de email: https://farmappapi.herokuapp.com/api/Cliente/VerificaEmail?idCliente={idCliente}"
            };
        }
    }
}
