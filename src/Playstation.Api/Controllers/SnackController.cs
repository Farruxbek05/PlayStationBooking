using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.Snack;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers;

public class SnackController : ControllerBase
{
    private readonly ISnackService _snackService;
    public SnackController(ISnackService snackService)
    {
        _snackService = snackService;
    }
    [HttpGet("GetAllSnack")]
    public async Task<IActionResult> GetAllSnack()
    {
        var res = await _snackService.GetAllSnackAsync();
        return Ok(res);
    }
    [HttpGet("GetSnack/{id}")]
    public async Task<IActionResult> GetSnack(Guid id)
    {
        var res = await _snackService.GetByIdSnackAsync(id);
        return Ok(res);
    }
    [HttpPost("CreateSnack")]
    public async Task<IActionResult> CreateSnack(SnackCM snackCM)
    {
        var res = await _snackService.CreateSnackAsync(snackCM);
        return Ok(res);
    }
    [HttpPut("UpdateSnack")]
    public async Task<IActionResult> UpdateSnack(SnackUM snackUM)
    {
        var res = await _snackService.UpdateSnackAsync(snackUM);
        return Ok(res);
    }
    [HttpDelete("DeleteSnack")]
    public async Task<IActionResult> DeleteSnack(Guid guid)
    {
        var res = await _snackService.DeleteSnackAsync(guid);
        return Ok(res);
    }
}
