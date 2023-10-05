using Postgrest.Attributes;

namespace KPI5.Domain.Entities.KPI5;

[System.ComponentModel.DataAnnotations.Schema.Table("Kpi5")]
public class Kpi5 : BaseEntity
{
    [Column("Circle")]
    public string? Circle { get; set; }
    [Column("Kpi")]
    public string? Kpi { get; set; }
    [Column("Periodicity")]
    public string? Periodicity { get; set; }
    [Column("Range")]
    public string? Range { get; set; }
    [Column("PeriodYear")]
    public int? PeriodYear { get; set; }
    [Column("PeriodMonth")]
    public int? PeriodMonth { get; set; }
    [Column("Value")]
    public float? Value { get; set; }
}