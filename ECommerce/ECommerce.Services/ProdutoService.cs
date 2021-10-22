using ECommerce.Model;
using ECommerce.Model.Interfaces;
using ECommerce.Model.Interfaces.Blob;
using ECommerce.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IBlobService _blobService;

        public ProdutoService(IProdutoRepositorio produtoRepositorio,IBlobService blobService)
        {
            _produtoRepositorio = produtoRepositorio;
            _blobService = blobService;
        }

        public async Task Create(ProdutoModel produtoCriado)
        {
            if (produtoCriado.UriBlob != null)
            {
                var blob = await _blobService.CreateBlobAsync(produtoCriado.UriBlob);

                produtoCriado.UriBlob = blob;
            }
            await _produtoRepositorio.Create(produtoCriado);
           
        }

        public async Task Delete(int id,string uri)
        {
           
            if (uri != null)
            {
                await _blobService.DeleteBlobAsync(uri);
            }
            await _produtoRepositorio.Delete(id);
        }

        public async Task<IEnumerable<ProdutoModel>> GetAll()
        {
            var catalogo = _produtoRepositorio.GetAll();
            return await catalogo;
        }

        public async  Task<ProdutoModel> GetDetails(int id)
        {
            return await _produtoRepositorio.GetDetails(id);
        }

        public async Task Update(ProdutoModel produtoAtualizado)
        {
            
            
            if (produtoAtualizado.UriBlob != null)
            {
                var blob = await _blobService.CreateBlobAsync(produtoAtualizado.UriBlob);

                produtoAtualizado.UriBlob = blob;
            }
            await _produtoRepositorio.Update(produtoAtualizado);
        }
    }
}
