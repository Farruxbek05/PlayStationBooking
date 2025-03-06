using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.Booking;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers;

public class BookingController : ControllerBase
{
    public readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    [HttpGet("GetBookings")]
    public async Task<IActionResult> GetBookings()
    {
        var res = await _bookingService.GetAllBookingAsync();
        return Ok(res);
    }
    [HttpGet("GetBooking/{id}")]
    public async Task<IActionResult> GetBooking(Guid id)
    {
        var res = await _bookingService.GetByIdBookingAsync(id);
        return Ok(res);

    }
    [HttpPost("CreateBooking")]
    public async Task<IActionResult> CreateBooking(BookingCM bookingCM)
    {
        var res = await _bookingService.CreateBookingAsync(bookingCM);
        return Ok(res);
    }
    [HttpPut("UpdateBooking")]
    public async Task<IActionResult> UpdateBooking(BookingUM bookingUM)
    {
        var res = await _bookingService.UpdateBookingAsync(bookingUM);
        return Ok(res);
    }
    [HttpDelete("DeleteBooking")]
    public async Task<IActionResult> DeleteBooking(Guid Id)
    {
        var res = await _bookingService.DeleteBookingAsync(Id);
        return Ok(res);
    }
}
