using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Bairro : BaseModel
    {
        public Bairro()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public string NomeBairro { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
