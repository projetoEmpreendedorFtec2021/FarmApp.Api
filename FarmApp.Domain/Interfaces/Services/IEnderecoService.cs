using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IEnderecoService : IBaseService<EnderecoPoco>
    {
        Task<EnderecoCadastroDTO> GetEnderecoFromCEPAsync(string CEP);
        Task<int> GetIdEnderecoAsync(string nomeEndereco, int idCidade, int idBairro);
        Task<EnderecoCadastroDTO> GetEnderecoFromLatLong(EnderecoLatLongDTO endereco);
        Task<EnderecoPoco> AddEnderecoIfNotExistsAsync(string nomeEndereco, int idCidade, int idBairro);
        Task<bool> AddEnderecoCompletoAsync(EnderecoLatLongDTO enderecoLatLong);
    }
}
