using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class TipoEnderecoPoco : BaseModel
    {
        public TipoEnderecoPoco()
        {
            EnderecoContapessoals = new HashSet<EnderecoContapessoalPoco>();
        }

        public string NomeTipoEndereco { get; set; }

        public virtual ICollection<EnderecoContapessoalPoco> EnderecoContapessoals { get; set; }
    }
}
