#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ContaMensagemSistema : BaseModel
    {
        public int Idconta { get; set; }
        public int IdmensagemSistema { get; set; }

        public virtual Conta IdcontaNavigation { get; set; }
        public virtual MensagemSistema IdmensagemSistemaNavigation { get; set; }
    }
}
