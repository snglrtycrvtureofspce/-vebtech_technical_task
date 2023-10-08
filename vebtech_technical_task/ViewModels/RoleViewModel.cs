namespace vebtech_technical_task.ViewModels;

/// <summary>
/// ViewModel for the role
/// </summary>
public class RoleViewModelSummary
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual List<UserViewModelSummary> Users { get; set; }
}