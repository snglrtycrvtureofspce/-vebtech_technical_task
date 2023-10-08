using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using vebtech_technical_task.Data;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Handlers.UserController.Put;

/// <summary>
/// Handler for the UpdateUser method
/// </summary>
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserViewModelSummary>
{
    private readonly UsersDbContext _context;
    private readonly IValidator<UpdateUserCommand> _validator;

    /// <summary>
    /// Constructor with params for UpdateUserHandler
    /// </summary>
    /// <param name="context"></param>
    /// <param name="validator"></param>
    public UpdateUserHandler(UsersDbContext context, IValidator<UpdateUserCommand> validator)
    {
        _context = context;
        _validator = validator;
    }

    /// <inheritdoc />
    public async Task<UserViewModelSummary> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId,
            cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new Exception($"User with ID {request.UserId} not found");
        }
        
        user.Name = request.Name;
        user.Age = request.Age;
        user.Email = request.Email;
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return new UserViewModelSummary
        {
            Id = user.Id,
            Name = user.Name,
            Age = user.Age,
            Email = user.Email,
            Roles = new List<RoleViewModelSummary>()
        };
    }
}