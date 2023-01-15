using Microsoft.EntityFrameworkCore;

namespace WebCardapioSQL.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Lanche> Lanche { get; set; }
        public DbSet<Porcao> Porcao { get; set; }
    }
}
