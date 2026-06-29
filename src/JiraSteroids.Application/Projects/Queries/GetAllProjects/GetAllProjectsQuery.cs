using MediatR;
using JiraSteroids.Domain;

namespace JiraSteroids.Application.Projects.Queries.GetAllProjects;

// Esta consulta implementa IRequest de MediatR
// Entre los piquitos indicamos que promete devolver una colección (IEnumerable) de Proyectos
public record GetAllProjectsQuery() : IRequest<IEnumerable<Project>>;