using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class BairroPoco : BaseModel
    {
        public BairroPoco()
        {
            Enderecos = new HashSet<EnderecoPoco>();
        }

        public string NomeBairro { get; set; }

        public virtual ICollection<EnderecoPoco> Enderecos { get; set; }
    }
}
