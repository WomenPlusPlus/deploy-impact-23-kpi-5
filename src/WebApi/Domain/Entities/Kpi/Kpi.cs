using Postgrest.Attributes;

namespace Domain.Entities.Kpi;

[Table("Kpi")]
public class Kpi : BaseEntity
{
    [Column("CircleId")]
    public Guid CircleId { get; set; }
    
    [Column("Name")]
    public string? Name { get; set; }
    
    [Column("Value")]
    public float? Value { get; set; }
    
    [Column("ValueType")]
    public string? ValueType { get; set; }
    
    [Column("Range")]
    public string? Range { get; set; }
    
    [Column("Periodicity")]
    public string? Periodicity { get; set; }
}