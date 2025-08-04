using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    // Contexto de dados para Entity Framework Core
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet representa a tabela de tarefas no banco de dados
        public DbSet<Task> Tasks { get; set; }
    }
}
