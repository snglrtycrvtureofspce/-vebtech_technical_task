namespace vebtech_technical_task.Models;

/// <summary>
/// User model
/// </summary>
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public virtual List<Role> Roles { get; set; }
}