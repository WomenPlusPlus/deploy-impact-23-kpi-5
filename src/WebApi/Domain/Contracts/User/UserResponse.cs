using Domain.Contracts.Circle;
using Domain.Entities.User;

namespace Domain.Contracts.User;

public class UserResponse
{
    public Guid id { get; set; }
    public string? Name { get; set; }
    public CircleResponse Circle { get; set; }
    public List<UserPermissionResponse> UserPermission { get; set; }

}