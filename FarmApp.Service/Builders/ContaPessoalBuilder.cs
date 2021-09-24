using FarmApp.Domain.Models.Poco;

namespace FarmApp.Service.Builders
{
    public class ContaPessoalBuilder
    {
        private ContaPessoalPoco _contaPessoal = new ContaPessoalPoco();

        private ContaPessoalBuilder()
        {

        }
        public static ContaPessoalBuilder Init()
        {
            return new ContaPessoalBuilder();
        }

        public ContaPessoalPoco Build() => _contaPessoal;

        public ContaPessoalBuilder SetTemFarmacia(bool temFarmacia)
        {
            _contaPessoal.TemFarmacia = temFarmacia ? 1 : 0;
            return this;
        }
    }
}
