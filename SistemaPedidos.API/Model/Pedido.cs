using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SistemaPedidos.API.Model.Base;

namespace SistemaPedidos.API.Model
{
    public class Pedido : BaseEntity
    {
        [Column("data")]
        public DateTime DataPedido { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("idcliente")]
        public long IdCliente { get; set; }
        [Column("idproduto")]
        public long IdProduto { get; set; }
    }
}
