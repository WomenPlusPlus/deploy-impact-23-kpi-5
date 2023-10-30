using Domain.Entities.User;

namespace Domain.Contracts.User;

public class UserPermissionResponse
{
    public Guid id { get; set; }
    public Guid UserId { get; set; }
    public Guid UserRoleId { get; set; }
    public DateTime CreatedAt { get; set; }
}