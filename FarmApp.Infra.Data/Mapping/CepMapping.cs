using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class CepMapping : IEntityTypeConfiguration<CepPoco>
    {
        public void Configure(EntityTypeBuilder<CepPoco> entity)
        {
            entity.ToTable("cep");

            entity.HasIndex(e => e.Idendereco, "fk_cep_endereco1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Idendereco)
                .HasColumnType("int(11)")
                .HasColumnName("idendereco");

            entity.Property(e => e.NumeroCep)
                .HasMaxLength(12)
                .HasColumnName("numero_cep");

            entity.HasOne(d => d.IdenderecoNavigation)
                .WithMany(p => p.Ceps)
                .HasForeignKey(d => d.Idendereco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cep_endereco1");
        }
    }
}
