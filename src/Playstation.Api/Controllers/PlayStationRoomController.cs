using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.Console;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers;

public class PlayStationRoomController : ControllerBase
{
    private readonly IPlayStationRoomService _playStationRoomService;

    public PlayStationRoomController(IPlayStationRoomService playStationRoomService)
    {
        _playStationRoomService = playStationRoomService;
    }
    [HttpGet("GetAllPlayStationRoom")]
    public async Task<IActionResult> GetAllPlayStationRoom()
    {
        var res = await _playStationRoomService.GetAllPlayStationRoomAsync();
        return Ok(res);
    }
    [HttpGet("GetPlayStationRoom/{id}")]
    public async Task<IActionResult> GetPlayStationRoom(Guid id)
    {
        var res = await _playStationRoomService.GetByIdPlayStationRoomAsync(id);
        return Ok(res);
    }
    [HttpPost("CreatePlayStationRoom")]
    public async Task<IActionResult> CreatePlayStationRoom(PlayStationRoomCM playStationRoomCM)
    {
        var res = await _playStationRoomService.CreatePlayStationRoomAsync(playStationRoomCM);
        return Ok(res);
    }
    [HttpPut("UpdatePlayStationRoom")]
    public async Task<IActionResult> UpdatePlayStationRoom(PlayStationRoomUM playStationRoomUM)
    {
        var res = await _playStationRoomService.UpdatePlayStationRoomAsync(playStationRoomUM);
        return Ok(res);
    }
    [HttpDelete("DeletePlayStationRoom")]
    public async Task<IActionResult> DeletePlayStationRoom(Guid guid)
    {
        var res = await _playStationRoomService.DeletePlayStationRoomAsync(guid);
        return Ok(res);
    }

}
