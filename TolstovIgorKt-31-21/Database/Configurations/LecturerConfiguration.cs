using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TolstovIgorKt_31_21.Models;
using TolstovIgorKt_31_21.Database.Helprers;


namespace TolstovIgorKt_31_21.Database.Configurations
{
    public class LecturerConfiguration: IEntityTypeConfiguration<Lecturer>
    {
        public const string TableName = "cd_lecturer";

        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            builder
                .HasKey(p => p.LecturerId)
                .HasName($"pk_{TableName}_lecturer_id");

            builder.Property(p => p.LecturerId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.LecturerId)
                .HasColumnName("lecturer_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_lecturer_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(128)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_lecturer_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(128)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_lecturer_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(128)
                .HasComment("Отчество преподавателя");


            //связь Должности
            builder.Property(p => p.PositionId)
                .HasColumnName("position_id")
                .HasComment("Идентификатор записи должности");

            builder.ToTable(TableName)
                .HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PositionId)
                .HasConstraintName("fk_f_position_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.PositionId, $"idx_{TableName}_fk_f_position_id");

            builder.Navigation(p => p.Position)
                .AutoInclude();

             //связь кафедры
            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.ToTable(TableName)
                .HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .HasConstraintName("fk_f_department_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_f_department_id");

            builder.Navigation(p => p.Department)
                .AutoInclude();


            //связь Ученые степени
            builder.Property(p => p.AcademicDegreeId)
                .HasColumnName("academic_degree_id")
                .HasComment("Идентификатор записи ученой степени");

            builder.ToTable(TableName)
                .HasOne(p => p.AcademicDegree)
                .WithMany()
                .HasForeignKey(p => p.AcademicDegreeId)
                .HasConstraintName("fk_f_academic_degree_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.AcademicDegreeId, $"idx_{TableName}_fk_f_academic_degree_id");

            builder.Navigation(p => p.AcademicDegree)
                .AutoInclude();


            //связь нагруженность преподавателя
            builder.Property(p => p.HourlyLoadId)
                .HasColumnName("hourly_load_id")
                .HasComment("Идентификатор записи нагруженности");

            builder.ToTable(TableName)
                .HasOne(p => p.HourlyLoad)
                .WithOne()
                .HasForeignKey<HourlyLoad>(p => p.HourlyLoadId)
                .HasConstraintName("fk_f_hourly_load_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.HourlyLoadId, $"idx_{TableName}_fk_f_hourly_load_id");

            builder.Navigation(p => p.HourlyLoad)
                .AutoInclude();
        }
    }
}
