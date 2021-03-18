using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Configuration
{
    internal class PrecoConfiguration : IEntityTypeConfiguration<Preco>
    {
        public void Configure(EntityTypeBuilder<Preco> builder)
        {
            builder.ToTable(nameof(Preco));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Desconto).IsRequired(false);
            builder.Property(x => x.Imposto).IsRequired(false);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.PrecoPadrao).IsRequired();
        }
    }
}
