using AutoMapper;
using vebtech_technical_task.Models;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.AutomapperProfiles;

/// <summary>
/// Mapping profile for role
/// </summary>
public class RoleProfile : Profile
{
    /// <inheritdoc />
    public RoleProfile()
    {
        CreateMap<Role, RoleViewModelSummary>();
    }
}