using KPI5.Domain.Entities;
using KPI5.Domain.Entities.KPI5;
using KPI5.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KPI5.API.Controllers.Kpi5;

[ApiController]
[Route("/v1/Kpi5/Kpis")]
public class Kpi5Controller : ControllerBase
{
    private readonly DataContext _context;
    public Kpi5Controller(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetKpisAsync()
    {
        try
        {
            var kpis = await _context.Kpi5s.AsNoTracking().ToListAsync();
            return Ok(new ResultViewEntity<List<Kpi5Entity>>(kpis));
        }
        catch
        {
            return StatusCode(500, new ResultViewEntity<List<Kpi5Entity>>("Internal server failure (kpi01)"));
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostKpiAsync([FromBody] Kpi5Entity kpi)
    {
        try
        {
            await _context.Kpi5s.AddAsync(kpi);
            await _context.SaveChangesAsync();

            return Created($"/v1/Kpi5/Kpis/{kpi.Kpi}", new ResultViewEntity<Kpi5Entity>(kpi));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewEntity<Kpi5Entity>("The input failed (kpi02)"));
        }
        catch
        {
            return StatusCode(500, new ResultViewEntity<List<Kpi5Entity>>("Internal server failure (kpi01)"));
        }
    }
}