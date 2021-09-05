using FarmApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Infra.Data.Mapping
{
    public class ContaPessoalMapping : IEntityTypeConfiguration<ContaPessoal>
    {
        public void Configure(EntityTypeBuilder<ContaPessoal> entity)
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
