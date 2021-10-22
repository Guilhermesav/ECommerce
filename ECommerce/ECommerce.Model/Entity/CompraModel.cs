using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model
{
    public class CompraModel
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public string ProdutoNome { get; set; }

        public string ProdutoImagem { get; set; }
        public double Preço { get; set; }

        public string Comprador { get; set; }

        public string FormaDePagamento { get; set; }

    }
}
