using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IProdutoMarcaService : IBaseService<ProdutoMarcaPoco>
    {
        Task<IList<ProdutoMarca>> GetProdutosPorTipoAsync(ProdutoDTO produtoDTO);
        Task MontaProdutoMarca(ProdutoMarcaPoco produtoPoco);
    }
}
