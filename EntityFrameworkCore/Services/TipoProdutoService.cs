using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Services.Base;

namespace EntityFrameworkCore.Services
{
    public class TipoProdutoService : ServiceBase
    {
        public List<TipoProduto> GetTipoProdutos()
        {
            return _context.TipoProduto.ToList();
        }
    }
}
