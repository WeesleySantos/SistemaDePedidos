using SistemaPedidos.API.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPedidos.API.Model
{
    public class ProdutosCliente : BaseEntity
    {
        [Column("idproduto")]
        public long IdProduto { get; set; }

        [Column("idcliente")]
        public long IdCliete { get; set; }
    }
}
