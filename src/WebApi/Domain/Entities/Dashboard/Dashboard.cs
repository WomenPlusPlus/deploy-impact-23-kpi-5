using Postgrest.Attributes;

namespace Domain.Entities.Dashboard;

[Table("Dashboard")]
public class Dashboard : BaseEntity
{
    [Column("CircleId")]
    public Guid? CircleId { get; set; }
    
    [Column("Title")]
    public string? Title { get; set; }
    
    [Column("CreationDate")]
    public DateTime? CreationDate { get; set; }
    
    [Column("VisualisationType")]
    public string? VisualisationType { get; set; }
    
    [Column("KpiId")]
    public Guid? KpiId { get; set; }
    
    [Column("Field")]
    public string? Field { get; set; }
    
    [Column("TemplateId")]
    public Guid? TemplateId { get; set; }
}