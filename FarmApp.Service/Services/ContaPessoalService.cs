using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ContaPessoalService : BaseService<ContaPessoalPoco>, IContaPessoalService
    {
        public ContaPessoalService(IContaPessoalRepository contaPessoalRepository) : base(contaPessoalRepository)
        {

        }

        public async Task<int> GetIdContaPessoalAsync()
        {
            ContaPessoalPoco contaPessoal = ContaPessoalBuilder
                .Init()
                .SetTemFarmacia(false)
                .Build();

            contaPessoal = await AddAsync<ContaPessoalValidator>(contaPessoal);
            return contaPessoal.Id;

        }
    }
}
