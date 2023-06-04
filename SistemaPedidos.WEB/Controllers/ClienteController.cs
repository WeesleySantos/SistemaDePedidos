using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.WEB.Models;
using SistemaPedidos.WEB.Servicos.IServicos;
using System;
using System.Threading.Tasks;

namespace SistemaPedidos.WEB.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteservico)
        {
            _clienteServico = clienteservico ?? throw new ArgumentNullException(nameof(clienteservico));
        }
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteServico.BuscarClientes();
            return View(clientes);
        }

        public async Task<IActionResult> CadastrarCliente()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarCliente(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _clienteServico.CadastrarCliente(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> AtualizarCliente(int id)
        {
            var model = await _clienteServico.BuscarClientePorId(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarCliente(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _clienteServico.AtualizarCliente(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
