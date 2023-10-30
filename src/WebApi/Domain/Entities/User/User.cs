using Postgrest.Attributes;

namespace Domain.Entities.User;

[Table("User")]
public class User : BaseEntity
{
    [Column("Name")]
    public string? Name { get; set; }
    
    [Column("CircleId")]
    public Guid CircleId { get; set; }
    
    public Circle.Circle Circle { get; set; }
    
    public List<UserPermission> UserPermission { get; set; }
}