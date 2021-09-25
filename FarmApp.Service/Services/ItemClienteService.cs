using AutoMapper;
using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ItemClienteService : BaseService<ItemClientePoco>, IItemClienteService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoMarcaService _produtoMarcaService;
        public ItemClienteService(
            IItemClienteRepository itemClienteRepository,
            IMapper mapper,
            IProdutoMarcaService produtoMarcaService) : base(itemClienteRepository)
        {
            _mapper = mapper;
            _produtoMarcaService = produtoMarcaService;
        }

        public async Task<bool> AddItensClienteAsync(ItemClienteDTO itemClienteDTO)
        {
            if(itemClienteDTO is null)
            {
                throw new ArgumentNullException(nameof(itemClienteDTO));
            }
            bool addedAllItens = true;
            foreach (var idProdutoMarca in itemClienteDTO.IdsProdutoMarca)
            {
                var itemClientePoco = new ItemClientePoco
                {
                    IdCliente = itemClienteDTO.IdCliente,
                    IdProdutoMarca = idProdutoMarca
                };
                var itemClientePocoIncluded = await AddAsync<ItemClienteValidator>(itemClientePoco);
                addedAllItens &= itemClientePocoIncluded != null;
            }
            return addedAllItens;
        }

        public async Task<IList<ProdutoMarcaDTO>> GetAllItensCliente(int idCliente)
        {
            var listaClientePoco = await GetAllAsync();
            listaClientePoco = listaClientePoco.Where(x => x.IdCliente == idCliente).ToList();
            var produtosPorCliente = new List<ProdutoMarcaDTO>();
            foreach(var listaCliente in listaClientePoco)
            {
                var produtoMarcaPoco = await _produtoMarcaService.GetByIdAsync(listaCliente.IdProdutoMarca);
                if(produtoMarcaPoco is null)
                {
                    throw new KeyNotFoundException(nameof(listaCliente.IdProdutoMarca));
                }
                await _produtoMarcaService.MontaProdutoMarca(produtoMarcaPoco);
                var produtoMarca = _mapper.Map<ProdutoMarca>(produtoMarcaPoco);
                produtosPorCliente.Add(_mapper.Map<ProdutoMarcaDTO>(produtoMarca));
            }
            return produtosPorCliente;
        }
    }
}
