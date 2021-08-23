using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class EnderecoContapessoal
    {
        public EnderecoContapessoal()
        {
            ContaPessoals = new HashSet<ContaPessoal>();
        }

        public int Id { get; set; }
        public int IdtipoEndereco { get; set; }
        public int Idcep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string LatLong { get; set; }

        public virtual Cep IdcepNavigation { get; set; }
        public virtual TipoEndereco IdtipoEnderecoNavigation { get; set; }
        public virtual ICollection<ContaPessoal> ContaPessoals { get; set; }
    }
}
