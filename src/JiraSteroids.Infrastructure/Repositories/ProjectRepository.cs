using Microsoft.EntityFrameworkCore;
using JiraSteroids.Domain;

namespace JiraSteroids.Infrastructure.Repositories;

// Usamos los dos puntos (:) para decirle a C# que esta clase va a CUMPLIR el contrato de IProjectRepository
public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    // Inyectamos nuestro contexto de base de datos a través del constructor (como el __init__ de Python)
    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // 1. Buscar un proyecto por su ID
    public async Task<Project?> GetByIdAsync(Guid id)
    {
        // En Python con una lista harías algo como: next((p for p in proyectos if p.id == id), None)
        // En EF Core usamos SingleOrDefaultAsync para buscar una fila por su ID de forma asíncrona
        return await _context.Projects
            .Include(p => p.Tasks) // ¡Truco senior! Trae el proyecto junto con todas sus tareas de un solo golpe
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    // 2. Obtener todos los proyectos que estén activos
    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        // Filtramos usando una expresión lambda (como un filter de Python)
        return await _context.Projects
            .Where(p => p.IsActive)
            .ToListAsync();
    }

    // 3. Agregar un nuevo proyecto a la base de datos
    public async Task AddAsync(Project project)
    {
        // Esto no lo guarda de inmediato en el disco duro, solo lo "prepara" en la memoria de EF Core
        await _context.Projects.AddAsync(project);
        
        // Esta línea es la que realmente hace el "COMMIT" en la base de datos y guarda los cambios
        await _context.SaveChangesAsync();
    }

    // 4. Actualizar un proyecto que ya existe
    public async Task UpdateAsync(Project project)
    {
        // Le avisamos a EF Core que este objeto sufrio cambios
        _context.Projects.Update(project);
        
        // Guardamos los cambios en el disco duro
        await _context.SaveChangesAsync();
    }
}