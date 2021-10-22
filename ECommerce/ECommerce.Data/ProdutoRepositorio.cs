using ECommerce.Model;
using ECommerce.Model.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DbSet<ProdutoModel> _dbSet;

        public ProdutoRepositorio(ECommerceContext context)
        {
            _dbSet = context.Set<ProdutoModel>();
        }
        public async Task Create(ProdutoModel produtoCriado)
        {
            await _dbSet.AddAsync(produtoCriado);
                
        }

        public async Task Delete(int id)
        {
            var produto = await _dbSet.FindAsync(id);
            _dbSet.Remove(produto);
        }

        public async Task<IEnumerable<ProdutoModel>> GetAll()
        {
            var catalogo = _dbSet.ToListAsync();
            return await catalogo;
        }

        public async Task<ProdutoModel> GetDetails(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public  async Task Update(ProdutoModel produtoAtualizado)
        {

             _dbSet.Update(produtoAtualizado);
            
        }
    }
}
