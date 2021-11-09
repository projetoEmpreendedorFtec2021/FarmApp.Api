using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.Poco;
using System;

namespace FarmApp.Service.Builders
{
    public class ItemFarmaciaBuilder
    {
        private readonly ItemFarmaciaPoco _itemFarmacia = new ItemFarmaciaPoco();
        private readonly IProdutoMarcaService _produtoMarcaService;
        private readonly IContaFarmaciaService _contaFarmaciaService;
        private ItemFarmaciaBuilder(
            IProdutoMarcaService produtoMarcaService,
            IContaFarmaciaService contaFarmaciaService)
        {
            _produtoMarcaService = produtoMarcaService;
            _contaFarmaciaService = contaFarmaciaService;
        }

        public static ItemFarmaciaBuilder Init(
            IProdutoMarcaService produtoMarcaService,
            IContaFarmaciaService contaFarmaciaService)
        {
            return new ItemFarmaciaBuilder(produtoMarcaService, contaFarmaciaService);
        }

        public ItemFarmaciaPoco Build() => _itemFarmacia;

        public ItemFarmaciaBuilder SetIdProdutoMarca(int idProdutoMarca)
        {
            _itemFarmacia.IdprodutoMarca = idProdutoMarca;
            return this;
        }

        public ItemFarmaciaBuilder SetIdContaFarmacia(int idContaFarmacia)
        {
            _itemFarmacia.IdcontaFarmacia = idContaFarmacia;
            return this;
        }

        public ItemFarmaciaBuilder SetCodigoItemFarmacia(string codigoItemFarmacia)
        {
            _itemFarmacia.CodigoItemFarmacia = codigoItemFarmacia;
            return this;
        }

        public ItemFarmaciaBuilder SetPreco(double preco)
        {
            _itemFarmacia.Preco = preco;
            return this;
        }
    }
}
