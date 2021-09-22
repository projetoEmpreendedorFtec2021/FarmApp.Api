using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ApresentacaoProdutoRepository : BaseRepository<ApresentacaoProduto>, IApresentacaoProdutoRepository
    {
        public ApresentacaoProdutoRepository(Db_FarmAppContext db) : base(db)
        {

        }
    }
}
