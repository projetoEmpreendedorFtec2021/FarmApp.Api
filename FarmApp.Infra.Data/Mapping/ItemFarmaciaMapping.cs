using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ItemFarmaciaMapping : IEntityTypeConfiguration<ItemFarmaciaPoco>
    {
        public void Configure(EntityTypeBuilder<ItemFarmaciaPoco> entity)
        {
            entity.ToTable("item_farmacia");

            entity.HasIndex(e => e.IdcontaFarmacia, "fk_item_farmacia_conta_farmacia1_idx");

            entity.HasIndex(e => e.IdprodutoMarca, "fk_item_farmacia_produto_marca1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.CodigoItemFarmacia)
                .HasMaxLength(20)
                .HasColumnName("codigo_item_farmacia");

            entity.Property(e => e.IdcontaFarmacia)
                .HasColumnType("int(11)")
                .HasColumnName("idconta_farmacia");

            entity.Property(e => e.IdprodutoMarca)
                .HasColumnType("int(11)")
                .HasColumnName("idproduto_marca");

            entity.Property(e => e.Preco).HasColumnName("preco");

            entity.HasOne(d => d.IdcontaFarmaciaNavigation)
                .WithMany(p => p.ItemFarmacia)
                .HasForeignKey(d => d.IdcontaFarmacia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_farmacia_conta_farmacia1");

            entity.HasOne(d => d.IdprodutoMarcaNavigation)
                .WithMany(p => p.ItemFarmacia)
                .HasForeignKey(d => d.IdprodutoMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_farmacia_produto_marca1");
        }
    }
}
