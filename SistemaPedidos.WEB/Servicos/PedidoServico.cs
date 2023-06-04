using SistemaPedidos.WEB.Models;
using SistemaPedidos.WEB.Servicos.IServicos;
using SistemaPedidos.WEB.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;


namespace SistemaPedidos.WEB.Servicos
{
    public class PedidoServico : IPedidoServico
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/pedido";

        public PedidoServico(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<PedidoViewModel>> BuscarPedidos()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<PedidoViewModel>>();
        }

        public async Task<PedidoViewModel> BuscarPedidoPorId(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<PedidoViewModel>();
        }

        public async Task<PedidoViewModel> CadastrarPedido(PedidoViewModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<PedidoViewModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }      

        public async Task<PedidoViewModel> AtualizarPedido(PedidoViewModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<PedidoViewModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }

        public async Task<bool> DeletarPedido(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }
    }
}
