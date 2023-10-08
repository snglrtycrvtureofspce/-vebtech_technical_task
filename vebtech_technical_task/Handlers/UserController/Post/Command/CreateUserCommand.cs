using MediatR;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Handlers.UserController.Post.Command;

/// <inheritdoc />
public class CreateUserCommand : IRequest<UserViewModelSummary>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}