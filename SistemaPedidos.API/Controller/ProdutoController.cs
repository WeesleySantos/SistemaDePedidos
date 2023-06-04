using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.API.Data.ValueObjects;
using SistemaPedidos.API.Model;
using SistemaPedidos.API.Repositorios;

namespace SistemaPedidos.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepositorio _repository;

        public ProdutoController(IProdutoRepositorio repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<ProdutoVO>>> ListaProdutos()
        {
            var produtos = await _repository.ListaProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoVO>> ProdutoPorId(long id)
        {
            var produto = await _repository.ProdutoPorId(id);
            if (produto.Id <= 0) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
      
        public async Task<ActionResult<ProdutoVO>> Criar([FromBody] ProdutoVO vo)
        {
            if (vo == null) return BadRequest();
            var produto = await _repository.Criar(vo);
            return Ok(produto);
        }

        [HttpPut]
        
        public async Task<ActionResult<ProdutoVO>> Atualizar([FromBody] ProdutoVO vo)
        {
            if (vo == null) return BadRequest();
            var produto = await _repository.Atualizar(vo);
            return Ok(produto);
        }
    }
}
