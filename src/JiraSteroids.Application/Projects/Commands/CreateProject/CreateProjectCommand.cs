using MediatR;

namespace JiraSteroids.Application.Projects.Commands.CreateProject;

// Un comando es un registro (record) de datos que implementa IRequest de MediatR
// Entre los piquitos <Guid> indicamos qué va a devolver este comando al terminar (el ID del proyecto creado)
public record CreateProjectCommand(string Name, string Description) : IRequest<Guid>;