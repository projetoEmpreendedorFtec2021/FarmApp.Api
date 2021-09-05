using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ContaPessoal : BaseModel
    {
        public ContaPessoal()
        {
            Conta = new HashSet<Conta>();
            EnderecoContapessoals = new HashSet<EnderecoContapessoal>();
        }

        public int? TemFarmacia { get; set; }

        public virtual ICollection<Conta> Conta { get; set; }
        public virtual ICollection<EnderecoContapessoal> EnderecoContapessoals { get; set; }
    }
}
