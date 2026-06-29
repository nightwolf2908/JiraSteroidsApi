using FluentValidation;

namespace JiraSteroids.Application.Projects.Commands.CreateProject;

// Heredamos de AbstractValidator e indicamos entre los piquitos qué queremos validar
public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        // Regla para el Nombre
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("El nombre del proyecto no puede estar vacío.")
            .MaximumLength(100).WithMessage("El nombre del proyecto no puede tener más de 100 caracteres.");

        // Regla para la Descripción
        RuleFor(command => command.Description)
            .MaximumLength(500).WithMessage("La descripción no puede tener más de 500 caracteres.");
    }
}