using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Configuration
{
    internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Descricao).IsRequired(false).HasMaxLength(250).HasColumnType("varchar(250)");
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Preco).IsRequired();
            builder.Property(x => x.DataLancamento).IsRequired(false);

            builder.HasOne(x => x.TipoProduto).WithMany(x => x.Produtos).HasForeignKey(x => x.TipoProdutoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Marca).WithMany(x => x.Produtos).HasForeignKey(x => x.MarcaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
