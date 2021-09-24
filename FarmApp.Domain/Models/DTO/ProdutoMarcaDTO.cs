using System.Collections.Generic;

namespace FarmApp.Domain.Models.DTO
{
    public class ProdutoMarcaDTO : ResponsePaginated<ProdutoMarca>
    {
        public ProdutoMarcaDTO()
        {
            Itens = new List<ProdutoMarca>();
        }
    }
}
