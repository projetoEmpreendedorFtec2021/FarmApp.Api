using System.Collections.Generic;

namespace FarmApp.Domain.Models.DTO
{
    public class ItemClienteDTO
    {
        public int IdCliente { get; set; }
        public IList<int> IdsProdutoMarca { get; set; }
    }
}
