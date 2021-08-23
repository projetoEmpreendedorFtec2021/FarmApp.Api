using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Marca
    {
        public Marca()
        {
            ProdutoMarcas = new HashSet<ProdutoMarca>();
        }

        public int Id { get; set; }
        public string NomeMarca { get; set; }

        public virtual ICollection<ProdutoMarca> ProdutoMarcas { get; set; }
    }
}
