using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {
          
        }

        public async Task<Endereco> EnderecoExistsAsync(Endereco endereco)
        {
            var enderecos = await GetAllAsync();

            var enderecoExistente = enderecos
                .Where(x => x.NomeEndereco == endereco.NomeEndereco
                    && x.Idcidade == endereco.Idcidade
                    && x.Idbairro == endereco.Idbairro)
                .FirstOrDefault();

            return enderecoExistente;
        }
    }
}
