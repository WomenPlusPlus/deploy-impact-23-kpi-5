namespace KPI5.Domain.Contracts;
public class CreateKpiRequest
{
    public string? Circle { get; set; }

    public string? Kpi { get; set; }

    public string? Periodicity { get; set; }

    public string? Range { get; set; }

    public int? PeriodYear { get; set; }

    public int? PeriodMonth { get; set; }

    public float? Value { get; set; }
}