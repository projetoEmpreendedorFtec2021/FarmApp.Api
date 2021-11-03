using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ApresentacaoProdutoMapping : IEntityTypeConfiguration<ApresentacaoProdutoPoco>
    {
        public void Configure(EntityTypeBuilder<ApresentacaoProdutoPoco> entity)
        {
            entity.ToTable("apresentacao_produto");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.DescricaoApresentação)
                .HasMaxLength(150)
                .HasColumnName("descricao_apresentação");
        }
    }
}
