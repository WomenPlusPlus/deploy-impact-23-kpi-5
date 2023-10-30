using Domain.Entities.User;
using Newtonsoft.Json;

namespace Domain.Contracts.User;

public class UserPermissionRoleResponse
{
    public Guid id { get; set; }
    public Guid UserId { get; set; }
    public Guid UserRoleId { get; set; }
    public string RoleName { get; set; }
    public DateTime CreatedAt { get; set; }
    
}