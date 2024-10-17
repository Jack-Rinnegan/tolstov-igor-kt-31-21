using Microsoft.AspNetCore.Mvc;
using TolstovIgorKt_31_21.Filters.DepartmentFilters;
using TolstovIgorKt_31_21.Interfaces.DepartmentInterfaces;


namespace TolstovIgorKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpPost("GetDepartmentAsync")]
        public async Task<IActionResult> GetDepartmentAsync(CancellationToken cancellationToken = default)
        {
            var department = await _departmentService.GetDepartmentAsync(cancellationToken);

            return Ok(department);
        }

        [HttpPost("GetDepartmentByDateOfEstablishmentAsync")]
        public async Task<IActionResult> GetDepartmentByDateOfEstablishmentAsync(DepartmentEstablishmentFilter filter, CancellationToken cancellationToken = default)
        {
            var department = await _departmentService.GetDepartmentByDateOfEstablishmentAsync(filter, cancellationToken);

            return Ok(department);
        }

        [HttpPost("GetDepartmentByCountOfLecturerAsync")]
        public async Task<IActionResult> GetDepartmentByCountOfLecturer(DepartmentLecturerFilter filter, CancellationToken cancellationToken = default)
        {
            var department = await _departmentService.GetDepartmentByCountOfLecturerAsync(filter, cancellationToken);

            return Ok(department);
        }
    }
}
