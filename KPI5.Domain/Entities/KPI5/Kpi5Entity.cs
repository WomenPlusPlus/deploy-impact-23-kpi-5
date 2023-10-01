namespace KPI5.Domain.Entities.KPI5;

public class Kpi5Entity : BaseEntity
{
    public string? Circle { get; set; }
    public string? Kpi { get; set; }
    public string? Periodicity { get; set; }
    public string? Range { get; set; }
    public int? PeriodYear { get; set; }
    public int? PeriodMonth { get; set; }
    public float? Value { get; set; }
}