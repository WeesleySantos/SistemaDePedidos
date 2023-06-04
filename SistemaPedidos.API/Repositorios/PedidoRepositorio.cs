using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SistemaPedidos.API.Data.ValueObjects;
using SistemaPedidos.API.Model;
using SistemaPedidos.API.Model.Context;
using SistemaPedidos.WEB.Models;

namespace SistemaPedidos.API.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public PedidoRepositorio(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PedidoVO>> ListaPedidos()
        {
            try
            {
                var query = @"SELECT  p.id
                                     ,p.DATA
                                     ,p.STATUS
                                     ,p.idcliente
                                     ,p.idproduto
                                     ,c.id
                                     ,c.nome 
                                     ,c.ativo
                                     ,pd.id
                                     ,pd.nome
                                     ,pd.ativo
                              FROM pedidos p
                              LEFT JOIN cliente c ON c.id = p.idcliente
                              LEFT JOIN produto pd ON pd.id = p.idproduto
                              WHERE c.ativo = 1 AND pd.ativo = 1";

                var connection = _context.Database.GetDbConnection();
                var pedidos = await connection.QueryAsync<PedidoVO, ClienteViewModel, ProdutoViewModel, PedidoVO>(query,
                    (pedido, cliente, produto) =>
                    {
                        pedido.Cliente = cliente;
                        pedido.Produto = produto;
                        return pedido;
                    },
                    splitOn: "id,idcliente,id");

                return pedidos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<PedidoVO>();
            }
        }

        public async Task<PedidoVO> PedidoPorId(long id)
        {
            try
            {
                var query = $@"SELECT  
                                       p.id
                                     ,p.DATA
                                     ,p.STATUS
                                     ,p.idcliente
                                     ,p.idproduto
                                     ,c.id
                                     ,c.nome 
                                     ,c.ativo
                                     ,pd.id
                                     ,pd.nome
                                     ,pd.preco
                                     ,pd.ativo
                              FROM pedidos p
                              LEFT JOIN cliente c ON c.id = p.idcliente
                              LEFT JOIN produto pd ON pd.id = p.idproduto
                             WHERE p.id = {id}";

                var connection = _context.Database.GetDbConnection();
                var pedidos = await connection.QueryAsync<PedidoVO, ClienteViewModel, ProdutoViewModel, PedidoVO>(query,
                    (pedido, cliente, produto) =>
                    {
                        pedido.Cliente = cliente;
                        pedido.Produto = produto;
                        return pedido;
                    }, splitOn: "id,idcliente,id");

                return pedidos.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new PedidoVO();
            }
        }

        public async Task<PedidoVO> CadastrarPedido(PedidoVO vo)
        {

            Pedido pedido = _mapper.Map<Pedido>(vo);
            pedido.IdCliente = vo.Cliente.Id;
            pedido.IdProduto = vo.Produto.Id;
            vo.DataPedido = DateTime.Now;
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return _mapper.Map<PedidoVO>(pedido);
        }

        public async Task<PedidoVO> Atualizar(PedidoVO vo)
        {
            Pedido pedido = _mapper.Map<Pedido>(vo);
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
            return _mapper.Map<PedidoVO>(pedido);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Pedido pedido = await _context.Pedidos.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Pedido();
                if (pedido.Id <= 0) return false;
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
