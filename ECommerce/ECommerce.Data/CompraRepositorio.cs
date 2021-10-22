using ECommerce.Model;
using ECommerce.Model.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CompraRepositorio : ICompraRepositorio
    {
        private readonly DbSet<CompraModel> _dbSet;
        public CompraRepositorio(ECommerceContext context)
        {
            _dbSet = context.Set<CompraModel>();
        }
        public async Task Create(CompraModel compraFeita)
        {
            await _dbSet.AddAsync(compraFeita);
        }

        public async Task<IEnumerable<CompraModel>> GetAll()
        {
            var historicoTotal = _dbSet.ToListAsync();
            return await historicoTotal;
        }

        public async Task<IEnumerable<CompraModel>> GetCompraByUser(string usuario)
        {
            var historicoUser = await _dbSet.Where(x => x.Comprador == usuario).ToListAsync();
           return historicoUser;
        }

        public async Task<CompraModel> GetDetails(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
