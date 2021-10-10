using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmApp.Infra.Data.Mapping
{
    public class EnderecoContaPessoalMapping : IEntityTypeConfiguration<EnderecoContapessoalPoco>
    {
        public void Configure(EntityTypeBuilder<EnderecoContapessoalPoco> entity)
        {
            entity.ToTable("endereco_contapessoal");

            entity.HasIndex(e => e.IdcontaPessoal, "fk_conta_conta_pessoal_idx");

            entity.HasIndex(e => e.Idcep, "fk_endereco_contapessoal_cep1_idx");

            entity.HasIndex(e => e.IdtipoEndereco, "fk_endereco_contapessoal_tipo_endereco1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Complemento)
                .HasMaxLength(10)
                .HasColumnName("complemento");

            entity.Property(e => e.Idcep)
                .HasColumnType("int(11)")
                .HasColumnName("idcep");

            entity.Property(e => e.IdcontaPessoal)
                .HasColumnType("int(11)")
                .HasColumnName("idconta_pessoal");

            entity.Property(e => e.IdtipoEndereco)
                .HasColumnType("int(11)")
                .HasColumnName("idtipo_endereco");

            entity.Property(e => e.LatLong)
                .HasMaxLength(16)
                .HasColumnName("lat_long");

            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");

            entity.HasOne(d => d.IdcepNavigation)
                .WithMany(p => p.EnderecoContapessoals)
                .HasForeignKey(d => d.Idcep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_endereco_contapessoal_cep1");

            entity.HasOne(d => d.IdcontaPessoalNavigation)
                .WithMany(p => p.EnderecoContapessoals)
                .HasForeignKey(d => d.IdcontaPessoal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_endereco_contapessoal_conta_pessoal");

            entity.HasOne(d => d.IdtipoEnderecoNavigation)
                .WithMany(p => p.EnderecoContapessoals)
                .HasForeignKey(d => d.IdtipoEndereco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_endereco_contapessoal_tipo_endereco1");
        }
    }
}
