#nullable disable

using FarmApp.Domain.Models.Poco;

namespace FarmApp.Domain.Models
{
    public partial class PesquisaPrecoFarmacia : BaseModel
    {
        public int Idpesquisa { get; set; }
        public int IditemFarmacia { get; set; }

        public virtual ItemFarmaciaPoco IditemFarmaciaNavigation { get; set; }
        public virtual PesquisaPrecoPoco IdpesquisaNavigation { get; set; }
    }
}
