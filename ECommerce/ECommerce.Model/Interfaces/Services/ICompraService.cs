using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Model.Interfaces.Services
{
    public interface ICompraService
    {
        Task Create(CompraModel compraFeita);

        Task <IEnumerable<CompraModel>> GetAll();

        Task<CompraModel> GetDetails(int id);

        Task<IEnumerable<CompraModel>> GetCompraByUser(string usuario);
    }
}
