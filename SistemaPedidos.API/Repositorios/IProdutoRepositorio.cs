using SistemaPedidos.API.Data.ValueObjects;

namespace SistemaPedidos.API.Repositorios
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<ProdutoVO>> ListaProdutos();
        Task<ProdutoVO> ProdutoPorId(long id);
        Task<ProdutoVO> Criar(ProdutoVO vo);
        Task<ProdutoVO> Atualizar(ProdutoVO vo);
    }
}
