using MediatR;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Handlers.UserController.Post.Command;

/// <inheritdoc />
public class CreateRoleCommand: IRequest<RoleViewModelSummary>
{
    public string Name { get; set; }
}