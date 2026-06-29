namespace JiraSteroids.Domain;

public interface IProjectRepository
{
    // 1. Obtener un proyecto por su ID
    Task<Project?> GetByIdAsync(Guid id);

    // 2. Obtener todos los proyectos activos
    Task<IEnumerable<Project>> GetAllAsync();

    // 3. Guardar un nuevo proyecto
    Task AddAsync(Project project);

    // 4. Actualizar un proyecto existente
    Task UpdateAsync(Project project);
}