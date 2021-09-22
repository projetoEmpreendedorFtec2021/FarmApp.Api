using FarmApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ProdutoTipoMapping : IEntityTypeConfiguration<ProdutoTipo>
    {
        public void Configure(EntityTypeBuilder<ProdutoTipo> entity)
        {
            entity.ToTable("produto_tipo");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.DescricaoTipoProduto)
                .HasMaxLength(45)
                .HasColumnName("descricao_tipo_produto");
        }
    }
}
