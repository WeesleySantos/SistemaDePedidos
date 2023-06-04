using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.API.Data.ValueObjects;
using SistemaPedidos.API.Model;
using SistemaPedidos.API.Model.Context;

namespace SistemaPedidos.API.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProdutoRepositorio(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoVO>> ListaProdutos()
        {
            List<Produto> produtos = await _context.Produtos.Where(x => x.Ativo).ToListAsync();
            return _mapper.Map<List<ProdutoVO>>(produtos);
        }

        public async Task<ProdutoVO> ProdutoPorId(long id)
        {
            Produto produto = await _context.Produtos.Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? new Produto();
            return _mapper.Map<ProdutoVO>(produto);
        }

        public async Task<ProdutoVO> Criar(ProdutoVO vo)
        {
            Produto produto = _mapper.Map<Produto>(vo);
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoVO>(produto);
        }

        public async Task<ProdutoVO> Atualizar(ProdutoVO vo)
        {
            Produto produto = _mapper.Map<Produto>(vo);
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoVO>(produto);
        }
    }
}
