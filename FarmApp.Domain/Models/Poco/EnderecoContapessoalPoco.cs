#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class EnderecoContapessoalPoco : BaseModel
    {
        public int IdtipoEndereco { get; set; }
        public int Idcep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string LatLong { get; set; }
        public int IdcontaPessoal { get; set; }

        public virtual CepPoco IdcepNavigation { get; set; }
        public virtual ContaPessoalPoco IdcontaPessoalNavigation { get; set; }
        public virtual TipoEnderecoPoco IdtipoEnderecoNavigation { get; set; }
    }
}
