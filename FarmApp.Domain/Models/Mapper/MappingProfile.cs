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
            CreateMap<ProdutoMarca, ProdutoMarcaDTO>()
                .ForMember(prd => prd.IdProdutoMarca,
                map => map.MapFrom(src => src.Id))
                .ForMember(prd => prd.Descricao,
                map => 
                map.MapFrom(src => $"{src.Produto.DescricaoProduto} {src.ApresentacaoProduto.DescricaoApresentação.Substring(0, src.ApresentacaoProduto.DescricaoApresentação.IndexOf(" "))}"));
            CreateMap<ItemClienteDTO, ItemClientePoco>();
        }
    }
}
