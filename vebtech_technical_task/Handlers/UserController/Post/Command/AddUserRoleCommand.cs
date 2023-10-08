using MediatR;

namespace vebtech_technical_task.Handlers.UserController.Post.Command;

/// <inheritdoc />
public class AddUserRoleCommand : IRequest<Unit>
{
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// UserId
    /// </summary>
    public Guid RoleId { get; set; }
}