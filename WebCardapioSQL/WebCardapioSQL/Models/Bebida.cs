using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCardapioSQL.Models
{
    [Table("Bebida")]
    public class Bebida
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Preco")]
        [Display(Name = "Preço")]
        public float Preco { get; set; }
    }
}
