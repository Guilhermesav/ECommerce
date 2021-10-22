using System;

namespace ECommerce.Model
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public string UriBlob { get; set; }
        
        public double Preco { get; set; }
        public string Vendedor { get; set; }
    }
}
