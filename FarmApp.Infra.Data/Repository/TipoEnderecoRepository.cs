using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class TipoEnderecoRepository : BaseRepository<TipoEnderecoPoco>, ITipoEnderecoRepository
    {
        public TipoEnderecoRepository(Db_FarmAppContext db) : base(db)
        {

        }

        public async Task<TipoEnderecoPoco> GetTipoEnderecoPorNomeAsync(string nome)
        {
            var tiposEnderecos = await GetAllAsync();

            return tiposEnderecos
                .Where(x => x.NomeTipoEndereco == nome)
                .FirstOrDefault();
        }
    }
}
