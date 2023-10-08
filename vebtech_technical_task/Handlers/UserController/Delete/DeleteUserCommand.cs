using MediatR;

namespace vebtech_technical_task.Handlers.UserController.Delete;

/// <inheritdoc />
public class DeleteUserCommand : IRequest<bool>
{
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set; }
}