using TolstovIgorKt_31_21.Database;
using TolstovIgorKt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace TolstovIgorKt_31_21.Interfaces.LecturerInterfaces
{
    public interface ILecturerService
    {
        public Task<Lecturer[]> GetLecturerAsync(CancellationToken cancellationToken = default);
        public Task AddLecturerAsync(string firstName, string lastName, string middleName, int departmentId, CancellationToken cancellationToken);
        public Task UpdateLecturerAsync(int lecturerId, string newLecturerFirstName, string newLecturerLastName, string newLecturerMiddleName, CancellationToken cancellationToken);
        public Task DeleteLecturerAsync(int lecturerId, CancellationToken cancellationToken);
    }

    public class LecturerService : ILecturerService
    {
        private readonly LecturerDbContext _dbContext;
        public LecturerService(LecturerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task<Lecturer[]> GetLecturerAsync(CancellationToken cancellationToken = default)
        {
            var lecturer = _dbContext.Set<Lecturer>().ToArrayAsync(cancellationToken);

            return lecturer;
        }

        public async Task AddLecturerAsync(string firstName, string lastName, string middleName, int departmentId, CancellationToken cancellationToken = default)
        {
            var lecturer = await _dbContext.Set<Lecturer>().FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (lecturer != null)
            {
                var newLecturer = new Lecturer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    DepartmentId = departmentId,
                };

                _dbContext.Lecturers.Add(newLecturer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateLecturerAsync(int lecturerId, string newLecturerFirstName, string newLecturerLastName, string newLecturerMiddleName, CancellationToken cancellationToken = default)
        {
            var lecturer = await _dbContext.Set<Lecturer>().FindAsync(lecturerId);

            if (lecturer != null)
            {
                lecturer.FirstName = newLecturerFirstName;
                lecturer.LastName = newLecturerLastName;
                lecturer.MiddleName = newLecturerMiddleName;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteLecturerAsync(int lecturerId, CancellationToken cancellationToken = default)
        {
            var lecturer = await _dbContext.Set<Lecturer>().FindAsync(lecturerId);

            if (lecturer != null)
            {
                _dbContext.Lecturers.Remove(lecturer);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
