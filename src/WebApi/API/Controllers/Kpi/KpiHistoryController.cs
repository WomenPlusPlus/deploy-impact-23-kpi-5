using Domain.Contracts.Kpi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers.Kpi;

[ApiController]
[Route("api/v1/[controller]")]
public class KpiHistoryController : ControllerBase
{
    private readonly Supabase.Client _client;

    public KpiHistoryController(Supabase.Client client)
    {
        _client = client;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(int skip = 0, int range = 25)
    {
        var response = await _client.From<Domain.Entities.Kpi.KpiHistory>()
            .Select("id, KpiId, Kpi!inner(Name), Value, CreatedAt, PeriodYear, PeriodMonth, ModifiedBy, User!inner(Name)")
            .Offset(skip) // skip a certain number of rows
            .Limit(range) //number of rows to fetch
            .Get();
        
        var dbResponse = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);

       
        var getResponse = new List<KpiHistoryResponse>();
        
        foreach (var item in dbResponse)
        {
            var tempData = new KpiHistoryResponse();
            tempData.id = Guid.Parse(item.id.ToString());
            tempData.KpiId = Guid.Parse(item.KpiId.ToString());
            tempData.KpiName = item.Kpi.Name;
            tempData.Value = item.Value;
            tempData.CreatedAt = item.CreatedAt;
            tempData.PeriodYear = item.PeriodYear;
            tempData.PeriodMonth = item.PeriodMonth;
            tempData.ModifiedBy = Guid.Parse(item.ModifiedBy.ToString());
            tempData.ModifiedByName = item.User.Name;
            
            getResponse.Add(tempData);
        }
        return Ok(getResponse);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _client.From<Domain.Entities.Kpi.KpiHistory>()
            .Select("id, KpiId, Kpi!inner(Name), Value, CreatedAt, PeriodYear, PeriodMonth, ModifiedBy, User!inner(Name)")
            .Where(n => n.id == id)
            .Get();
    
        var dbResponseArray = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);
        if (dbResponseArray == null || !dbResponseArray.Any())
        {
            return NotFound();
        }
        var dbResponse = dbResponseArray.First();
    
        var getResponse = new KpiHistoryResponse
        {
            id = Guid.Parse(dbResponse.id.ToString()),
            KpiId = Guid.Parse(dbResponse.KpiId.ToString()),
            KpiName = dbResponse.Kpi.Name,
            Value = dbResponse.Value,
            CreatedAt = dbResponse.CreatedAt,
            PeriodYear = dbResponse.PeriodYear,
            PeriodMonth = dbResponse.PeriodMonth,
            ModifiedBy = Guid.Parse(dbResponse.ModifiedBy.ToString()),
            ModifiedByName = dbResponse.User.Name
        };
        return Ok(getResponse);
    }
}