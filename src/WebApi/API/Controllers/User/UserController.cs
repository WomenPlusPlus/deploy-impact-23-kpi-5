using AutoMapper;
using Domain.Contracts.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Postgrest;

namespace Api.Controllers.User;

[ApiController]
[Route("api/v1/")]
public class UserController : ControllerBase
{
    private readonly Supabase.Client _client;
    private readonly IMapper _mapper;

    public UserController(Supabase.Client client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllUsers(int skip = 0, int range = 25)
    {
        var response = await _client.From<Domain.Entities.User.User>()
            .Select("id, Name, Circle!inner(id, Name), UserPermission!inner(*)")
            .Offset(skip) // skip a certain number of rows
            .Limit(range) //number of rows to fetch
            .Get();

        var dbResponse = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);

        var getResponse = _mapper.Map<List<UserResponse>>(dbResponse);

        return Ok(getResponse);
    }

    [HttpGet("user/{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var response = await _client.From<Domain.Entities.User.User>()
            .Select("id, Name, Circle!inner(id, Name), UserPermission!inner(*)")
            .Where(n => n.id == id)
            .Where(n => n.id == id)
            .Get();

        var dbResponseArray = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);
        if (dbResponseArray == null || !dbResponseArray.Any())
        {
            return NotFound();
        }

        var dbResponse = dbResponseArray.First();

        var getResponse = _mapper.Map<UserResponse>(dbResponse);

        return Ok(getResponse);
    }

    [HttpGet("user-role")]
    public async Task<IActionResult> GetAllUserRoles(int skip = 0, int range = 25)
    {
        var response = await _client.From<Domain.Entities.User.UserPermission>()
            .Select("id, UserId, CreatedAt, UserRole!inner(*)")
            .Offset(skip) // skip a certain number of rows
            .Limit(range) //number of rows to fetch
            .Get();

        var dbResponse = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);

        var getResponse = new List<UserPermissionRoleResponse>();

        foreach (var item in dbResponse)
        {
            var tempData = new UserPermissionRoleResponse();
            tempData.id = Guid.Parse(item.id.ToString());
            tempData.UserId = Guid.Parse(item.id.ToString());
            tempData.UserRoleId = Guid.Parse(item.id.ToString());
            tempData.RoleName = item.UserRole.RoleName;
            tempData.CreatedAt = item.CreatedAt;

            getResponse.Add(tempData);
        }

        return Ok(getResponse);
    }

    [HttpGet("user-role/{userId:guid}")]
    public async Task<IActionResult> GetUserRoleByUserId(Guid userId)
    {
        string userIdString = userId.ToString();
        var response = await _client.From<Domain.Entities.User.UserPermission>()
            .Select("id, UserId, CreatedAt, UserRole!inner(*)")
            .Filter("UserId", Constants.Operator.Equals, userIdString )
            .Get();

        var dbResponseArray = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);
        if (dbResponseArray == null || !dbResponseArray.Any())
        {
            return NotFound();
        }

        var dbResponse = dbResponseArray.First();

        var getResponse = new UserPermissionRoleResponse
        {
            id = Guid.Parse(dbResponse.id.ToString()),
            UserId = Guid.Parse(dbResponse.UserId.ToString()),
            UserRoleId = Guid.Parse(dbResponse.UserRoleId.ToString()),
            RoleName = dbResponse.UserRole.RoleName,
            CreatedAt = dbResponse.CreatedAt
        };
        return Ok(getResponse);
    }
}