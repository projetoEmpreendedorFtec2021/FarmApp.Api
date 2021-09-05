using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class TipoEndereco : BaseModel
    {
        public TipoEndereco()
        {
            EnderecoContapessoals = new HashSet<EnderecoContapessoal>();
        }

        public string NomeTipoEndereco { get; set; }

        public virtual ICollection<EnderecoContapessoal> EnderecoContapessoals { get; set; }
    }
}
