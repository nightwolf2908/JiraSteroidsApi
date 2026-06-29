using MediatR;
using JiraSteroids.Domain;

namespace JiraSteroids.Application.Projects.Queries.GetProjectById;

// Esta consulta promete regresar el objeto Project completo (o null si no existe)
public record GetProjectByIdQuery(Guid Id) : IRequest<Project?>;