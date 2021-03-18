using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Entities.Base;

namespace EntityFrameworkCore.Entities
{
    public class Preco : EntityBase<Preco, int>
    {
        public string Nome { get; set; }
        public decimal? PrecoPadrao { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Imposto { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
