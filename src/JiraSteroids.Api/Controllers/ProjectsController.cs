using Microsoft.AspNetCore.Mvc;
using MediatR;
using FluentValidation;
// Asegúrate de que estos namespaces coincidan exactamente con tus carpetas de Queries y Commands
using JiraSteroids.Application.Projects.Commands.CreateProject;
using JiraSteroids.Application.Projects.Queries.GetAllProjects;
using JiraSteroids.Application.Projects.Queries.GetProjectById;

namespace JiraSteroids.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    // Inyectamos MediatR para despachar comandos y consultas de forma limpia
    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // 1. POST: Crear un nuevo proyecto
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
    {
        // Nota: Si usas FluentValidation con un Middleware de excepciones global, 
        // puedes quitar este bloque IF y dejar que el middleware maneje los errores 400.
        if (command == null)
        {
            return BadRequest("Los datos del proyecto no pueden ser nulos.");
        }

        var projectId = await _mediator.Send(command);
        
        return CreatedAtAction(nameof(GetById), new { id = projectId }, new { id = projectId });
    }

    // 2. GET: Obtener la lista general de proyectos (Básico)
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _mediator.Send(new GetAllProjectsQuery());
        return Ok(projects);
    }

    // 3. GET: Obtener el detalle de un proyecto específico con todas sus tareas colgadas
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var project = await _mediator.Send(new GetProjectByIdQuery(id));

        if (project == null)
        {
            return NotFound(new { message = $"El proyecto con ID {id} no fue encontrado en la base de datos." });
        }

        // Retorna el proyecto completo incluyendo su lista interna de TaskItems gracias al Eager Loading
        return Ok(project);
    }
}

internal class GetProjectsQuery : IRequest<object>
{
}