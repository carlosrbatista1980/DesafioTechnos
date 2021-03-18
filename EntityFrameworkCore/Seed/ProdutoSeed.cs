using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Entities;

namespace EntityFrameworkCore.Seed
{
    public class ProdutoSeed
    {
        public ProdutoSeed()
        {
            var _context = new TechnosContextFactory().CreateDbContext(Array.Empty<string>());
            var produtoList = new List<Produto>();

            for (int i = 0; i < 10; i++)
            {
                var produto = new Produto()
                {
                    Nome = $"Produto Nome_{i:000}",
                    Codigo = $"Codigo_{i:00}",
                    Descricao = $"Descricao do produto - {i:000}",
                    DataCadastro = DateTime.Now,
                    DataLancamento = DateTime.Now.AddMonths(-16),
                    TipoProduto = _context.TipoProduto.FirstOrDefault(x => x.Id == i),
                    Preco = _context.Preco.FirstOrDefault(x => x.Id == i),
                    Marca = _context.Marca.FirstOrDefault(x => x.Id == i),
                };

                produtoList.Add(produto);
            }

            _context.Produto.AddRange(produtoList);
            _context.SaveChanges();
        }
    }
}
