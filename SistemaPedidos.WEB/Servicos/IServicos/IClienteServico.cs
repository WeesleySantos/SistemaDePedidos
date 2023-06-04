using SistemaPedidos.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPedidos.WEB.Servicos.IServicos
{
    public interface IClienteServico
    {
        Task<IEnumerable<ClienteViewModel>> BuscarClientes();
        Task<ClienteViewModel> BuscarClientePorId(long id);
        Task<ClienteViewModel> CadastrarCliente(ClienteViewModel vo);
        Task<ClienteViewModel> AtualizarCliente(ClienteViewModel vo);
    }
}
