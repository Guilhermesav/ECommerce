using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Model;
using ECommerce.Model.Interfaces.Services;
using ECommerce.Model.Interfaces.UnitOfWork;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;
        private readonly IUnitOfWork _unitOfWork;
        public CompraController(ICompraService compraService,IUnitOfWork unitOfWork )
        {
            _compraService = compraService;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Compra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraModel>>> GetCompras()
        {
            var historicoTotal = await _compraService.GetAll();
            return historicoTotal.ToList(); ;
        }

        // GET: api/Compra/5
        [HttpGet("/ById/{id}")]
        public async Task<ActionResult<CompraModel>> GetCompraModel(int id)
        {
            var compraModel = await _compraService.GetDetails(id);

            if (compraModel == null)
            {
                return NotFound();
            }

            return compraModel;
        }

        [HttpGet("{usuario}")]
        public async Task<ActionResult<IEnumerable<CompraModel>>> GetUserCompras(string usuario)
        {

            var historico = await _compraService.GetCompraByUser(usuario);
            return historico.ToList();
        }

        // POST: api/Compra
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CompraModel>> PostCompraModel(CompraModel compraModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.BeginTransaction();
                await _compraService.Create(compraModel);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

            return base.Ok();
        }
    }   
}
