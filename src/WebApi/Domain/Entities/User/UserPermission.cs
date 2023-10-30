using Postgrest.Attributes;

namespace Domain.Entities.User;

[Table("UserPermission")]
public class UserPermission : BaseEntity
{
    [Column("UserId")]
    public Guid? UserId { get; set; }
    
    [Column("UserRoleId")]
    public Guid? UserRoleId { get; set; }
    
    [Column("CreatedAt")]
    public DateTime? CreatedAt { get; set; }
    
}