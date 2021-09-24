using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    internal class UfMapping : IEntityTypeConfiguration<UfPoco>
    {
        public void Configure(EntityTypeBuilder<UfPoco> entity)
        {
            entity.ToTable("uf");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.NomeUf)
                .HasMaxLength(25)
                .HasColumnName("nome_uf");
        }
    }
}
