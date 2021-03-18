using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace EntityFrameworkCore.Seed
{
    public class TipoProdutoSeed
    {
        public TipoProdutoSeed()
        {
            var _context = new TechnosContextFactory().CreateDbContext(Array.Empty<string>());
            var tipoList = new List<TipoProduto>();

            if (!_context.TipoProduto.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var tipoProduto = new TipoProduto()
                    {
                        Nome = $"TipoProduto_{i:000}",
                        Secao = $"Secao_{i:000}",
                        Setor = $"Setor_{i:000}",
                    };

                    tipoList.Add(tipoProduto);
                }
            }

            _context.TipoProduto.AddRange(tipoList);
            _context.SaveChanges();
        }
    }
}
