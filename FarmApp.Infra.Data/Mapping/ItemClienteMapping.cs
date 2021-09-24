using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ItemClienteMapping : IEntityTypeConfiguration<ItemClientePoco>
    {
        public void Configure(EntityTypeBuilder<ItemClientePoco> entity)
        {
            entity.ToTable("item_cliente");

            entity.HasIndex(e => e.Idcliente, "fk_item_cliente_cliente1_idx");

            entity.HasIndex(e => e.IdprodutoMarca, "fk_item_cliente_produto_marca1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.Idcliente)
                .HasColumnType("int(11)")
                .HasColumnName("idcliente");

            entity.Property(e => e.IdprodutoMarca)
                .HasColumnType("int(11)")
                .HasColumnName("idproduto_marca");

            entity.HasOne(d => d.IdclienteNavigation)
                .WithMany(p => p.ItemClientes)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_cliente_cliente1");

            entity.HasOne(d => d.IdprodutoMarcaNavigation)
                .WithMany(p => p.ItemClientes)
                .HasForeignKey(d => d.IdprodutoMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_cliente_produto_marca1");
        }
    }
}
