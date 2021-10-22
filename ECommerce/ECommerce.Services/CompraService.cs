using ECommerce.Model;
using ECommerce.Model.Interfaces.Repositorios;
using ECommerce.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepositorio _compraRepositorio;
        public CompraService(ICompraRepositorio compraRepositorio)
        {
            _compraRepositorio = compraRepositorio;
        }
        public async Task Create(CompraModel compraFeita)
        {
            await _compraRepositorio.Create(compraFeita);
        }

        public async Task<IEnumerable<CompraModel>> GetAll()
        {
            var historico = _compraRepositorio.GetAll();
            return await historico;
        }

        public async Task<IEnumerable<CompraModel>> GetCompraByUser(string usuario)
        {
            var historicoUser = await _compraRepositorio.GetCompraByUser(usuario);
            return historicoUser;
        }

        public async Task<CompraModel> GetDetails(int id)
        {
            return await _compraRepositorio.GetDetails(id);
        }
    }
}
