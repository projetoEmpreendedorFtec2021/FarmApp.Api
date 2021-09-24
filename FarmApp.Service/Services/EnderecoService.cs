using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.GoogleMaps;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ViaCep;

namespace FarmApp.Service.Services
{
    public class EnderecoService : BaseService<EnderecoPoco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IBairroRepository _bairroRepository;

        private readonly IUfService _ufService;
        private readonly ICidadeService _cidadeService;
        private readonly IBairroService _bairroService;
        private readonly ICepService _cepService;
        private readonly IEnderecoContaPessoalService _enderecoContaPessoalService;

        private const int IdTipoEnderecoResidencia = 1;
        private const int IdTipoEnderecoTrabalho = 2;

        private readonly HttpClient _httpClient;

        public EnderecoService(
            IEnderecoRepository enderecoRepository,
            ICidadeRepository cidadeRepository,
            IBairroRepository bairroRepository,
            IUfService ufService,
            ICidadeService cidadeService,
            IBairroService bairroService,
            ICepService cepService,
            IEnderecoContaPessoalService enderecoContaPessoalService) : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
            _cidadeRepository = cidadeRepository;
            _bairroRepository = bairroRepository;

            _ufService = ufService;
            _cidadeService = cidadeService;
            _bairroService = bairroService;
            _cepService = cepService;
            _enderecoContaPessoalService = enderecoContaPessoalService;

            _httpClient = new HttpClient();
        }

        public async Task<EnderecoCadastroDTO> GetEnderecoFromCEPAsync(string CEP)
        {
            var cancellationToken = new CancellationToken();
            CEP = CEP
                .Trim()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty);

            if (CEP.Length == 8 && Regex.IsMatch(CEP, @"^\d+$"))
            { 
                var viaCepClient = await new ViaCepClient().SearchAsync(CEP, cancellationToken);
                if (viaCepClient.StateInitials != null)
                {
                    return new EnderecoCadastroDTO()
                    {
                        Uf = viaCepClient.StateInitials,
                        Cidade = viaCepClient.City,
                        Bairro = viaCepClient.Neighborhood,
                        Logradouro = viaCepClient.Street
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<int> GetIdEnderecoAsync(string nomeEndereco, int idCidade, int idBairro)
        {
            var endereco = await AddEnderecoIfNotExistsAsync(nomeEndereco, idCidade, idBairro);
            
            return endereco.Id;
        }

        public async Task<EnderecoPoco> AddEnderecoIfNotExistsAsync(string nomeEndereco, int idCidade, int idBairro)
        {
            var endereco = EnderecoBuilder
               .Init(_cidadeRepository, _bairroRepository)
               .SetNomeEndereco(nomeEndereco)
               .SetIdCidade(idCidade)
               .SetIdBairro(idBairro)
               .Build();

            var enderecoExistente = await _enderecoRepository.EnderecoExistsAsync(endereco);

            if (enderecoExistente is null)
            {
                enderecoExistente = await AddAsync<EnderecoValidator>(endereco);
            }
            return enderecoExistente;
        }
       

        public async Task<EnderecoCadastroDTO> GetEnderecoFromLatLong(EnderecoLatLongDTO endereco)
        {
            string requestUri = string.Format(
                "https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&key={2}&language=pt-BR", 
                endereco.Latitude.ToString(CultureInfo.InvariantCulture ),
                endereco.Longitude.ToString(CultureInfo.InvariantCulture), 
                "AIzaSyCnoX0Yi40shoiYC55_mOgdtQIXhDh7PHY");

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode) 
            {
                var json = await response.Content.ReadAsStringAsync();
                 var results = JsonConvert.DeserializeObject<ResultsList>(json);
                return new EnderecoCadastroDTO
                {
                    Uf = GetLongNameFromAddressComponent(results.Results, "administrative_area_level_1"),
                    Cidade = GetLongNameFromAddressComponent(results.Results, "administrative_area_level_2"),
                    Bairro = GetLongNameFromAddressComponent(results.Results, "sublocality_level_1"),
                    Logradouro = GetLongNameFromAddressComponent(results.Results, "route"),
                    Numero = GetLongNameFromAddressComponent(results.Results, "street_number"),
                    CEP = GetLongNameFromAddressComponent(results.Results, "postal_code"),
                    EnderecoFormatado = results.Results.FirstOrDefault().Formatted_address
                };
            }
            return null;
        }

        public async Task<bool> AddEnderecoCompletoAsync(EnderecoLatLongDTO enderecoLatLong) 
        {
            if (string.IsNullOrEmpty(enderecoLatLong.IdContaPessoal))
            {
                throw new ArgumentNullException(nameof(enderecoLatLong.IdContaPessoal));
            }

            var endereco = await GetEnderecoFromLatLong(enderecoLatLong);
            var idUf = await _ufService.GetIdUfAsync(endereco.Uf);
            var idBairro = await _bairroService.GetIdBairroAsync(endereco.Bairro);

            var idCidade = await _cidadeService.GetIdCidadeAsync(endereco.Cidade, idUf);

            var idEndereco = await GetIdEnderecoAsync(
                endereco.Logradouro,
                idCidade,
                idBairro);

            var idCep = await _cepService.GetIdCepAsync(endereco.CEP, idEndereco);
            var idTipoEndereco = enderecoLatLong.IdTipoEndereco ? IdTipoEnderecoTrabalho : IdTipoEnderecoResidencia;
            var idEnderecoContaPessoal = await _enderecoContaPessoalService.GetIdEnderecoContaPessoalAsync(
               idTipoEndereco,
               idCep,
               endereco.Numero,
               string.Empty,
               int.Parse(enderecoLatLong.IdContaPessoal));

            return idEnderecoContaPessoal != 0;
        }

        private string GetLongNameFromAddressComponent(IEnumerable<Result> results, string type)
        {
            return results.FirstOrDefault().Address_components.FirstOrDefault(x => x.Types.Contains(type))?.Long_name;
        }
        
       
    }

}