using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProduto.model
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }

        public int quantidade { get; set; }

        public double valor { get; set; }

        public string fornecedor { get; set; }

        public double preco_venda { get; set; }
    }
}
