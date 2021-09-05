#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class PesquisaPrecoFarmacia : BaseModel
    {
        public int Idpesquisa { get; set; }
        public int IditemFarmacia { get; set; }

        public virtual ItemFarmacia IditemFarmaciaNavigation { get; set; }
        public virtual PesquisaPreco IdpesquisaNavigation { get; set; }
    }
}
