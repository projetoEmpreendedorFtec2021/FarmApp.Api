using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ClientePoco : BaseModel
    {
        public ClientePoco()
        {
            Consentimentos = new HashSet<ConsentimentoPoco>();
            ItemClientes = new HashSet<ItemClientePoco>();
            PesquisaPrecos = new HashSet<PesquisaPrecoPoco>();
        }
     
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public int? Idconta { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? ValidaEmail { get; set; }

        public virtual ContaPoco IdcontaNavigation { get; set; }
        public virtual ICollection<ConsentimentoPoco> Consentimentos { get; set; }
        public virtual ICollection<ItemClientePoco> ItemClientes { get; set; }
        public virtual ICollection<PesquisaPrecoPoco> PesquisaPrecos { get; set; }
    }
}
