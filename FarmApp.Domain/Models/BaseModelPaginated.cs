using System.Collections.Generic;

namespace FarmApp.Domain.Models
{
    public abstract class BaseModelPaginated
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
    }
}
