using AutoMapper;
using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ProdutoMarcaService : BaseService<ProdutoMarcaPoco>, IProdutoMarcaService
    {
        private readonly IMarcaService _marcaService;
        private readonly IApresentacaoProdutoService _apresentacaoProdutoService;
        private readonly IProdutoService _produtoService;
        private readonly IProdutoTipoService _produtoTipoService;
        private readonly IMapper _mapper;

        public ProdutoMarcaService(
            IProdutoMarcaRepository produtoMarcaRepository,
            IMarcaService marcaService,
            IApresentacaoProdutoService apresentacaoProdutoService,
            IProdutoService produtoService,
            IProdutoTipoService produtoTipoService,
            IMapper mapper
            ) : base(produtoMarcaRepository)
        {
            _marcaService = marcaService;
            _apresentacaoProdutoService = apresentacaoProdutoService;
            _produtoService = produtoService;
            _produtoTipoService = produtoTipoService;
            _mapper = mapper;
        }
        public async Task<IList<ProdutoMarca>> GetProdutosPorTipoAsync(ProdutoDTO produtoDTO)
        {
            var produtosMarca = new List<ProdutoMarca>();
            var produtosPoco = await GetAllAsync();
            foreach (var produtoPoco in produtosPoco)
            {
                await MontaProdutoMarca(produtoPoco);
                produtosMarca.Add(_mapper.Map<ProdutoMarca>(produtoPoco));
            }
            produtosMarca = produtosMarca
                .Where(x => x.Produto.ProdutoTipo.Id == produtoDTO.IdTipoProduto)
                .ToList();
            if (!string.IsNullOrEmpty(produtoDTO.Busca))
            {
                produtosMarca = produtosMarca
                    .Where(x => x.ApresentacaoProduto.DescricaoApresentação
                            .ToLower()
                            .Trim()
                            .Contains(produtoDTO.Busca.ToLower()
                            .Trim()))
                    .ToList();
            }

            produtosMarca = produtosMarca
                .Where(x => x.Produto.ProdutoTipo.Id == produtoDTO.IdTipoProduto)
                .ToList();
            return produtosMarca;
        }

        public async Task MontaProdutoMarca(ProdutoMarcaPoco produtoPoco)
        {
            produtoPoco.Marca = await _marcaService.GetByIdAsync(produtoPoco.Idmarca);
            produtoPoco.ApresentacaoProduto = await _apresentacaoProdutoService.GetByIdAsync(produtoPoco.IdapresentacaoProduto);
            produtoPoco.Produto = await _produtoService.GetByIdAsync(produtoPoco.Idproduto);
            if (produtoPoco.Produto is null)
            {
                throw new ArgumentNullException(nameof(produtoPoco.Produto));
            }
            produtoPoco.Produto.ProdutoTipo = await _produtoTipoService.GetByIdAsync(produtoPoco.Produto.IdprodutoTipo);
            if (produtoPoco.Produto.ProdutoTipo is null)
            {
                throw new ArgumentNullException(nameof(produtoPoco.Produto));
            }
        }
    }
}
