using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class CepPoco : BaseModel
    {
        public CepPoco()
        {
            ContaFarmacia = new HashSet<ContaFarmaciaPoco>();
            EnderecoContapessoals = new HashSet<EnderecoContapessoalPoco>();
        }

        public string NumeroCep { get; set; }
        public int Idendereco { get; set; }

        public virtual EnderecoPoco IdenderecoNavigation { get; set; }
        public virtual ICollection<ContaFarmaciaPoco> ContaFarmacia { get; set; }
        public virtual ICollection<EnderecoContapessoalPoco> EnderecoContapessoals { get; set; }
    }
}
