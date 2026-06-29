using MediatR;
using JiraSteroids.Domain;

namespace JiraSteroids.Application.Projects.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
{
    private readonly IProjectRepository _projectRepository;

    // Inyectamos el contrato del repositorio (el menú)
    public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        // Le pedimos a la infraestructura que vaya a la base de datos por la lista
        return await _projectRepository.GetAllAsync();
    }
}