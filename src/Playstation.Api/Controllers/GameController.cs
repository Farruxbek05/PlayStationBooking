using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.Game;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers;

public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    [HttpGet("GetAllGame")]
    public async Task<IActionResult> GetAllGame()
    {
        var res = await _gameService.GetAllGameAsync();
        return Ok(res);
    }
    [HttpGet("GetGame/{id}")]
    public async Task<IActionResult> GetGame(Guid id)
    {
        var res = await _gameService.GetByIdGameAsync(id);
        return Ok(res);
    }
    [HttpPost("CreateGame")]
    public async Task<IActionResult> CreateGame(GameCM gameCM)
    {
        var res = await _gameService.CreateGameAsync(gameCM);
        return Ok(res);
    }
    [HttpPut("UpdateGame")]
    public async Task<IActionResult> UpdateGame(GameUM gameUM)
    {
        var res = await _gameService.UpdateGameAsync(gameUM);
        return Ok(res);
    }
    [HttpDelete("DeleteGame")]
    public async Task<IActionResult> DeleteGame(Guid guid)
    {
        var res = await _gameService.DeleteGameAsync(guid);
        return Ok(res);
    }
}
