using FluentValidation;
using vebtech_technical_task.Handlers.UserController.Post.Command;

namespace vebtech_technical_task.Handlers.UserController.Validator;

/// <summary>
/// Data validator for the role creation method
/// </summary>
public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    /// <inheritdoc />
    public CreateRoleCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required.");
    }
}