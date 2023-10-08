namespace vebtech_technical_task.ViewModels;

/// <summary>
/// ViewModel for the user
/// </summary>
public class UserViewModelSummary
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public virtual List<RoleViewModelSummary> Roles { get; set; }
}