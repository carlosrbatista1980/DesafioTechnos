using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.Entities;

namespace DesafioTechnos.Models
{
    public class ProdutoModel
    {
        /// <summary>
        /// nome do produto
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// codigo do produto
        /// </summary>
        [Required]
        public string Codigo { get; set; }

        /// <summary>
        /// descrição do produto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// data do cadastro do produto
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// data de lançamento
        /// </summary>
        public DateTime? DataLancamento { get; set; }
        
        /// <summary>
        /// Preco do produto
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Id da tabela de TipoProduto caso exista
        /// </summary>
        public int? TipoProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }

        /// <summary>
        /// Id da tabela de Marca caso exista
        /// </summary>
        public int? MarcaId { get; set; }
        public Marca Marca { get; set; }

        public ProdutoModel()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
