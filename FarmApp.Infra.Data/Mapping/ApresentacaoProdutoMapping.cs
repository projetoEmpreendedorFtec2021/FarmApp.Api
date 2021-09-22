using FarmApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ApresentacaoProdutoMapping : IEntityTypeConfiguration<ApresentacaoProduto>
    {
        public void Configure(EntityTypeBuilder<ApresentacaoProduto> entity)
        {
            entity.ToTable("apresentacao_produto");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.DescricaoApresentação)
                .HasMaxLength(30)
                .HasColumnName("descricao_apresentação");
        }
    }
}
