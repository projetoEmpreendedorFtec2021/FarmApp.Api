using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class ContaPessoalMapping : IEntityTypeConfiguration<ContaPessoalPoco>
    {
        public void Configure(EntityTypeBuilder<ContaPessoalPoco> entity)
        {
            entity.ToTable("conta_pessoal");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.TemFarmacia)
                .HasColumnType("tinyint(4)")
                .HasColumnName("tem_farmacia");
        }
    }
}
