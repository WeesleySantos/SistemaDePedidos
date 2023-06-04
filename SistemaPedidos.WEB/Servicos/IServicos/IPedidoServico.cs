using SistemaPedidos.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPedidos.WEB.Servicos.IServicos
{
    public interface IPedidoServico
    {
        Task<IEnumerable<PedidoViewModel>> BuscarPedidos();
        Task<PedidoViewModel> BuscarPedidoPorId(long id);
        Task<PedidoViewModel> CadastrarPedido(PedidoViewModel vo);
        Task<PedidoViewModel> AtualizarPedido(PedidoViewModel vo);
        Task<bool> DeletarPedido(long id);
    }
}
