using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.PlayStationRoomGame;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers;

public class PlayStationRoomGameController:ControllerBase
{
    private readonly IPlayStationRoomGameService _playStationRoomGameService;
    public PlayStationRoomGameController(IPlayStationRoomGameService playStationRoomGameService)
    {
        _playStationRoomGameService = playStationRoomGameService;
    }
    [HttpGet("GetAllPlayStationRoomGame")]
    public async Task<IActionResult> GetAllPlayStationRoomGame()
    {
        var res = await _playStationRoomGameService.GetAllPlayStationRoomGameAsync();
        return Ok(res);
    }
    [HttpGet("GetPlayStationRoomGame/{id}")]
    public async Task<IActionResult> GetPlayStationRoomGame(Guid id)
    {
        var res = await _playStationRoomGameService.GetByIdPlayStationRoomGameAsync(id);
        return Ok(res);
    }
    [HttpPost("CreatePlayStationRoomGame")]
    public async Task<IActionResult> CreatePlayStationRoomGame(PlayStationRoomGameCM playStationRoomGameCM)
    {
        var res = await _playStationRoomGameService.CreatePlayStationRoomGameAsync(playStationRoomGameCM);
        return Ok(res);
    }
    [HttpPut("UpdatePlayStationRoomGame")]
    public async Task<IActionResult> UpdatePlayStationRoomGame(PlayStationRoomGameUM playStationRoomGameUM)
    {
        var res = await _playStationRoomGameService.UpdatePlayStationRoomGameAsync(playStationRoomGameUM);
        return Ok(res);
    }
    [HttpDelete("DeletePlayStationRoomGame")]
    public async Task<IActionResult> DeletePlayStationRoomGame(Guid guid)
    {
        var res = await _playStationRoomGameService.DeletePlayStationRoomGameAsync(guid);
        return Ok(res);
    }
}
