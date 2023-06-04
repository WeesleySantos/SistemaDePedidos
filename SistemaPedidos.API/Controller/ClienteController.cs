using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.API.Data.ValueObjects;
using SistemaPedidos.API.Repositorios;

namespace SistemaPedidos.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepositorio _repository;

        public ClienteController(IClienteRepositorio repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<ClienteVO>>> ListaClientes()
        {
            var clientes = await _repository.ListaClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<ClienteVO>> ClientePorId(long id)
        {
            var cliente = await _repository.ClientePorId(id);
            if (cliente.Id <= 0) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
     
        public async Task<ActionResult<ClienteVO>> Criar([FromBody] ClienteVO vo)
        {
            if (vo == null) return BadRequest();
            var cliente = await _repository.CadastrarCliente(vo);
            return Ok(cliente);
        }

        [HttpPut]
      
        public async Task<ActionResult<ClienteVO>> Atualizar([FromBody] ClienteVO vo)
        {
            if (vo == null) return BadRequest();
            var cliente = await _repository.Atualizar(vo);
            return Ok(cliente);
        }
    }
}
