using Microsoft.AspNetCore.Mvc;
using TolstovIgorKt_31_21.Filters.HourlyLoadFilters;
using TolstovIgorKt_31_21.Interfaces.HourlyLoadInterfaces;


namespace TolstovIgorKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HourlyLoadController : ControllerBase
    {
        private readonly ILogger<HourlyLoadController> _logger;
        private readonly IHourlyLoadService _hourlyLoadService;

        public HourlyLoadController(ILogger<HourlyLoadController> logger, IHourlyLoadService hourlyLoadService)
        {
            _logger = logger;
            _hourlyLoadService = hourlyLoadService;
        }

        [HttpPost("GetHourlyLoadByLecturer")]
        public async Task<IActionResult> GetHourlyLoadByLecturerAsync(HourlyLoadLecturerFilter filter, CancellationToken cancellationToken = default)
        {
            var hourly_load = await _hourlyLoadService.GetHourlyLoadByLecturerAsync(filter, cancellationToken);

            return Ok(hourly_load);
        }
    }
}
