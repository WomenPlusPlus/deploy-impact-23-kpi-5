using Domain.Contracts.Dashboard;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers.Dashboard;

[ApiController]
[Route("api/v1/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly Supabase.Client _client;

    public DashboardController(Supabase.Client client)
    {
        _client = client;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(int skip = 0, int range = 25)
    {//            .Select("id, CircleId, Circle!inner(Name), Title, CreationDate, VisualisationType, KpiId, Kpi!inner(Name, Value, Range), Field, TemplateId, DashboardTemplate!inner(Name, Layout)"
        var response = await _client.From<Domain.Entities.Dashboard.Dashboard>()
            .Select("id, CreationDate, TemplateId, DashboardTemplate!inner(Name)," +
                    "CircleId, Circle!inner(Name), UserId, User!inner(Name)")
            .Offset(skip) // skip a certain number of rows
            .Limit(range) //number of rows to fetch
            .Get();

        var dbResponse = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);
       
        var getResponse = new List<DashboardResponse>();
        
        foreach (var item in dbResponse)
        {
            var tempData = new DashboardResponse();
            tempData.id = Guid.Parse(item.id.ToString());
            tempData.CreationDate = item.CreationDate;
            tempData.TemplateId = Guid.Parse(item.TemplateId.ToString());
            tempData.TemplateName = item.DashboardTemplate.Name;
            tempData.CircleId = Guid.Parse(item.CircleId.ToString());
            tempData.CircleName = item.Circle.Name;
            tempData.UserId = Guid.Parse(item.UserId.ToString());
            tempData.UserName = item.User.Name;
            
            getResponse.Add(tempData);
        }
        return Ok(getResponse);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _client.From<Domain.Entities.Dashboard.Dashboard>()
            .Select("id, CreationDate, TemplateId, DashboardTemplate!inner(Name)," +
                    "CircleId, Circle!inner(Name), UserId, User!inner(Name)")
            .Where(n => n.id == id)
            .Get();
    
        var dbResponseArray = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);
        if (dbResponseArray == null || !dbResponseArray.Any())
        {
            return NotFound();
        }
        var dbResponse = dbResponseArray.First();
    
        var getResponse = new DashboardResponse
        {
            id = Guid.Parse(dbResponse.id.ToString()),
            CreationDate = dbResponse.CreationDate,
            TemplateId = Guid.Parse(dbResponse.TemplateId.ToString()),
            TemplateName = dbResponse.DashboardTemplate.Name,
            CircleId = Guid.Parse(dbResponse.CircleId.ToString()),
            CircleName = dbResponse.Circle.Name,
            UserId = Guid.Parse(dbResponse.UserId.ToString()),
            UserName = dbResponse.User.Name
        };
        return Ok(getResponse);
    }
}