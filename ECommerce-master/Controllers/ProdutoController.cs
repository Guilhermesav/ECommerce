using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Model;
using Microsoft.AspNetCore.Authorization;
using ECommerce.Model.Interfaces;

using ECommerce.Model.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoServices;
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoController(IProdutoService produtoService, IUnitOfWork unitOfWork)
        {
            _produtoServices = produtoService;
            _unitOfWork = unitOfWork;
        } 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var catalogo = _produtoServices.GetAll();
           
            return  View(await catalogo);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nome,Categoria,UriBlob,Preco,Vendedor")] ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                produto.Vendedor = User.Identity.Name;  
                await _produtoServices.Create(produto);
               
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
            
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoServices.GetDetails(id);
            if(produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Nome,Categoria,UriBlob,Preco,Vendedor")] ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoServices.Update(produto);
               
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _produtoServices.GetDetails(id);
            var uri = produto.UriBlob;
            await _produtoServices.Delete(id,uri);
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoServices.GetDetails(id);

            return View(produto);
        }
    }
}
