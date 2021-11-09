using FarmApp.Domain.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Infra.Data.Mapping
{
    public class ContaFarmaciaMapping : IEntityTypeConfiguration<ContaFarmaciaPoco>
    {
        public void Configure(EntityTypeBuilder<ContaFarmaciaPoco> entity)
        {
            entity.ToTable("conta_farmacia");

            entity.HasIndex(e => e.Idcep, "fk_conta_farmacia_cep1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Alvara)
                .HasMaxLength(20)
                .HasColumnName("alvara");

            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .HasColumnName("celular");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(20)
                .HasColumnName("cnpj");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");

            entity.Property(e => e.Idcep)
                .HasColumnType("int(11)")
                .HasColumnName("idcep");

            entity.Property(e => e.LatilongFarmacia)
                .HasMaxLength(16)
                .HasColumnName("latilong_farmacia");

            entity.Property(e => e.NomeFantasia)
                .HasMaxLength(100)
                .HasColumnName("nome_fantasia");

            entity.Property(e => e.NumeroEndereçofarmacia)
                .HasMaxLength(10)
                .HasColumnName("numero_endereçofarmacia");

            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(100)
                .HasColumnName("razao_social");

            entity.Property(e => e.Site)
                .HasMaxLength(200)
                .HasColumnName("site");

            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .HasColumnName("telefone");

            entity.HasOne(d => d.IdcepNavigation)
                .WithMany(p => p.ContaFarmacia)
                .HasForeignKey(d => d.Idcep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_conta_farmacia_cep1");
        }
    }
}
