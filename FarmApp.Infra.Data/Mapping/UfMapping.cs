using FarmApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    internal class UfMapping : IEntityTypeConfiguration<Uf>
    {
        public void Configure(EntityTypeBuilder<Uf> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PRIMARY");

            builder.ToTable("uf");

            builder.Property(e => e.Id)
                .HasColumnType("int(11)")
                .ValueGeneratedNever()
                .HasColumnName("id");

            builder.Property(e => e.NomeUf)
                .HasMaxLength(25)
                .HasColumnName("nome_uf");
        }
    }
}
