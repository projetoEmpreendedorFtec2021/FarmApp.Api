using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class TipoEnderecoMapping : IEntityTypeConfiguration<TipoEnderecoPoco>
    {
        public void Configure(EntityTypeBuilder<TipoEnderecoPoco> entity)
        {
            entity.ToTable("tipo_endereco");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.NomeTipoEndereco)
                .HasMaxLength(45)
                .HasColumnName("nome_tipo_endereco");
        }
    }
}
