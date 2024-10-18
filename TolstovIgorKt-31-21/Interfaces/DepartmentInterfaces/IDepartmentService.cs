using TolstovIgorKt_31_21.Database;
using TolstovIgorKt_31_21.Models;
using TolstovIgorKt_31_21.Filters.DepartmentFilters;
using Microsoft.EntityFrameworkCore;
using TolstovIgorKt_31_21.Interfaces.DepartmentInterfaces;
using NLog.Filters;
using Microsoft.AspNetCore.Mvc;


namespace TolstovIgorKt_31_21.Interfaces.DepartmentInterfaces
{
    public interface IDepartmentService
    {
        public Task<Department[]> GetDepartmentAsync(CancellationToken cancellationToken);
        public Task<Department[]> GetDepartmentByDateOfEstablishmentAsync(DepartmentEstablishmentFilter filter, CancellationToken cancellationToken);
        public Task<Department[]> GetDepartmentByCountOfLecturerAsync(DepartmentLecturerFilter filter, CancellationToken cancellationToken);

    }

    public class DepartmentService : IDepartmentService
    {
        private readonly LecturerDbContext _dbContext;
        public DepartmentService(LecturerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Department[]> GetDepartmentAsync(CancellationToken cancellationToken = default)
        {
            var department = _dbContext.Set<Department>().ToArrayAsync(cancellationToken);

            return department;
        }
        public Task<Department[]> GetDepartmentByDateOfEstablishmentAsync(DepartmentEstablishmentFilter filter, CancellationToken cancellationToken = default)
        {
            var department = _dbContext.Set<Department>().Where(d =>
            (d.DepartmentEstablishment == filter.DateOfEstablishment)).ToArrayAsync(cancellationToken);

            return department;
        }
        public Task<Department[]> GetDepartmentByCountOfLecturerAsync(DepartmentLecturerFilter filter, CancellationToken cancellationToken = default)
        {
            var department = _dbContext.Set<Lecturer>()
                .GroupBy(d => d.DepartmentId)
                .Where(d => d.Count() == filter.CountOfLecturer)
                .Select(d => d.Key)
                .Join(_dbContext.Set<Department>(),
                      lecturerGroup => lecturerGroup,
                      department => department.DepartmentId,
                      (lecturerGroup, department) => department)
                .ToArrayAsync(cancellationToken);

            return department;
        }

    }
}
