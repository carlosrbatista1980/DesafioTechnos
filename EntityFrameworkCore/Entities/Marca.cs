using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Entities.Base;

namespace EntityFrameworkCore.Entities
{
    public class Marca : EntityBase<Marca, int>
    {
        public string Nome { get; set; }
        public byte[]? Logo { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
