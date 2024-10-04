using TolstovIgorKt_31_21.Database;
using TolstovIgorKt_31_21.Models;
using TolstovIgorKt_31_21.Filters.HourlyLoadFilters;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



namespace TolstovIgorKt_31_21.Interfaces.HourlyLoadInterfaces
{
    public interface IHourlyLoadService
    {
        public Task<HourlyLoad[]> GetHourlyLoadByLecturerAsync(HourlyLoadLecturerFilter filter, CancellationToken cancellationToken);
    }

    public class HourlyLoadService : IHourlyLoadService
    {
        private readonly LecturerDbContext _dbContext;
        public HourlyLoadService(LecturerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<HourlyLoad[]> GetHourlyLoadByLecturerAsync(HourlyLoadLecturerFilter filter, CancellationToken cancellationToken = default)
        {
            var fio = filter.FIO.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var query = _dbContext.Set<HourlyLoad>().AsQueryable();

            if (filter.FIO != "string" && fio.Length == 3)
            {
                query = query.Where(
                    w => (fio.Length == 3 && w.Lecturer.MiddleName == fio[0] &&
                         w.Lecturer.FirstName == fio[1] && w.Lecturer.LastName == fio[2])
                );
            }
                
            if(filter.DepartmentName != "string")
            {
                query = query.Where(
                    w => (w.Department.DepartmentName == filter.DepartmentName)
                );
            }

            if (filter.DisciplinName != "string")
            {
                query = query.Where(
                    w => (w.Disciplin.DisciplinName == filter.DisciplinName)
                );
            }

            var hourly_load =
                query.ToArrayAsync(cancellationToken);

            return hourly_load;
        }
    }
}
