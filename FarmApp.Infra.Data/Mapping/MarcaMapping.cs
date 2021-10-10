using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class MarcaMapping : IEntityTypeConfiguration<MarcaPoco>
    {
        public void Configure(EntityTypeBuilder<MarcaPoco> entity)
        {
            entity.ToTable("marca");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.NomeMarca)
                .HasMaxLength(50)
                .HasColumnName("nome_marca");
        }
    }
}
