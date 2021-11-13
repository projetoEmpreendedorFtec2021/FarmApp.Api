using FarmApp.Domain.Enums;

namespace FarmApp.Domain.Models.DTO
{
    public class PesquisaProdutoDTO
    {
        public string Busca { get; set; }
        public TipoOrdenacaoEnum TipoOrdenacao { get; set; }
        public int IdContaPessoal { get; set; }
    }
}
