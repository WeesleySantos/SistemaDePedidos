using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.WEB.Models;
using SistemaPedidos.WEB.Servicos.IServicos;
using System.Threading.Tasks;
using System;
using SistemaPedidos.WEB.Servicos;
using System.Reflection;

namespace SistemaPedidos.WEB.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoServico _pedidoServico;
        private readonly IClienteServico _clienteServico;
        private readonly IProdutoServico _ProdutoServico;

        private readonly PedidoViewModel _model;

        public PedidoController(IPedidoServico pedidoServico, IClienteServico clienteServico, IProdutoServico ProdutoServico)
        {
            _pedidoServico = pedidoServico ?? throw new ArgumentNullException(nameof(pedidoServico));
            _clienteServico = clienteServico ?? throw new ArgumentNullException(nameof(clienteServico));
            _ProdutoServico = ProdutoServico ?? throw new ArgumentNullException(nameof(ProdutoServico));
            _model = new PedidoViewModel(_clienteServico, _ProdutoServico);
        }
        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoServico.BuscarPedidos();
            return View(pedidos);
        }

        public async Task<IActionResult> CadastrarPedido()
        {
            _model.CarregaClientes();
            _model.CarregaProdutos();
            return View(_model);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPedido(PedidoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _pedidoServico.CadastrarPedido(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> DetalhePedido(int id)
        {
            var pedidos = await _pedidoServico.BuscarPedidoPorId(id);
            

            if (pedidos != null) return View(pedidos);
            return NotFound();
        }

        public async Task<IActionResult> DeletarPedido(long id)
        {
            var response = await _pedidoServico.DeletarPedido(id);
            if (response) return RedirectToAction(nameof(Index));
            return View();
        }
    }
}
