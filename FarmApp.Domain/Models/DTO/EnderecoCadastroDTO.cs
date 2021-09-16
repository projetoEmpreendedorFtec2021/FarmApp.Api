namespace FarmApp.Domain.Models.DTO
{
    public class EnderecoCadastroDTO
    {
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string EnderecoFormatado { get; set; }
    }
}
