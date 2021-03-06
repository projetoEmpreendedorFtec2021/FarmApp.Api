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
                .HasColumnName("id");

            entity.Property(e => e.NomeMarca)
                .HasMaxLength(100)
                .HasColumnName("nome_marca");
        }
    }
}
