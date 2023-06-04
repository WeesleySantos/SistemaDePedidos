using SistemaPedidos.WEB.Models;
using System.Text.Json.Serialization;

namespace SistemaPedidos.API.Data.ValueObjects
{
    public class PedidoVO
    {
        public long Id { get; set; }
        [JsonIgnore]
        public DateTime DataPedido { get; set; }
        [JsonIgnore]
        public string Status { get; set; }
        [JsonIgnore]
        public decimal ValorTotal { get; set; }
        public ClienteViewModel Cliente { get; set; }
        [JsonIgnore]
        public Task<IEnumerable<ClienteViewModel>> Clientes { get; set; }
        public ProdutoViewModel Produto { get; set; }
        [JsonIgnore]
        public Task<IEnumerable<ProdutoViewModel>> Produtos { get; set; }
    }
}
