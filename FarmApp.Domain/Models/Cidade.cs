using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public string NomeCidade { get; set; }
        public int Iduf { get; set; }

        public virtual Uf IdufNavigation { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
