using Domain.Contracts.Circle;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Circle;

[ApiController]
[Route("api/v1/[controller]")]
public class CircleController : ControllerBase
{
    private readonly Supabase.Client _client;

    public CircleController(Supabase.Client client)
    {
        _client = client;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(int skip = 0, int range = 25)
    {
        var response = await _client.From<Domain.Entities.Circle.Circle>()
            .Offset(skip) // skip a certain number of rows
            .Limit(range) //number of rows to fetch
            .Get();

        var dbResponse = response.Models;
       
        var getResponse = new List<CircleResponse>();
        
        foreach (var item in dbResponse)
        {
            var tempData = new CircleResponse();
            tempData.id = item.id;
            tempData.Name = item.Name;
            
            getResponse.Add(tempData);
        }
        return Ok(getResponse);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _client.From<Domain.Entities.Circle.Circle>()
            .Where(n => n.id == id)
            .Get();

        var dbResponse = response.Models.FirstOrDefault();
        if (dbResponse is null)
        {
            return NotFound();
        }

        var getResponse = new CircleResponse
        {
            id = dbResponse.id,
            Name = dbResponse.Name
        };
        return Ok(getResponse);
    }
}

