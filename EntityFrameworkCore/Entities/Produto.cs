using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Entities.Base;

namespace EntityFrameworkCore.Entities
{
    public class Produto : EntityBase<Produto, int>
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataLancamento { get; set; }
        public decimal Preco { get; set; }

        public int? TipoProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int? MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
