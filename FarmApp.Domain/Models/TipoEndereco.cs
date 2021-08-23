using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class TipoEndereco
    {
        public TipoEndereco()
        {
            EnderecoContapessoals = new HashSet<EnderecoContapessoal>();
        }

        public int Id { get; set; }
        public string NomeTipoEndereco { get; set; }

        public virtual ICollection<EnderecoContapessoal> EnderecoContapessoals { get; set; }
    }
}
