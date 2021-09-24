using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class EnderecoPoco : BaseModel
    {
        public EnderecoPoco()
        {
            Ceps = new HashSet<CepPoco>();
        }

        public string NomeEndereco { get; set; }
        public int Idcidade { get; set; }
        public int Idbairro { get; set; }

        public virtual BairroPoco IdbairroNavigation { get; set; }
        public virtual CidadePoco IdcidadeNavigation { get; set; }
        public virtual ICollection<CepPoco> Ceps { get; set; }
    }
}
