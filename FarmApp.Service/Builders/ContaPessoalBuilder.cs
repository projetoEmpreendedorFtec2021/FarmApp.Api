using FarmApp.Domain.Models;

namespace FarmApp.Service.Builders
{
    public class ContaPessoalBuilder
    {
        private ContaPessoal _contaPessoal = new ContaPessoal();

        private ContaPessoalBuilder()
        {

        }
        public static ContaPessoalBuilder Init()
        {
            return new ContaPessoalBuilder();
        }

        public ContaPessoal Build() => _contaPessoal;

        public ContaPessoalBuilder SetTemFarmacia(bool temFarmacia)
        {
            _contaPessoal.TemFarmacia = temFarmacia ? 1 : 0;
            return this;
        }
    }
}
