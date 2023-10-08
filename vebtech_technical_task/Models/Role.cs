namespace vebtech_technical_task.Models;

/// <summary>
/// Role model
/// </summary>
public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual List<User> Users { get; set; }
}