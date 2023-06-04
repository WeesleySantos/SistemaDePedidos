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
    public class ClienteServico : IClienteServico
    {

        private readonly HttpClient _client;
        public const string BasePath = "api/cliente";

        public ClienteServico(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ClienteViewModel>> BuscarClientes()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ClienteViewModel>>();
        }

        public async Task<ClienteViewModel> BuscarClientePorId(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ClienteViewModel>();
        }

        public async Task<ClienteViewModel> CadastrarCliente(ClienteViewModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ClienteViewModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }

        public async Task<ClienteViewModel> AtualizarCliente(ClienteViewModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ClienteViewModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }
    }
}
