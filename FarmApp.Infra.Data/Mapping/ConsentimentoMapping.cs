using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ConsentimentoMapping : IEntityTypeConfiguration<ConsentimentoPoco>
    {
        public void Configure(EntityTypeBuilder<ConsentimentoPoco> entity)
        {
            entity.ToTable("consentimento");

            entity.HasIndex(e => e.Idcliente, "fk_cliente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");

            entity.Property(e => e.Finalidade)
                .HasMaxLength(1000)
                .HasColumnName("finalidade");

            entity.Property(e => e.Idcliente)
                .HasColumnType("int(11)")
                .HasColumnName("idcliente");

            entity.Property(e => e.Situacao)
                .HasMaxLength(20)
                .HasColumnName("situacao");

            entity.HasOne(d => d.IdclienteNavigation)
                .WithMany(p => p.Consentimentos)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cliente1");
        }
    }
}
