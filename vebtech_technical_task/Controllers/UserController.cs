using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vebtech_technical_task.Handlers.UserController.Delete;
using vebtech_technical_task.Handlers.UserController.Get.Query;
using vebtech_technical_task.Handlers.UserController.Post.Command;
using vebtech_technical_task.Handlers.UserController.Put;
using vebtech_technical_task.Infrastructure;
using vebtech_technical_task.ViewModels;

namespace vebtech_technical_task.Controllers;

/// <summary>
/// Controller for interaction with the user and roles
/// </summary>
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <inheritdoc />
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// The method provider possibility to get all users
    /// </summary>
    [HttpGet("GetUsers")]
    [ProducesResponseType(typeof(IEnumerable<UserViewModelSummary>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<IEnumerable<UserViewModelSummary>> GetUsers([FromQuery] GetAllUsersQuery query)
    {
        return await _mediator.Send(query);
    }

    /// <summary>
    /// The method provider possibility to get a user by id 
    /// </summary>
    [HttpGet("GetUserById/{userId:guid}", Name = "GetUserById")]
    [ProducesResponseType(typeof(ItemResponse<UserViewModelSummary>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<ItemResponse<UserViewModelSummary>> GetUserById(Guid userId)
    {
        var query = await _mediator.Send(new GetUserByIdQuery { UserId = userId });
        
        return new ItemResponse<UserViewModelSummary>
        {
            Message = "The response was received successfully.",
            StatusCode = 200,
            Item = new UserViewModelSummary
            {
                Id = query.Id,
                Name = query.Name,
                Age = query.Age,
                Email = query.Email,
                Roles = query.Roles
            }
        };
    }

    /// <summary>
    /// The method provider possibility to add a role to user
    /// </summary>
    [HttpPost("AddUserRole/{userId:guid}/roles/{roleId:guid}", Name = "AddUserRole")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<ActionResult<string>> AddUserRole(Guid userId, Guid roleId)
    {
        await _mediator.Send(new AddUserRoleCommand { UserId = userId, RoleId = roleId });
        return Ok($"Role added successfully.\nUserId: {userId}\nRoleId: {roleId}");
    }
    
    /// <summary>
    /// The method provider possibility to create a user
    /// </summary>
    [HttpPost("CreateUser", Name = "CreateUser")]
    [ProducesResponseType(typeof(ItemResponse<UserViewModelSummary>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<ItemResponse<UserViewModelSummary>> CreateUser(CreateUserCommand createUserCommand)
    {
        var query = await _mediator.Send(createUserCommand);
        
        return new ItemResponse<UserViewModelSummary>
        {
            Message = "User created successfully.",
            StatusCode = 200,
            Item = new UserViewModelSummary
            {
                Id = query.Id,
                Name = query.Name,
                Age = query.Age,
                Email = query.Email,
                Roles = query.Roles
            }
        };
    }
    
    /// <summary>
    /// The method provider possibility to create a role
    /// </summary>
    [HttpPost("CreateRole", Name = "CreateRole")]
    [ProducesResponseType(typeof(ItemResponse<RoleViewModelSummary>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<ItemResponse<RoleViewModelSummary>> CreateRole(CreateRoleCommand createRoleCommand)
    {
        var query = await _mediator.Send(createRoleCommand);
        
        return new ItemResponse<RoleViewModelSummary>
        {
            Message = "Role created successfully.",
            StatusCode = 200,
            Item = new RoleViewModelSummary
            {
                Id = query.Id,
                Name = query.Name,
                Users = query.Users
            }
        };
    }

    /// <summary>
    /// The method provider possibility to update a user
    /// </summary>
    [HttpPut("UpdateUser/{userId:guid}", Name = "UpdateUser")]
    [ProducesResponseType(typeof(ItemResponse<UserViewModelSummary>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<ItemResponse<UserViewModelSummary>> UpdateUser(Guid userId, UpdateUserCommand updateUserCommand)
    {
        updateUserCommand.UserId = userId;
        var query = await _mediator.Send(updateUserCommand);
        
        return new ItemResponse<UserViewModelSummary>
        {
            Message = "User updated successfully.",
            StatusCode = 200,
            Item = new UserViewModelSummary
            {
                Id = query.Id,
                Name = query.Name,
                Age = query.Age,
                Email = query.Email,
                Roles = query.Roles
            }
        };
    }

    /// <summary>
    /// The method provider possibility to delete a user
    /// </summary>
    [HttpDelete("DeleteUser/{userId:guid}", Name = "DeleteUser")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<ActionResult<string>> DeleteUser(Guid userId)
    {
        await _mediator.Send(new DeleteUserCommand { UserId = userId });
        return Ok("User deleted successfully.");
    }
}