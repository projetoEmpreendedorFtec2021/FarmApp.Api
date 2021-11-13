using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IPesquisaProdutoService
    {
        Task<IList<PesquisaProduto>> GetPesquisaProdutoPorPrecoOuDistanciaAsync(PesquisaProdutoDTO pesquisaProduto);
    }
}
