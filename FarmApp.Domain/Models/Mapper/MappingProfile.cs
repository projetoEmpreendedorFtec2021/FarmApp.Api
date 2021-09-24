using AutoMapper;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;

namespace FarmApp.Domain.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<ProdutoTipoPoco, ProdutoTipo>();
            CreateMap<ProdutoPoco, Produto>();
            CreateMap<MarcaPoco, Marca>();
            CreateMap<ApresentacaoProdutoPoco, ApresentacaoProduto>();
            CreateMap<ProdutoMarcaPoco, ProdutoMarca>();
        }
    }
}
