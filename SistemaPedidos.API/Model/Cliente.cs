using SistemaPedidos.API.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaPedidos.API.Model
{
    [Table("cliente")]
    public class Cliente : BaseEntity
    {
        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
