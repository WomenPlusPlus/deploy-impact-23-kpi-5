using Domain.Contracts.Kpi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers.Kpi;

[ApiController]
[Route("api/v1/[controller]")]
public class KpiController : ControllerBase
{
    private readonly Supabase.Client _client;

    public KpiController(Supabase.Client client)
    {
        _client = client;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(int skip = 0, int range = 25)
    {
        var response = await _client.From<Domain.Entities.Kpi.Kpi>()
            .Select("id, Name, ValueType, Range, Periodicity, CircleId, Circle!inner(Name)")
            .Offset(skip) // skip a certain number of rows
            .Limit(range) //number of rows to fetch
            .Get();
        
        var dbResponse = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);
       
        var getResponse = new List<KpiResponse>();
        
        foreach (var item in dbResponse)
        {
            var tempData = new KpiResponse();
            tempData.id = Guid.Parse(item.id.ToString());
            tempData.Name = item.Name;
            tempData.ValueType = item.ValueType;
            tempData.Range = item.Range;
            tempData.Periodicity = item.Periodicity;
            tempData.CircleId = Guid.Parse(item.CircleId.ToString());
            tempData.CircleName = item.Circle.Name;
            
            getResponse.Add(tempData);
        }
        return Ok(getResponse);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _client.From<Domain.Entities.Kpi.Kpi>()
            .Select("id, Name, ValueType, Range, Periodicity, CircleId, Circle!inner(Name)")
            .Where(n => n.id == id)
            .Get();
    
        var dbResponseArray = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);
        if (dbResponseArray == null || !dbResponseArray.Any())
        {
            return NotFound();
        }
        var dbResponse = dbResponseArray.First();
    
        var getResponse = new KpiResponse
        {
            id = Guid.Parse(dbResponse.id.ToString()),
            Name = dbResponse.Name,
            ValueType = dbResponse.ValueType,
            Range = dbResponse.Range,
            Periodicity = dbResponse.Periodicity,
            CircleId = Guid.Parse(dbResponse.CircleId.ToString()),
            CircleName = dbResponse.Circle.Name,
        };
        return Ok(getResponse);
    }
}