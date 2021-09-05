using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class CidadeService : BaseService<Cidade>, ICidadeService
    {
        private readonly IUfRepository _ufRepository;
        private readonly ICidadeRepository _cidadeRepository;
        public CidadeService(
            ICidadeRepository cidadeRepository,
            IUfRepository ufRepository) : base(cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
            _ufRepository = ufRepository;
        }

        public async Task<int> GetIdCidadeAsync(string nomeCidade, int idUf)
        {
            Cidade cidade = CidadeBuilder
                .Init(_ufRepository)
                .SetNomeCidade(nomeCidade)
                .SetIdUf(idUf)
                .Build();

            var cidadeExistente = await _cidadeRepository.GetCidadeIfExists(nomeCidade, idUf);
            if(cidadeExistente is null)
            {
                cidadeExistente = await AddAsync<CidadeValidator>(cidade);
            }
            return cidadeExistente.Id;
        }

    }
}
