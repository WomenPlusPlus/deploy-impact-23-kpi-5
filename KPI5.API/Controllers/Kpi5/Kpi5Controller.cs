using KPI5.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KPI5.API.Controllers.Kpi5;    

[ApiController]
[Route("[controller]")]
public class Kpi5Controller : ControllerBase
{
    private readonly Supabase.Client _client;

    public Kpi5Controller(Supabase.Client client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int skip = 0, int range = 25)
    {
        var response = await _client.From<Domain.Entities.KPI5.Kpi5>()
            .Offset(skip) // skip a certain number of rows
            .Limit(range) //number of rows to fetch
            .Get();

        var kpis = response.Models;
       
        var kpiResponse = new List<KpiResponse>();
        
        foreach (var item in kpis)
        {
            var tempKpi = new KpiResponse();
            tempKpi.Id = item.Id;
            tempKpi.Circle = item.Circle;
            tempKpi.Circle = item.Kpi;
            tempKpi.Range = item.Range;
            tempKpi.PeriodYear = item.PeriodYear;
            tempKpi.PeriodMonth = item.PeriodMonth;
            tempKpi.Value = item.Value;

            kpiResponse.Add(tempKpi);
        }
        
        return Ok(kpiResponse);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _client.From<Domain.Entities.KPI5.Kpi5>()
            .Where(n => n.Id == id)
            .Get();

        var kpi = response.Models.FirstOrDefault();
        if (kpi is null)
        {
            return NotFound();
        }

        var kpiResponse = new KpiResponse
        {
            Id = kpi.Id,
            Circle = kpi.Circle,
            Kpi = kpi.Circle,
            Range = kpi.Range,
            PeriodYear = kpi.PeriodYear,
            PeriodMonth = kpi.PeriodMonth,
            Value = kpi.Value
        };
        return Ok(kpiResponse);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateKpiRequest create)
    {
        var kpi = new Domain.Entities.KPI5.Kpi5
        {
            Circle = create.Circle,
            Kpi = create.Kpi,
            Periodicity = create.Periodicity,
            Range = create.Range,
            PeriodYear = create.PeriodYear,
            PeriodMonth = create.PeriodMonth,
            Value = create.Value
        };
        var response = await _client.From<Domain.Entities.KPI5.Kpi5>().Insert(kpi);
        var newKpi = response.Models.First();

        return Ok(newKpi.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] KpiResponse model)
    {
        var response = await _client.From<Domain.Entities.KPI5.Kpi5>()
            .Where(n => n.Id == id)
            .Single();
        
        if (response is null)
        {
            return NotFound();
        }

        response.Circle = model.Circle;
        response.Kpi = model.Kpi;
        response.Periodicity = model.Periodicity;
        response.Range = model.Range;
        response.PeriodYear = model.PeriodYear;
        response.PeriodMonth = model.PeriodMonth;
        response.Value = model.Value;

        await _client.From<Domain.Entities.KPI5.Kpi5>().Update(response);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = _client.From<Domain.Entities.KPI5.Kpi5>()
            .Where(x => x.Id == id)
            .Delete();
        
        return Ok(response.Id);
    }
}