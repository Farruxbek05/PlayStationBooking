using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.Review;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers;

public class ReviewController: ControllerBase
{
    private readonly IReviewService _reviewService;
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    [HttpGet("GetAllReview")]
    public async Task<IActionResult> GetAllReview()
    {
        var res = await _reviewService.GetAllReviewAsync();
        return Ok(res);
    }
    [HttpGet("GetReview/{id}")]
    public async Task<IActionResult> GetReview(Guid id)
    {
        var res = await _reviewService.GetByIdReviewAsync(id);
        return Ok(res);
    }
    [HttpPost("CreateReview")]
    public async Task<IActionResult> CreateReview(ReviewCM reviewCM)
    {
        var res = await _reviewService.CreateReviewAsync(reviewCM);
        return Ok(res);
    }
    [HttpPut("UpdateReview")]
    public async Task<IActionResult> UpdateReview(ReviewUM reviewUM)
    {
        var res = await _reviewService.UpdateReviewAsync(reviewUM);
        return Ok(res);
    }
    [HttpDelete("DeleteReview")]
    public async Task<IActionResult> DeleteReview(Guid guid)
    {
        var res = await _reviewService.DeleteReviewAsync(guid);
        return Ok(res);
    }
}
