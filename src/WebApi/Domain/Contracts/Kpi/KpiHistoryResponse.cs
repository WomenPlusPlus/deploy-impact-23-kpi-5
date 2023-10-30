namespace Domain.Contracts.Kpi;

public class KpiHistoryResponse
{
    public Guid id { get; set; }
    public Guid KpiId { get; set; }
    public string? KpiName { get; set; }
    public float? Value { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? PeriodYear { get; set; }
    public int? PeriodMonth { get; set; }
    public Guid? ModifiedBy { get; set; }
    public string? ModifiedByName { get; set; }
}