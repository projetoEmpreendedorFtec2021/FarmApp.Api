using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ProdutoMarcaMapping : IEntityTypeConfiguration<ProdutoMarcaPoco>
    {
        public void Configure(EntityTypeBuilder<ProdutoMarcaPoco> entity)
        {
            entity.ToTable("produto_marca");

            entity.HasIndex(e => e.IdapresentacaoProduto, "fk_produto_marca_apresentacao_produto1_idx");

            entity.HasIndex(e => e.Idmarca, "fk_produto_marca_marca1_idx");

            entity.HasIndex(e => e.Idproduto, "fk_produto_marca_produto1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.CodigoProdutoMarca)
                .HasMaxLength(20)
                .HasColumnName("codigo_produto_marca");

            entity.Property(e => e.IdapresentacaoProduto)
                .HasColumnType("int(11)")
                .HasColumnName("idapresentacao_produto");

            entity.Property(e => e.Idmarca)
                .HasColumnType("int(11)")
                .HasColumnName("idmarca");

            entity.Property(e => e.Idproduto)
                .HasColumnType("int(11)")
                .HasColumnName("idproduto");

            entity.HasOne(d => d.ApresentacaoProduto)
                .WithMany(p => p.ProdutoMarcas)
                .HasForeignKey(d => d.IdapresentacaoProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto_marca_apresentacao_produto1");

            entity.HasOne(d => d.Marca)
                .WithMany(p => p.ProdutoMarcas)
                .HasForeignKey(d => d.Idmarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto_marca_marca1");

            entity.HasOne(d => d.Produto)
                .WithMany(p => p.ProdutoMarcas)
                .HasForeignKey(d => d.Idproduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto_marca_produto1");
        }
    }
}
