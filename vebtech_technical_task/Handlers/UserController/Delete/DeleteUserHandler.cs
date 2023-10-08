using MediatR;
using Microsoft.EntityFrameworkCore;
using vebtech_technical_task.Data;

namespace vebtech_technical_task.Handlers.UserController.Delete;

/// <summary>
/// Handler for the DeleteUser method
/// </summary>
public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly UsersDbContext _context;

    /// <summary>
    /// Constructor with params for DeleteUserHandler
    /// </summary>
    /// <param name="context"></param>
    public DeleteUserHandler(UsersDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId,
            cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new Exception($"User with ID {request.UserId} not found");
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}