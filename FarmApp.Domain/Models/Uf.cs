﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Uf : BaseModel
    {
        public Uf()
        {
            Cidades = new HashSet<Cidade>();
        }

        public string NomeUf { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
