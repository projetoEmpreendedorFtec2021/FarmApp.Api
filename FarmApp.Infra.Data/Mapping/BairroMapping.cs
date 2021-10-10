using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class BairroMapping : IEntityTypeConfiguration<BairroPoco>
    {
        public void Configure(EntityTypeBuilder<BairroPoco> entity)
        {
            entity.ToTable("bairro");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.NomeBairro)
                .HasMaxLength(45)
                .HasColumnName("nome_bairro");
        }
    }
}
