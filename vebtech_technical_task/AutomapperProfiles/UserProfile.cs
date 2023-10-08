using AutoMapper;
using vebtech_technical_task.Models;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.AutomapperProfiles;

/// <summary>
/// Mapping profile for user
/// </summary>
public class UserProfile : Profile
{
    /// <inheritdoc />
    public UserProfile()
    {
        CreateMap<User, UserViewModelSummary>();
    }
}