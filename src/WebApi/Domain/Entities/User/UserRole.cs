using Postgrest.Attributes;

namespace Domain.Entities.User;


public class UserRole : BaseEntity
{

    public string? RoleName { get; set; } 
}