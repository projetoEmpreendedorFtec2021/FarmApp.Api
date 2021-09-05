using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IEnderecoService : IBaseService<Endereco>
    {
        Task<EnderecoDTO> GetEnderecoFromCEPAsync(string CEP);
        Task<int> GetIdEnderecoAsync(string nomeEndereco, int idCidade, int idBairro);
    }
}
