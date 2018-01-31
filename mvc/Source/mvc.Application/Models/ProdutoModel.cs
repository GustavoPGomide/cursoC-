using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Application.Models
{
    public class ProdutoModel
    {
        public int CodigoProduto { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal Preco { get; set; }
    }
}
