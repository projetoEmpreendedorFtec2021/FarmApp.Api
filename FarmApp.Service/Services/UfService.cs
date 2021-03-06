using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class UfService : BaseService<UfPoco>, IUfService
    {
        private readonly IUfRepository _ufRepository;
        public UfService(IUfRepository ufRepository) : base(ufRepository)
        {
            _ufRepository = ufRepository;
        }

        public async Task<int> GetIdUfAsync(string nomeUf)
        {
            UfPoco uf = UfBuilder
                .Init()
                .SetNomeUf(nomeUf)
                .Build();

            var ufExistente = await _ufRepository.GetUfByNomeAsync(nomeUf);

            if (ufExistente is null)
            {
                ufExistente = await AddAsync<UfValidator>(uf);
            }

            return ufExistente.Id;
        }
    }
}
