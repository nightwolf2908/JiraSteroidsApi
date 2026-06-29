using MediatR;
using JiraSteroids.Domain;

namespace JiraSteroids.Application.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;

    // 1. Inyección de dependencias: Pedimos el contrato del repositorio que creamos en el Dominio
    public CreateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    // 2. Este es el método que MediatR ejecutará automáticamente
    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        // 3. Creamos la entidad de Dominio usando los datos del comando
        var newProject = new Project
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        };

        // 4. Usamos el repositorio para guardarlo (la interfaz del Dominio)
        await _projectRepository.AddAsync(newProject);

        // 5. Devolvemos el ID del proyecto que se acaba de crear
        return newProject.Id;
    }
}