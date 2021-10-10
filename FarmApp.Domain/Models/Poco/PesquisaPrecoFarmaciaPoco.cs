#nullable disable

using FarmApp.Domain.Models.Poco;

namespace FarmApp.Domain.Models.Poco
{
    public partial class PesquisaPrecoFarmaciaPoco : BaseModel
    {
        public int Idpesquisa { get; set; }
        public int IditemFarmacia { get; set; }

        public virtual ItemFarmaciaPoco IditemFarmaciaNavigation { get; set; }
        public virtual PesquisaPrecoPoco IdpesquisaNavigation { get; set; }
    }
}
