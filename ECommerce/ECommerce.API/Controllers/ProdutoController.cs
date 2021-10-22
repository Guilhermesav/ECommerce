using ECommerce.Model;
using ECommerce.Model.Interfaces;
using ECommerce.Model.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoServices;
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoController(IProdutoService produtoService,  IUnitOfWork unitOfWork)
        {
            _produtoServices = produtoService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> PostProduto([Bind("Id,Nome,Categoria,UriBlob,Preco,Vendedor")] ProdutoModel produtoModel)
        {
        
           if (!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }
       
           try
            {
               _unitOfWork.BeginTransaction();
                await _produtoServices.Create(produtoModel);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
           {

               return BadRequest(e);
          }
       
           return base.Ok();
        }
        
       [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetCatalogo()
        {
            
            var catalogo = await _produtoServices.GetAll();
            return catalogo.ToList();
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProduto(int id)
        {
            var produto = await _produtoServices.GetDetails(id);
            
            if (produto == null)
            {
                return NotFound();
            }
            
            

            return produto;
        }
        [HttpPut]
        public async Task<ActionResult<ProdutoModel>> PutProdutoModel([Bind("Id,Nome,Categoria,UriBlob,Preco,Vendedor")] ProdutoModel produtoModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.BeginTransaction();
                await _produtoServices.Update(produtoModel);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

            return base.Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> DeleteProduto(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var produto = await _produtoServices.GetDetails(id);

            if (produto == null)
            {
                return NotFound();
            }
            var uri = produto.UriBlob;
            _unitOfWork.BeginTransaction();
            await _produtoServices.Delete(id,uri);
            await _unitOfWork.CommitAsync();

            return produto;
        }
    }
}
