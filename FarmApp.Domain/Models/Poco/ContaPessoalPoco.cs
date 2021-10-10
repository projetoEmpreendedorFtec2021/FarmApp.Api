using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ContaPessoalPoco : BaseModel
    {
        public ContaPessoalPoco()
        {
            Conta = new HashSet<ContaPoco>();
            EnderecoContapessoals = new HashSet<EnderecoContapessoalPoco>();
        }

        public int? TemFarmacia { get; set; }

        public virtual ICollection<ContaPoco> Conta { get; set; }
        public virtual ICollection<EnderecoContapessoalPoco> EnderecoContapessoals { get; set; }
    }
}
