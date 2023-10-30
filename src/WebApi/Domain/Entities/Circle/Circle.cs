using Postgrest.Attributes;

namespace Domain.Entities.Circle;

[Table("Circle")]
public class Circle : BaseEntity
{
    [Column("Name")]
    public string? Name { get; set; }  
}