using FarmApp.Domain.Enums;

namespace FarmApp.Domain.Models.DTO
{
    public class PesquisaProdutoDTO
    {
        public string Busca { get; set; }
        public TipoPesquisaEnum TipoPesquisa { get; set; }
        public int IdContaPessoal { get; set; }
    }
}
