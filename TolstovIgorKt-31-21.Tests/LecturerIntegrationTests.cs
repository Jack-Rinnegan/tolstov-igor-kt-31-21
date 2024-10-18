using Microsoft.EntityFrameworkCore;
using TolstovIgorKt_31_21.Database;
using TolstovIgorKt_31_21.Models;
using TolstovIgorKt_31_21.Interfaces.DepartmentInterfaces;

namespace TolstovIgorKt_31_21.Tests
{
    public class LecturerIntegrationTests
    {
        public readonly DbContextOptions<LecturerDbContext> _dbContextOptions;

        public LecturerIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<LecturerDbContext>()
            .UseInMemoryDatabase(databaseName: "lecturer_db")
            .Options;
        }

        [Fact]
        public async Task GetLecturersByDepartmentAsync_KT3121_TwoObjects()
        {
            // Arrange
            var ctx = new LecturerDbContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);
            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentName = "ИВТ",
                    DepartmentEstablishment = new DateOnly(2001, 01, 02),
                },
                new Department
                {
                    DepartmentName = "ВИШ",
                    DepartmentEstablishment = new DateOnly(1800, 11, 02)
                }
            };
            await ctx.Set<Department>().AddRangeAsync(departments);

            var academic_degrees = new List<AcademicDegree>
            {
                new AcademicDegree
                {
                    AcademicDegreeName = AcademicDegreeType.ScienceDoctor
                },
                new AcademicDegree
                {
                    AcademicDegreeName = AcademicDegreeType.ScienceCandidate
                },
            };
            await ctx.Set<AcademicDegree>().AddRangeAsync(academic_degrees);

            var positions = new List<Position>
            {
                new Position
                {
                    PositionName = PositionNameType.HeadLecturer
                },
            };
            await ctx.Set<Position>().AddRangeAsync(positions);

            var lecturers = new List<Lecturer>
            {
                new Lecturer
                {
                    FirstName = "Ivan",
                    LastName = "NeVan",
                    MiddleName = "NeVano",
                    PositionId = 1,
                    DepartmentId = 2,
                    AcademicDegreeId = 1,
                },
                new Lecturer
                {
                    FirstName = "Egor",
                    LastName = "NeEgor",
                    MiddleName = "NeEgorov",
                    PositionId = 1,
                    DepartmentId = 1,
                    AcademicDegreeId = 2,
                },
            };
            await ctx.Set<Lecturer>().AddRangeAsync(lecturers);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.DepartmentFilters.DepartmentEstablishmentFilter
            {
                DateOfEstablishment = new DateOnly(1800, 11, 02)
            };
            var lecturersResult = await departmentService.GetDepartmentByDateOfEstablishmentAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, lecturersResult.Length);
        }
    }
}
