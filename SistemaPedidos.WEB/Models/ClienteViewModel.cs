namespace SistemaPedidos.WEB.Models
{
    public class ClienteViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public int? PedidoId { get; set; }
        public PedidoViewModel Pedido { get; set; }
    }
}
