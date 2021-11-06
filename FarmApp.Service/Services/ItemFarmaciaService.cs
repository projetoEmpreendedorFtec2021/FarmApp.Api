using AutoMapper;
using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ItemFarmaciaService : BaseService<ItemFarmaciaPoco>, IItemFarmaciaService
    {
        private readonly IProdutoMarcaService _produtoMarcaService;
        private readonly IContaFarmaciaService _contaFarmaciaService;

        private readonly IMapper _mapper;
        public ItemFarmaciaService(
            IItemFarmaciaRepository itemFarmaciaRepository,
            IProdutoMarcaService produtoMarcaService,
            IContaFarmaciaService contaFarmaciaService,
            IMapper mapper) : base(itemFarmaciaRepository)
        {
            _produtoMarcaService = produtoMarcaService;
            _contaFarmaciaService = contaFarmaciaService;
            _mapper = mapper;
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
    }
}
