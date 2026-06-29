using Microsoft.EntityFrameworkCore;
using JiraSteroids.Domain;

namespace JiraSteroids.Infrastructure;

// Heredamos de DbContext para obtener todas las funciones de bases de datos
public class ApplicationDbContext : DbContext
{
    // El constructor recibe la configuración (como la cadena de conexión) y se la pasa a la clase padre
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Aquí le decimos a EF Core qué clases se convertirán en tablas de la base de datos
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
}