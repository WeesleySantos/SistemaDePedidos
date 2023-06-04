using SistemaPedidos.WEB.Servicos;
using SistemaPedidos.WEB.Servicos.IServicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPedidos.WEB.Models
{
    public class PedidoViewModel
    {
        private readonly IClienteServico _clienteServico;
        private readonly IProdutoServico _produtoServico;

        public PedidoViewModel()
        {
            
        }

        public PedidoViewModel(IClienteServico clienteServico, IProdutoServico produtoServico)
        {
            _clienteServico = clienteServico ?? throw new ArgumentNullException(nameof(clienteServico));
            _produtoServico = produtoServico ?? throw new ArgumentNullException(nameof(produtoServico));
        }
        public ClienteViewModel Cliente { get; set; } = new ClienteViewModel();
        public ProdutoViewModel Produto { get; set; } = new ProdutoViewModel();
        public Task<IEnumerable<ClienteViewModel>> Clientes { get; set; }
        public Task<IEnumerable<ProdutoViewModel>> Produtos { get; set; } 

        public long Id { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Novo pedido";

        internal void CarregaClientes()
        {
            Clientes = _clienteServico.BuscarClientes();
        }
        internal void CarregaProdutos()
        {
            Produtos = _produtoServico.BuscarProdutos();
        }

    }
}
