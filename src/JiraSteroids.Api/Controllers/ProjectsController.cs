using Microsoft.AspNetCore.Mvc;
using MediatR;
using FluentValidation;
using JiraSteroids.Application.Projects.Commands.CreateProject;
using JiraSteroids.Application.Projects.Queries.GetAllProjects;

namespace JiraSteroids.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateProjectCommand> _validator;

    public ProjectsController(IMediator mediator, IValidator<CreateProjectCommand> validator)
    {
        _mediator = mediator;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
    {
        // 1. Validar la petición
        var validationResult = await _validator.ValidateAsync(command);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        // 2. Enviar a MediatR
        var projectId = await _mediator.Send(command);

        // 3. Responder con el ID creado
        return CreatedAtAction(nameof(Create), new { id = projectId }, new { id = projectId });
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // 1. Creamos el paquete de consulta vacío
        var query = new GetAllProjectsQuery();

        // 2. Se lo aventamos a MediatR para que busque al Handler correspondiente
        var projects = await _mediator.Send(query);

        // 3. Devolvemos un código 200 (OK) con la lista de proyectos que el Handler encontró
        return Ok(projects);
    }
}