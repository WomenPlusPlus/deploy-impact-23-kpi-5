namespace Domain.Contracts.Dashboard;

public class DashboardResponse
{
    public Guid id { get; set; }
    public DateTime? CreationDate { get; set; }
    public Guid? TemplateId { get; set; }
    public string? TemplateName { get; set; }
    public Guid? CircleId { get; set; }
    public string? CircleName { get; set; }
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    

}