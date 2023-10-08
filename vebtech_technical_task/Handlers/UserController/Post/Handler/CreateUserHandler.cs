using FluentValidation;
using MediatR;
using vebtech_technical_task.Data;
using vebtech_technical_task.Handlers.UserController.Post.Command;
using vebtech_technical_task.Models;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Handlers.UserController.Post.Handler;

/// <summary>
/// Handler for the CreateUser method
/// </summary>
public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserViewModelSummary>
{
    private readonly UsersDbContext _context;
    private readonly IValidator<CreateUserCommand> _validator;

    /// <summary>
    /// Constructor with params for CreateUserHandler
    /// </summary>
    /// <param name="context"></param>
    /// <param name="validator"></param>
    public CreateUserHandler(UsersDbContext context, IValidator<CreateUserCommand> validator)
    {
        _context = context;
        _validator = validator;
    }

    /// <inheritdoc />
    public async Task<UserViewModelSummary> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Age = request.Age,
            Email = request.Email,
            Roles = new List<Role>()
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new UserViewModelSummary
        {
            Id = newUser.Id,
            Name = newUser.Name,
            Age = newUser.Age,
            Email = newUser.Email,
            Roles = new List<RoleViewModelSummary>()
        };
    }
}