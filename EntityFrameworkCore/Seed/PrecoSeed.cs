using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace EntityFrameworkCore.Seed
{
    public class PrecoSeed
    {
        public PrecoSeed()
        {
            var _context = new TechnosContextFactory().CreateDbContext(Array.Empty<string>());
            var precoList = new List<Preco>();

            if (!_context.Preco.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var preco = new Preco()
                    {
                        Nome = $"Nome da lista de Preco_{i:000}",
                        PrecoPadrao = Math.Round(new decimal(i)),
                        Imposto = 0.01m,
                        Desconto = 0.5m,
                    };

                    precoList.Add(preco);
                }
            }

            _context.Preco.AddRange(precoList);
            _context.SaveChanges();
        }
    }
}
