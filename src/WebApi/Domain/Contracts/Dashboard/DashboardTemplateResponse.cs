namespace Domain.Contracts.Dashboard;

public class DashboardTemplateResponse
{
    public Guid id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Layout { get; set; }
}