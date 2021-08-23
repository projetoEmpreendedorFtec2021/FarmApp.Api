using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Bairro
    {
        public Bairro()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public string NomeBairro { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
