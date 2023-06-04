using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SistemaPedidos.API.Model.Base;

namespace SistemaPedidos.API.Model
{
    [Table("produto")]
    public class Produto : BaseEntity
    {
        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Column("preco")]
        [Required]
        [Range(1, 10000)]
        public decimal Preco { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
