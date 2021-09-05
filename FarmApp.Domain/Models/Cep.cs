using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Cep : BaseModel
    {
        public Cep()
        {
            ContaFarmacia = new HashSet<ContaFarmacia>();
            EnderecoContapessoals = new HashSet<EnderecoContapessoal>();
        }

        public string NumeroCep { get; set; }
        public int Idendereco { get; set; }

        public virtual Endereco IdenderecoNavigation { get; set; }
        public virtual ICollection<ContaFarmacia> ContaFarmacia { get; set; }
        public virtual ICollection<EnderecoContapessoal> EnderecoContapessoals { get; set; }
    }
}
