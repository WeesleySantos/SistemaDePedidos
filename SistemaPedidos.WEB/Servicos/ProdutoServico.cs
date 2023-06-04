using SistemaPedidos.WEB.Models;
using SistemaPedidos.WEB.Servicos.IServicos;
using SistemaPedidos.WEB.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace SistemaPedidos.WEB.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/produto";

        public ProdutoServico(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProdutoViewModel>> BuscarProdutos()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProdutoViewModel>>();
        }

        public async Task<ProdutoViewModel> BuscarProdutoPorId(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProdutoViewModel>();
        }

        public async Task<ProdutoViewModel> CriarProduto(ProdutoViewModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProdutoViewModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }

        public async Task<ProdutoViewModel> AtualizarProduto(ProdutoViewModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProdutoViewModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }
    }
}
