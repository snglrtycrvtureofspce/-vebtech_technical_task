using FluentValidation;
using MediatR;
using vebtech_technical_task.Data;
using vebtech_technical_task.Handlers.UserController.Post.Command;
using vebtech_technical_task.Models;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Handlers.UserController.Post.Handler;

/// <summary>
/// Handler for the CreateRole method
/// </summary>
public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, RoleViewModelSummary>
{
    private readonly UsersDbContext _context;
    private readonly IValidator<CreateRoleCommand> _validator;

    /// <summary>
    /// Constructor with params for CreateRoleHandler
    /// </summary>
    /// <param name="context"></param>
    /// <param name="validator"></param>
    public CreateRoleHandler(UsersDbContext context, IValidator<CreateRoleCommand> validator)
    {
        _context = context;
        _validator = validator;
    }
    
    /// <inheritdoc />
    public async Task<RoleViewModelSummary> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var newRole = new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Users = new List<User>()
        };

        _context.Roles.Add(newRole);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new RoleViewModelSummary
        {
            Id = newRole.Id,
            Name = newRole.Name,
            Users = new List<UserViewModelSummary>()
        };
    }
}