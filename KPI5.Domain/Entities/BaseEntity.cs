using Microsoft.EntityFrameworkCore;
using Postgrest.Models;

namespace KPI5.Domain.Entities;

public class BaseEntity : BaseModel
{
    [Postgrest.Attributes.PrimaryKey("Id")]
    public int Id { get; set; }
}