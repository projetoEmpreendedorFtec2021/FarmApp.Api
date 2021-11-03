using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class CidadePoco : BaseModel
    {
        public CidadePoco()
        {
            Enderecos = new HashSet<EnderecoPoco>();
        }
   
        public string NomeCidade { get; set; }
        public int Iduf { get; set; }

        public virtual ICollection<EnderecoPoco> Enderecos { get; set; }
    }
}
