using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Model.Interfaces.Repositorios
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<ProdutoModel>> GetAll();

        Task Create(ProdutoModel produtoCriado);

        Task Update(ProdutoModel produtoAtualizado);

        Task Delete(int id);

        Task<ProdutoModel> GetDetails(int id);
    }
}
