using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Domain.Models.DTO
{
    public class EnderecoDTO
    {
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
    }
}
