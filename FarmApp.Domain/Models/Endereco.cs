using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Ceps = new HashSet<Cep>();
        }

        public int Id { get; set; }
        public string NomeEndereco { get; set; }
        public int Idcidade { get; set; }
        public int Idbairro { get; set; }

        public virtual Bairro IdbairroNavigation { get; set; }
        public virtual Cidade IdcidadeNavigation { get; set; }
        public virtual ICollection<Cep> Ceps { get; set; }
    }
}
