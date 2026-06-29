using MediatR;

namespace JiraSteroids.Application.Tasks.Commands.CreateTask;

// Este comando promete regresar el Guid (ID) de la tarea recién creada
public record CreateTaskCommand(
    Guid ProjectId,
    string Title,
    string Description
) : IRequest<Guid>;