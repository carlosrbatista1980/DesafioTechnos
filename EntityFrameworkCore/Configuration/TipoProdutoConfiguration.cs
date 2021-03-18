using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Configuration
{
    internal class TipoProdutoConfiguration : IEntityTypeConfiguration<TipoProduto>
    {
        public void Configure(EntityTypeBuilder<TipoProduto> builder)
        {
            builder.ToTable(nameof(TipoProduto));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Secao).IsRequired(false).HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Setor).IsRequired(false).HasMaxLength(50).HasColumnType("varchar(50)");
        }
    }
}
