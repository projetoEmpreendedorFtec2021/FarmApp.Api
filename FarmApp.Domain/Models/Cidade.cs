using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Cidade : BaseModel
    {
        public Cidade()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public string NomeCidade { get; set; }
        public int Iduf { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
