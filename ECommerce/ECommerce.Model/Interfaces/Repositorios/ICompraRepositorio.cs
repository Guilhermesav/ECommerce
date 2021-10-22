using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Model.Interfaces.Repositorios
{
    public interface ICompraRepositorio
    {
        Task Create(CompraModel compraFeita);

        Task<IEnumerable<CompraModel>> GetAll();

        Task<CompraModel> GetDetails(int id);

        Task<IEnumerable<CompraModel>> GetCompraByUser(string usuario);
    }
}
