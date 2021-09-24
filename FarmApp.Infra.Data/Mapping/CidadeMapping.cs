using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    internal class CidadeMapping : IEntityTypeConfiguration<CidadePoco>
    {
        public void Configure(EntityTypeBuilder<CidadePoco> entity)
        {
            entity.ToTable("cidade");

            entity.HasIndex(e => e.Iduf, "fk_cidade_uf1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Iduf)
                .HasColumnType("int(11)")
                .HasColumnName("iduf");

            entity.Property(e => e.NomeCidade)
                .HasMaxLength(100)
                .HasColumnName("nome_cidade");
        }
    }
}
