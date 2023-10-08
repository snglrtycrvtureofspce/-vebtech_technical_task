using MediatR;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Handlers.UserController.Put;

/// <inheritdoc />
public class UpdateUserCommand : IRequest<UserViewModelSummary>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}