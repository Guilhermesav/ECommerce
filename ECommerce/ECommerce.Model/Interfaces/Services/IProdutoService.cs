using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Model.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoModel>> GetAll();

        Task Create(ProdutoModel produtoCriado);

        Task Update(ProdutoModel produtoAtualizado);

        Task Delete(int id,string uri);

        Task<ProdutoModel> GetDetails(int id);
    }
}
