using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IEnderecoService : IBaseService<Endereco>
    {
        Task<EnderecoCadastroDTO> GetEnderecoFromCEPAsync(string CEP);
        Task<int> GetIdEnderecoAsync(string nomeEndereco, int idCidade, int idBairro);
        Task<EnderecoCadastroDTO> GetEnderecoFromLatLong(EnderecoLatLongDTO endereco);
        Task<Endereco> AddEnderecoIfNotExistsAsync(string nomeEndereco, int idCidade, int idBairro);
        Task<bool> AddEnderecoCompletoAsync(EnderecoLatLongDTO enderecoLatLong);
    }
}
