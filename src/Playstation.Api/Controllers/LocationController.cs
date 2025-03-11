using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.Location;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers;

public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    [HttpGet("GetAllLocation")]
    public async Task<IActionResult> GetAllLocation()
    {
        var res = await _locationService.GetAllLocationAsync();
        return Ok(res);
    }
    [HttpPost("CreateLocation")]
    public async Task<IActionResult> CreateLocation(LocationCM locationCM)
    {
        var res = await _locationService.CreateLocationAsync(locationCM);
        return Ok(res);
    }
    [HttpDelete("DeleteLocation")]
    public async Task<IActionResult> DeleteLocation(Guid guid)
    {
        var res = await _locationService.DeleteLocationAsync(guid);
        return Ok(res);
    }
    [HttpGet("GetLocation/{id}")]
    public async Task<IActionResult> GetLocation(Guid id)
    {
        var res = await _locationService.GetByIdLocationAsync(id);
        return Ok(res);
    }
    [HttpPut("UpdateLocation")]
    public async Task<IActionResult> UpdateLocation(LocationUM locationUM)
    {
        var res = await _locationService.UpdateLocationAsync(locationUM);
        return Ok(res);
    }

}
