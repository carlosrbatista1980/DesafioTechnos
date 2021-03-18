using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Helpers;
using EntityFrameworkCore.Services.Base;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EntityFrameworkCore.Services
{
    public class ProdutoService : ServiceBase
    {
        public int CadastrarProduto(Produto produto)
        {
            if (produto is null)
            {
                return -1;
            }
            
            _context.Produto.Add(produto);
            return _context.SaveChanges(true);
        }

        public List<Produto> GetProdutos()
        {
            return _context.Produto
                .Include(x => x.TipoProduto)
                .Include(x => x.Marca)
                .OrderBy(x => x.Nome)
                .ToList();
        }
    }
}
