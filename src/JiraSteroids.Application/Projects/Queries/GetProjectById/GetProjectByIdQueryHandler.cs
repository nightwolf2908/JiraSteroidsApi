using MediatR;
using JiraSteroids.Domain;

namespace JiraSteroids.Application.Projects.Queries.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project?>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        // Buscamos el proyecto usando el repositorio
        return await _projectRepository.GetByIdAsync(request.Id);
    }
}