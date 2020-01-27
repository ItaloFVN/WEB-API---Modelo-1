using Microsoft.EntityFrameworkCore;

namespace WEB_API___Modelo_1.Models
{
        public class TodoContext : DbContext
        {
            public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }

            public DbSet<TodoItem> TodoItems { get; set; }
        }
}
