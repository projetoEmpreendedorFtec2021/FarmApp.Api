using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ItemCliente : BaseModel
    {
        public ItemCliente()
        {
            PesquisaPrecos = new HashSet<PesquisaPreco>();
        }

        public int Idcliente { get; set; }
        public int IdprodutoMarca { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual ProdutoMarca IdprodutoMarcaNavigation { get; set; }
        public virtual ICollection<PesquisaPreco> PesquisaPrecos { get; set; }
    }
}
