using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Cliente : BaseModel
    {
        public Cliente()
        {
            ClienteConsentimentos = new HashSet<ClienteConsentimento>();
            ItemClientes = new HashSet<ItemCliente>();
            PesquisaPrecos = new HashSet<PesquisaPreco>();
        }

        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public int? Idconta { get; set; }

        public virtual Conta IdcontaNavigation { get; set; }
        public virtual ICollection<ClienteConsentimento> ClienteConsentimentos { get; set; }
        public virtual ICollection<ItemCliente> ItemClientes { get; set; }
        public virtual ICollection<PesquisaPreco> PesquisaPrecos { get; set; }
    }
}
