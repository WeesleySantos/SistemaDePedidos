using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.API.Data.ValueObjects;
using SistemaPedidos.API.Model;
using SistemaPedidos.API.Model.Context;

namespace SistemaPedidos.API.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ClienteRepositorio(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteVO>> ListaClientes()
        {
            List<Cliente> clientes = await _context.Clientes.Where(x => x.Ativo).ToListAsync();
            return _mapper.Map<List<ClienteVO>>(clientes);
        }

        public async Task<ClienteVO> ClientePorId(long id)
        {
            Cliente cliente = await _context.Clientes.Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? new Cliente();
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> CadastrarCliente(ClienteVO vo)
        {
            Cliente cliente = _mapper.Map<Cliente>(vo);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> Atualizar(ClienteVO vo)
        {
            Cliente cliente = _mapper.Map<Cliente>(vo);
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }
    }
}
