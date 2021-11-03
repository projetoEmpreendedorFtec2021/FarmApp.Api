using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<ProdutoPoco>
    {
        public void Configure(EntityTypeBuilder<ProdutoPoco> entity)
        {
            entity.ToTable("produto");

            entity.HasIndex(e => e.IdprodutoTipo, "fk_produto_produto_tipo1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.DescricaoProduto)
                .HasMaxLength(255)
                .HasColumnName("descricao_produto");

            entity.Property(e => e.IdprodutoTipo)
                .HasColumnType("int(11)")
                .HasColumnName("idproduto_tipo");

            entity.HasOne(d => d.ProdutoTipo)
                .WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdprodutoTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto_produto_tipo1");
        }
    }
}
