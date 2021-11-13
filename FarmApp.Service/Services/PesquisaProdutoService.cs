using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.GoogleMaps;
using FarmApp.Domain.Models.Poco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class PesquisaProdutoService : IPesquisaProdutoService
    {
        private readonly IItemFarmaciaService _itemFarmaciaService;
        private readonly IProdutoMarcaService _produtoMarcaService;
        private readonly IEnderecoContaPessoalService _enderecoContaPessoalService;
        private readonly ICepService _cepService;
        private readonly IEnderecoService _enderecoService;
        private readonly IContaFarmaciaService _contaFarmaciaService;

        private readonly HttpClient _httpClient;

        public PesquisaProdutoService(
            IItemFarmaciaService itemFarmaciaService,
            IProdutoMarcaService produtoMarcaService,
            IEnderecoContaPessoalService enderecoContaPessoalService,
            ICepService cepService,
            IEnderecoService enderecoService,
            IContaFarmaciaService contaFarmaciaService)
        {
            _itemFarmaciaService = itemFarmaciaService;
            _produtoMarcaService = produtoMarcaService;
            _enderecoContaPessoalService = enderecoContaPessoalService;
            _cepService = cepService;
            _enderecoService = enderecoService;
            _contaFarmaciaService = contaFarmaciaService;

            _httpClient = new HttpClient();
        }

        public async Task<IList<PesquisaProduto>> GetPesquisaProdutoPorPrecoOuDistanciaAsync(PesquisaProdutoDTO pesquisaProduto)
        {
            var pesquisaProdutoList = new List<PesquisaProduto>();
            var produtosMarca = await _produtoMarcaService.GetAllProdutosMarca();
            produtosMarca = produtosMarca
               .Where(x => x.Descricao
                            .ToLower()
                            .Trim()
                            .Contains(pesquisaProduto.Busca.ToLower()
                            .Trim()))
               .ToList();

            var enderecoContaPessoal = await _enderecoContaPessoalService.GetByIdAsync(pesquisaProduto.IdContaPessoal);
            if (enderecoContaPessoal is null)
            {
                throw new ArgumentException(nameof(enderecoContaPessoal));
            }

            foreach (var produtoMarca in produtosMarca)
            {
                var itens = await _itemFarmaciaService.GetItensFarmaciaPorIdProdutoMarca(produtoMarca.IdProdutoMarca);
                foreach (var item in itens)
                {
                    var contaFarmacia = await _contaFarmaciaService.GetByIdAsync(item.IdcontaFarmacia);

                    var distancia = await GetDistanciaFromUsuarioToFarmaciaAsync(enderecoContaPessoal, contaFarmacia);

                    pesquisaProdutoList.Add(new PesquisaProduto
                    {
                        NomeFarmacia = contaFarmacia.NomeFantasia,
                        Descricao = produtoMarca.Descricao,
                        Preco = item.Preco.Value,
                        Distancia = distancia
                    });
                }
            }

            if (pesquisaProduto.TipoPesquisa == Domain.Enums.TipoPesquisaEnum.Preco)
            {
                return pesquisaProdutoList
                    .OrderBy(x => x.Preco)
                    .ToList();
            }
            else
            {
                return pesquisaProdutoList
                    .OrderBy(x => double.Parse(x.Distancia.Substring(0, x.Distancia.IndexOf(" ")), CultureInfo.InvariantCulture))
                    .ToList();
            }

        }

        private async Task<string> GetDistanciaFromUsuarioToFarmaciaAsync(EnderecoContapessoalPoco enderecoContaPessoalPoco, ContaFarmaciaPoco contaFarmaciaPoco)
        {
            var cepUser = await _cepService.GetByIdAsync(enderecoContaPessoalPoco.Idcep);
            var enderecoUser = await _enderecoService.GetEnderecoFromCEPAsync(cepUser.NumeroCep);

            var cepFarmacia = await _cepService.GetByIdAsync(contaFarmaciaPoco.Idcep);
            var enderecoFarmacia = await _enderecoService.GetEnderecoFromCEPAsync(cepFarmacia.NumeroCep);

            string requestUri = string.Format(
              "https://maps.googleapis.com/maps/api/distancematrix/json?destinations={0}&origins={1}&key={2}",
               $"{enderecoContaPessoalPoco.Numero}+{enderecoUser.Logradouro}+{enderecoUser.Bairro}+{enderecoUser.Cidade}+{enderecoUser.Uf}",
               $"{contaFarmaciaPoco.NumeroEnderecofarmacia}+{enderecoFarmacia.Logradouro}+{enderecoFarmacia.Bairro}+{enderecoFarmacia.Cidade}+{enderecoFarmacia.Uf}",
              "AIzaSyBkatcMzH8vTl8iFCdyCLU3eCIJe3pMenE");

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Result>(json);

                return result
                    .Rows
                    .FirstOrDefault()
                    .Elements
                    .FirstOrDefault()
                    .Distance
                    .Text;
            }
            return string.Empty;
        }

        private async Task<EnderecoCadastroDTO> GetEnderecoAsync(int idCep)
        {
            var cep = await _cepService.GetByIdAsync(idCep);
            return await _enderecoService.GetEnderecoFromCEPAsync(cep.NumeroCep);
        }


        private async Task GetDistanciaFromUsuarioToFarmaciaAsync(double latUser, double longUser, double latFarmacia, double longFarmacia)
        {
            var stringLatLongUser = $"{latUser},{longUser}";
            var stringLatLongFarmacia = $"{latFarmacia},{longFarmacia}";
            string requestUri = string.Format(
                  "https://maps.googleapis.com/maps/api/distancematrix/json?destinations={0}&origins={1}&key={2}",
                   stringLatLongFarmacia,
                   stringLatLongUser,
                  "AIzaSyBkatcMzH8vTl8iFCdyCLU3eCIJe3pMenE");

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //var results = JsonConvert.DeserializeObject<ResultsList>(json);

                //var location = results.Results.FirstOrDefault().Geometry.Location;

                //return (location.Lat, location.Long);
            }
            //return (0, 0);
        }
        
    }
}
