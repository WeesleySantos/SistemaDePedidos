using SistemaPedidos.API.Data.ValueObjects;

namespace SistemaPedidos.API.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<ClienteVO>> ListaClientes();
        Task<ClienteVO> ClientePorId(long id);
        Task<ClienteVO> CadastrarCliente(ClienteVO vo);
        Task<ClienteVO> Atualizar(ClienteVO vo);
    }
}
