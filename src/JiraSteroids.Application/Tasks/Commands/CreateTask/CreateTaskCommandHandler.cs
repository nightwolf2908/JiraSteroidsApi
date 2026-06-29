using MediatR;
using JiraSteroids.Domain;

namespace JiraSteroids.Application.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskRepository _taskRepository;

    // Inyectamos ambos repositorios del Dominio
    public CreateTaskCommandHandler(IProjectRepository projectRepository, ITaskRepository taskRepository)
    {
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        // 1. Validar que el proyecto exista usando el repositorio de proyectos
        var project = await _projectRepository.GetByIdAsync(request.ProjectId);
        if (project == null)
        {
            throw new Exception("El proyecto especificado no existe.");
        }

        // 2. Crear la tarea con tu Enum
        var newTask = new TaskItem
        {
            Id = Guid.NewGuid(),
            ProjectId = request.ProjectId,
            Title = request.Title,
            Description = request.Description,
            Status = JiraSteroids.Domain.TaskStatus.ToDo
        };

        // 3. Guardar la tarea de forma directa y aislada a través de su propio repositorio
        await _taskRepository.AddAsync(newTask, cancellationToken);

        return newTask.Id;
    }
}