namespace FarmApp.Domain.Models.DTO
{
    public abstract class ContaDTO
    {
        public string CEP { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
