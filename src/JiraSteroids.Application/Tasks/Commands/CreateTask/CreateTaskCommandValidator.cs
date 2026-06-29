using FluentValidation;

namespace JiraSteroids.Application.Tasks.Commands.CreateTask;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("La tarea debe estar asociada a un proyecto válido.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("El título de la tarea no puede estar vacío.")
            .MaximumLength(150).WithMessage("El título no puede tener más de 150 caracteres.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("La descripción no puede tener más de 500 caracteres.");
    }
}