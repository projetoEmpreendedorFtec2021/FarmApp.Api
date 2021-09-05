using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class TipoEnderecoService : BaseService<TipoEndereco>, ITipoEnderecoService
    {
        private readonly ITipoEnderecoRepository _tipoEnderecoRepository;
        public TipoEnderecoService(ITipoEnderecoRepository tipoEnderecoRepository) : base(tipoEnderecoRepository)
        {
            _tipoEnderecoRepository = tipoEnderecoRepository;
        }

        public async Task<TipoEndereco> GetTipoEnderecoByNomeAsync(string nome)
        {
            return await _tipoEnderecoRepository.GetTipoEnderecoPorNomeAsync(nome);
        }
    }
}
