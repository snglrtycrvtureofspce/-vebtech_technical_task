using MediatR;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Handlers.UserController.Get.Query;

/// <inheritdoc />
public class GetAllUsersQuery : IRequest<IEnumerable<UserViewModelSummary>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; }
    public string Filter { get; set; }
}