namespace Domain.Contracts.Kpi;

public class KpiResponse
{
    public Guid id { get; set; }
    public string? Name { get; set; }
    public string? ValueType { get; set; }
    public string? Range { get; set; }
    public string? Periodicity { get; set; }
    public Guid CircleId { get; set; }
    public string? CircleName { get; set; }
}