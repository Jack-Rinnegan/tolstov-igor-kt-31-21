using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TolstovIgorKt_31_21.Interfaces.DepartmentInterfaces;
using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LecturerController : Controller
    {
        private readonly ILogger<LecturerController> _logger;
        private readonly IDepartmentService _lecturerService;

        public LecturerController(ILogger<LecturerController> logger, IDepartmentService lecturerService)
        {
            _logger = logger;
            _lecturerService = lecturerService;
        }

        [HttpGet("GetLecturer")]
        public async Task<IActionResult> GetLecturerAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var lecturer = await _lecturerService.GetLecturerAsync(cancellationToken);
                return Ok(lecturer);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при добавлении преподавателя: {ex.Message}");
            }

        }

        [HttpPost("AddLecturer")]
        public async Task<IActionResult> AddLecturerAsync(string firstName, string lastName, string middleName, int departmentId, CancellationToken cancellationToken = default)
        {
            try
            {
                await _lecturerService.AddLecturerAsync(firstName, lastName, middleName, departmentId, cancellationToken);
                return Ok("Преподаватель успешно добавлен.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при добавлении преподавателя: {ex.Message}");
            }
        }

        [HttpPut("UpdateLecturer/{lecturerId}")]
        public async Task<IActionResult> UpdateLecturerAsync(int lecturerId, string newLecturerFirstName, string newLecturerLastName, string newLecturerMiddleName, CancellationToken cancellationToken = default)
        {
            try
            {
                await _lecturerService.UpdateLecturerAsync(lecturerId, newLecturerFirstName, newLecturerLastName, newLecturerMiddleName, cancellationToken);
                return Ok("Преподаватель успешно обновлен.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при обновлении преподавателя: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLecturer/{lecturerId}")]
        public async Task<IActionResult> DeleteLecturerAsync(int lecturerId, CancellationToken cancellationToken = default)
        {
            try
            {
                await _lecturerService.DeleteLecturerAsync(lecturerId, cancellationToken);
                return Ok("Преподаватель успешно удален.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при удалении преподавателя: {ex.Message}");
            }
        }
    }
}
