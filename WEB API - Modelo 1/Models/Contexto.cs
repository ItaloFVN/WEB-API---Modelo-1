using Microsoft.EntityFrameworkCore;

namespace WEB_API___Modelo_1.Models
{
        public class Contexto : DbContext
        {
            public Contexto(DbContextOptions<Contexto> options)
                : base(options)
            {
            }

            public DbSet<Item> Items { get; set; }
        }
}
