using SistemaPedidos.API.Data.ValueObjects;

namespace SistemaPedidos.API.Repositorios
{
    public interface IPedidoRepositorio
    {
        Task<IEnumerable<PedidoVO>> ListaPedidos();
        Task<PedidoVO> PedidoPorId(long id);
        Task<PedidoVO> CadastrarPedido(PedidoVO vo);
        Task<PedidoVO> Atualizar(PedidoVO vo);
        Task<bool> Delete(long id);
    }
}
