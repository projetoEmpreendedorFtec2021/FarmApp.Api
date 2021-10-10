using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<EnderecoPoco>
    {
        public void Configure(EntityTypeBuilder<EnderecoPoco> entity)
        {
            entity.ToTable("endereco");

            entity.HasIndex(e => e.Idbairro, "fk_endereco_bairro1_idx");

            entity.HasIndex(e => e.Idcidade, "fk_endereco_cidade1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Idbairro)
                .HasColumnType("int(11)")
                .HasColumnName("idbairro");

            entity.Property(e => e.Idcidade)
                .HasColumnType("int(11)")
                .HasColumnName("idcidade");

            entity.Property(e => e.NomeEndereco)
                .HasMaxLength(45)
                .HasColumnName("nome_endereco");

            entity.HasOne(d => d.IdbairroNavigation)
                .WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.Idbairro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_endereco_bairro1");

            entity.HasOne(d => d.IdcidadeNavigation)
                .WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.Idcidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_endereco_cidade1");
        }
    }
}
