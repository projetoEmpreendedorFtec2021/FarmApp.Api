using FarmApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    internal class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.ToTable("cliente");

            entity.HasIndex(e => e.Idconta, "fk_cliente_conta1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .HasColumnName("celular");

            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .HasColumnName("cpf");

            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("data_nascimento");

            entity.Property(e => e.Idconta)
                .HasColumnType("int(11)")
                .HasColumnName("idconta");

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");

            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");

            entity.Property(e => e.Senha)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("senha");

            entity.Property(e => e.ValidaEmail)
                .HasColumnType("tinyint(4)")
                .HasColumnName("valida_email");

            entity.HasOne(d => d.IdcontaNavigation)
                .WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idconta)
                .HasConstraintName("fk_cliente_conta1");
        }
    }
}
