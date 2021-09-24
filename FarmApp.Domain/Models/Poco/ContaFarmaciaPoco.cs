using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ContaFarmaciaPoco : BaseModel
    {
        public ContaFarmaciaPoco()
        {
            Conta = new HashSet<ContaPoco>();
            ItemFarmacia = new HashSet<ItemFarmaciaPoco>();
        }

        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Alvara { get; set; }
        public string Endereco { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int Idcep { get; set; }
        public string NumeroEndereçofarmacia { get; set; }
        public string LatilongFarmacia { get; set; }

        public virtual CepPoco IdcepNavigation { get; set; }
        public virtual ICollection<ContaPoco> Conta { get; set; }
        public virtual ICollection<ItemFarmaciaPoco> ItemFarmacia { get; set; }
    }
}
