using Microsoft.EntityFrameworkCore;
using TolstovIgorKt_31_21.Models;
using TolstovIgorKt_31_21.Database.Configurations;


namespace TolstovIgorKt_31_21.Database
{
    public class LecturerDbContext : DbContext
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Lecturer> Lecturers { get; set; }
        DbSet<AcademicDegree> AcademicDegrees { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<HourlyLoad> HourlyLoads { get; set; }
        DbSet<Disciplin> Disciplins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new LecturerConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new HourlyLoadConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinConfiguration());
        }

        public LecturerDbContext(DbContextOptions<LecturerDbContext> options) : base(options)
        {

        }
    }
}
