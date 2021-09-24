using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IProdutoMarcaService : IBaseService<ProdutoMarcaPoco>
    {
        Task<ProdutoMarcaDTO> GetProdutosPorTipoAsync(ProdutoDTO produtoDTO);
    }
}
