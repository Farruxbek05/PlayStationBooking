using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.BookingSnack;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers;

public class BookingSnackController : ControllerBase
{
    private readonly IBookingSnackService _bookingSnackService;

    public BookingSnackController(IBookingSnackService bookingSnackService)
    {
        _bookingSnackService = bookingSnackService;
    }
    [HttpGet("GetAllBookingSnack")]
    public async Task<IActionResult> GetAllBookingSnack()
    {
        var res = await _bookingSnackService.GetAllBookingSnackAsync();
        return Ok(res);
    }
    [HttpGet("GetBookingSnack/{id}")]
    public async Task<IActionResult> GetBookingSnack(Guid guid)
    {
        var res = await _bookingSnackService.GetByIdBookingSnackAsync(guid);
        return Ok(res);
    }
    [HttpPost("CreateBookingSnack")]
    public async Task<IActionResult> CreateBookingSnack(BookingSnackCM bookingSnackCM)
    {
        var res = await _bookingSnackService.CreateBookingSnackAsync(bookingSnackCM);
        return Ok(res);
    }
    [HttpPut("UpdateBookingSnack")]
    public async Task<IActionResult> UpdateBookingSnack(BookingSnackUM bookingSnackUM)
    {
        var res = await _bookingSnackService.UpdateBookingSnackAsync(bookingSnackUM);
        return Ok(res);
    }
    [HttpDelete("DeleteBookingSnack")]
    public async Task<IActionResult> DeleteBookingSnack(Guid guid)
    {
        var res = await _bookingSnackService.DeleteBookingSnackAsync(guid);
        return Ok(res);
    }
}
