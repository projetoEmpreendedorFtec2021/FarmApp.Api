using AutoMapper;
using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ItemFarmaciaService : BaseService<ItemFarmaciaPoco>, IItemFarmaciaService
    {
        private readonly IProdutoMarcaService _produtoMarcaService;
        private readonly IContaFarmaciaService _contaFarmaciaService;

        private readonly IMapper _mapper;

        private readonly IItemFarmaciaRepository _itemFarmaciaRepository;
        public ItemFarmaciaService(
            IItemFarmaciaRepository itemFarmaciaRepository,
            IProdutoMarcaService produtoMarcaService,
            IContaFarmaciaService contaFarmaciaService,
            IMapper mapper) : base(itemFarmaciaRepository)
        {
            _produtoMarcaService = produtoMarcaService;
            _contaFarmaciaService = contaFarmaciaService;
            _mapper = mapper;
            _itemFarmaciaRepository = itemFarmaciaRepository;
        }

        public async Task<bool> AddOrUpdateItensFarmaciaAsync(IList<ItemFarmaciaDTO> itens)
        {
            bool atualizouOuCriouItem = true;
            foreach (var item in itens)
            {
                ItemFarmaciaPoco itemFarmaciaAdicionadoOuAtualizado;
                if (item.IdItemFarmacia is null)
                {
                    var itemFarmacia = ItemFarmaciaBuilder
                      .Init(_produtoMarcaService, _contaFarmaciaService)
                      .SetIdProdutoMarca(item.IdProdutoMarca)
                      .SetIdContaFarmacia(item.IdContaFarmacia)
                      .SetCodigoItemFarmacia(item.CodigoItemFarmacia)
                      .SetPreco(item.Preco)
                      .Build();

                    itemFarmaciaAdicionadoOuAtualizado = await AddAsync<ItemFarmaciaValidator>(itemFarmacia);
                }
                else
                {
                    var itemFarmaciaPoco = _mapper.Map<ItemFarmaciaPoco>(item);

                    itemFarmaciaAdicionadoOuAtualizado = await UpdateAsync<ItemFarmaciaValidator>(itemFarmaciaPoco);
                }

                atualizouOuCriouItem &= itemFarmaciaAdicionadoOuAtualizado != null;
            }

            return atualizouOuCriouItem;
        }

        public async Task DeleteItemFarmaciaAsync(int idItemFarmacia)
        {
            await DeleteAsync(idItemFarmacia);
        }

        public async Task<IList<ProdutoMarcaItemFarmacia>> GetProdutosMarcaItemFarmaciaAsync(ProdutoMarcaItemFarmaciaDTO produto)
        {
            var produtosMarcaItemFarmacia = new List<ProdutoMarcaItemFarmacia>();

            var itensFarmacia = await _itemFarmaciaRepository.GetItensFarmaciaByIdContaFarmaciaAsync(produto.IdContaFarmacia);

            var produtosMarcaPoco = await _produtoMarcaService.GetAllAsync();
            produtosMarcaPoco = produtosMarcaPoco
                .Take(10)
                .ToList();

            foreach(var produtoMarcaPoco in produtosMarcaPoco)
            {
                await _produtoMarcaService.MontaProdutoMarca(produtoMarcaPoco);
                if(produtoMarcaPoco.Produto.IdprodutoTipo == produto.IdTipoProduto)
                {
                    var produtoMarcaItemFarmacia = new ProdutoMarcaItemFarmacia();
                    var produtoMarca = _mapper.Map<ProdutoMarca>(produtoMarcaPoco);
                    produtoMarcaItemFarmacia.ProdutoMarca = _mapper.Map<ProdutoMarcaDTO>(produtoMarca);

                    if (itensFarmacia.Select(x => x.IdprodutoMarca).Contains(produtoMarcaPoco.Id))
                    {
                        MontaProdutoMarcaItemFarmacia(itensFarmacia, produtoMarcaPoco, produtoMarcaItemFarmacia);
                    }

                    produtosMarcaItemFarmacia.Add(produtoMarcaItemFarmacia);
                }
            }

            if (!string.IsNullOrEmpty(produto.Busca))
            {
                produtosMarcaItemFarmacia = produtosMarcaItemFarmacia
                    .Where(x => x.ProdutoMarca.Descricao
                            .ToLower()
                            .Trim()
                            .Contains(produto.Busca.ToLower()))
                    .ToList();
            }

            return produtosMarcaItemFarmacia;

        }

        private void MontaProdutoMarcaItemFarmacia(
            IList<ItemFarmaciaPoco> itensFarmaciaPoco, 
            ProdutoMarcaPoco produtoMarcaPoco, 
            ProdutoMarcaItemFarmacia produtoMarcaItemFarmacia)
        {
            var itensFarmaciaFromProdutoMarca = itensFarmaciaPoco
                       .Where(x => x.IdprodutoMarca == produtoMarcaPoco.Id)
                       .ToList();

            produtoMarcaItemFarmacia.IdItemFarmacia = itensFarmaciaFromProdutoMarca
                .Select(x => x.Id)
                .FirstOrDefault();

            produtoMarcaItemFarmacia.Preco = itensFarmaciaFromProdutoMarca
                .Select(x => x.Preco.Value)
                .FirstOrDefault();

            produtoMarcaItemFarmacia.CodigoItemFarmacia = itensFarmaciaFromProdutoMarca
                .Select(x => x.CodigoItemFarmacia)
                .FirstOrDefault();
        }
    }
}
