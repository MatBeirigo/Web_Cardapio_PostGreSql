using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebCardapioSQL.Models
{
    [Table("Porcao")]
    public class Porcao
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Preco")]
        [Display(Name = "Preço")]
        public int Preco { get; set; }
    }
}
