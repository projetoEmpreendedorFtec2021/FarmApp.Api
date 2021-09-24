using System.Collections.Generic;

namespace FarmApp.Domain.Models
{
    public abstract class ResponsePaginated<T>
    {
        public IList<T> Itens { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int Total { get; set; }
    }
}
