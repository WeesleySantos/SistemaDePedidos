using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.WEB.Models;
using SistemaPedidos.WEB.Servicos;
using SistemaPedidos.WEB.Servicos.IServicos;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace SistemaPedidos.WEB.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _productServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _productServico = produtoServico ?? throw new ArgumentNullException(nameof(produtoServico));
        }
        public async Task<IActionResult> Index()
        {
            var produtos = await _productServico.BuscarProdutos();
            return View(produtos);
        }
        public async Task<IActionResult> CriarProduto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productServico.CriarProduto(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> AtualizarProduto(int id)
        {
            var model = await _productServico.BuscarProdutoPorId(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarProduto(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productServico.AtualizarProduto(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
