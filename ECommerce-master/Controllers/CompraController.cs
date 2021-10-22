using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Model;
using ECommerce.Model.Interfaces;
using ECommerce.Model.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Controllers
{
    [Authorize]
    public class CompraController : Controller
    {
        
        private readonly IProdutoService _produtoService;
        private readonly ICompraService _compraService;

      
        public CompraController(IProdutoService produtoService,ICompraService compraService)
        {
            _produtoService = produtoService;
            _compraService = compraService;
        }

        // GET: Compra
        public async Task<IActionResult> Index()
        {
            
            var historicoTotal = await _compraService.GetAll();
            return View(historicoTotal);
        }

        // GET: Compra/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var compra = await _compraService.GetDetails(id);
            return View(compra);
        }

        // GET: Compra/Create

        [HttpGet]
        public async Task<IActionResult> Create(int produtoId)
        {
            
            var produto = await _produtoService.GetDetails(produtoId);
            var compraModel = new CompraModel
            {
                ProdutoNome = produto.Nome,
                ProdutoId = produto.Id,
                Preço = produto.Preco,
                ProdutoImagem = produto.UriBlob,
                
            };

            return View(compraModel);
        }

        // POST: Compra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,ProdutoNome,ProdutoImagem,Preço,Comprador,FormaDePagamento")] CompraModel compraModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = User.Identity.Name;
                compraModel.Comprador = usuario;
                await _compraService.Create(compraModel); 
                return RedirectToAction("Index", "Produto");
            }
            return View(compraModel);
        }
        
        public async Task<IActionResult> UserCompras(string usuario)
        {
            
            var historico = await _compraService.GetCompraByUser(usuario);
            return View(historico);
        }
    }
}
