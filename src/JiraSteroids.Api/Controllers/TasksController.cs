using Microsoft.AspNetCore.Mvc;
using MediatR;
using FluentValidation;
using JiraSteroids.Application.Tasks.Commands.CreateTask;

namespace JiraSteroids.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateTaskCommand> _validator;

    // Inyectamos MediatR y el validador que acabamos de programar
    public TasksController(IMediator mediator, IValidator<CreateTaskCommand> validator)
    {
        _mediator = mediator;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        // 1. Validar los datos de la tarea (Título, Descripción, ProjectId)
        var validationResult = await _validator.ValidateAsync(command);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        // 2. Despachar el comando al Handler a través de MediatR
        var taskId = await _mediator.Send(command);

        // 3. Responder con un 201 Created y el ID de la tarea generada
        return CreatedAtAction(nameof(Create), new { id = taskId }, new { id = taskId });
    }
}