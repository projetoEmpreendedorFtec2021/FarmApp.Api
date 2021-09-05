#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class EnderecoContapessoal : BaseModel
    {
        public int IdtipoEndereco { get; set; }
        public int Idcep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string LatLong { get; set; }
        public int IdcontaPessoal { get; set; }

        public virtual Cep IdcepNavigation { get; set; }
        public virtual ContaPessoal IdcontaPessoalNavigation { get; set; }
        public virtual TipoEndereco IdtipoEnderecoNavigation { get; set; }
    }
}
