using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.API.Data.ValueObjects;
using SistemaPedidos.API.Model;
using SistemaPedidos.API.Repositorios;
using SistemaPedidos.WEB.Models;
using System.Data;

namespace SistemaPedidos.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoRepositorio _repository;

        public PedidoController(IPedidoRepositorio repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<PedidoVO>>> ListaPedidos()
        {
            var pedidos = await _repository.ListaPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoVO>> PedidoPorId(long id)
        {
            var pedido = await _repository.PedidoPorId(id);
            if (pedido.Id <= 0) return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
       
        public async Task<ActionResult<PedidoVO>> Criar([FromBody] PedidoVO vo)
        {
            if (vo == null) return BadRequest();
             await _repository.CadastrarPedido(vo);
            return Ok(vo);
        }

        [HttpPut]
       
        public async Task<ActionResult<PedidoVO>> Atualizar([FromBody] PedidoVO vo)
        {
            if (vo == null) return BadRequest();
            var cliente = await _repository.Atualizar(vo);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
