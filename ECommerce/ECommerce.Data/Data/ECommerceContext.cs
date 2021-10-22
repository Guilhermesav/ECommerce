using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext (DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        public DbSet<CompraModel> CompraModel { get; set; }
        public DbSet<ProdutoModel> ProdutoModel { get; set; }
    }
}
