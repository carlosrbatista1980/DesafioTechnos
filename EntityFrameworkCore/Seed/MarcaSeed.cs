using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace EntityFrameworkCore.Seed
{
    public class MarcaSeed
    {
        public MarcaSeed()
        {
            var _context = new TechnosContextFactory().CreateDbContext(Array.Empty<string>());

            if(!_context.Marca.Any())
            {
                List<Marca> marcaList = new List<Marca>();

                for (int i = 0; i < 5; i++)
                {
                    var marca = new Marca()
                    {
                        Nome = $"Nome da Marca_{i:000}",
                        Logo = new byte[i],
                    };

                    marcaList.Add(marca);
                }

                _context.Marca.AddRange(marcaList);
                _context.SaveChanges();
            }
        }
    }
}
