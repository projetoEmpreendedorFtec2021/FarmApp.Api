using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ContaMapping : IEntityTypeConfiguration<ContaPoco>
    {
        public void Configure(EntityTypeBuilder<ContaPoco> entity)
        {
            entity.ToTable("conta");

            entity.HasIndex(e => e.IdcontaFarmacia, "fk_conta_conta_farmacia1_idx");

            entity.HasIndex(e => e.IdcontaPessoal, "fk_conta_conta_pessoal_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.DataCriacao)
                .HasMaxLength(45)
                .HasColumnName("data_criacao");

            entity.Property(e => e.DataEncerramento)
                .HasMaxLength(45)
                .HasColumnName("data_encerramento");

            entity.Property(e => e.IdcontaFarmacia)
                .HasColumnType("int(11)")
                .HasColumnName("idconta_farmacia");

            entity.Property(e => e.IdcontaPessoal)
                .HasColumnType("int(11)")
                .HasColumnName("idconta_pessoal");

            entity.HasOne(d => d.IdcontaFarmaciaNavigation)
                .WithMany(p => p.Conta)
                .HasForeignKey(d => d.IdcontaFarmacia)
                .HasConstraintName("fk_conta_conta_farmacia1");

            entity.HasOne(d => d.IdcontaPessoalNavigation)
                .WithMany(p => p.Conta)
                .HasForeignKey(d => d.IdcontaPessoal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_conta_conta_pessoal");
        }
    }
}
