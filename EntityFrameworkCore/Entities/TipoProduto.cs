using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Entities.Base;

namespace EntityFrameworkCore.Entities
{
    public class TipoProduto : EntityBase<TipoProduto, int>
    {
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string Setor { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
