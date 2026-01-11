using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetteRFlow.Shared.Data;

[ApiController]
[Route("api/admin/statistics")]
public class AdminStatisticsController : ControllerBase
{
    private readonly BetteRFlowContext _db;

    public AdminStatisticsController(BetteRFlowContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetStatistics()
    {
        var today = DateTime.UtcNow.Date;

        var totalPageViews = await _db.PageViews.CountAsync();
        var todayPageViews = await _db.PageViews
            .CountAsync(p => p.CreatedAt >= today);

        return Ok(new
        {
            totalPageViews,
            todayPageViews
        });
    }
}

