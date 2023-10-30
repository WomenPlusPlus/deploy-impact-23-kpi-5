using Postgrest.Attributes;

namespace Domain.Entities.Kpi;

[Table("KpiHistory")]
public class KpiHistory : BaseEntity
{
    [Column("KpiId")]
    public Guid KpiId { get; set; }
    
    [Column("Value")]
    public float? Value { get; set; }
    
    [Column("CreatedAt")]
    public DateTime? CreatedAt { get; set; }
    
    [Column("PeriodYear")]
    public int? PeriodYear { get; set; }
    
    [Column("PeriodMonth")]
    public int? PeriodMonth { get; set; }
    
    [Column("ModifiedBy")]
    public Guid? ModifiedBy { get; set; }
}