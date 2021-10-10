#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ContaMensagemSistemaPoco : BaseModel
    {
        public int Idconta { get; set; }
        public int IdmensagemSistema { get; set; }

        public virtual ContaPoco IdcontaNavigation { get; set; }
        public virtual MensagemSistemaPoco IdmensagemSistemaNavigation { get; set; }
    }
}
