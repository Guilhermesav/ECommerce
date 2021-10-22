using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model.Options
{
    public class HttpOptions
    {
        public Uri ApiBaseUrl { get; set; }
        public string ProdutoPath { get; set; }
        public string CompraPath { get; set; }
        public string Name { get; set; }
        public int Timeout { get; set; }
    }
}
