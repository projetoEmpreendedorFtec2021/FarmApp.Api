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

            entity.HasIndex(e => e.IdCliente, "fk_item_cliente_cliente1_idx");

            entity.HasIndex(e => e.IdProdutoMarca, "fk_item_cliente_produto_marca1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.IdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("idcliente");

            entity.Property(e => e.IdProdutoMarca)
                .HasColumnType("int(11)")
                .HasColumnName("idproduto_marca");

            entity.HasOne(d => d.Cliente)
                .WithMany(p => p.ItemClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_cliente_cliente1");

            entity.HasOne(d => d.ProdutoMarca)
                .WithMany(p => p.ItemClientes)
                .HasForeignKey(d => d.IdProdutoMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_item_cliente_produto_marca1");
        }
    }
}
