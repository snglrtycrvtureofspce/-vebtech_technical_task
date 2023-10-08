using MediatR;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Handlers.UserController.Get.Query;

/// <inheritdoc />
public class GetUserByIdQuery : IRequest<UserViewModelSummary>
{
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set; }
}