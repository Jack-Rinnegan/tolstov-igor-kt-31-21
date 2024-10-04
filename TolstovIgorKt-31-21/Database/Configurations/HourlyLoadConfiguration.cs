using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TolstovIgorKt_31_21.Database.Helprers;
using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Database.Configurations
{
    public class HourlyLoadConfiguration: IEntityTypeConfiguration<HourlyLoad>
    {
        public const string TableName = "cd_hourly_load";

        public void Configure(EntityTypeBuilder<HourlyLoad> builder)
        {
            builder
                .HasKey(p => p.HourlyLoadId)
                .HasName($"pk_{TableName}_hourly_load_id");

            builder.Property(p => p.HourlyLoadId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.HourlyLoadId)
                .HasColumnName("hourly_load_id")
                .HasComment("Идентификатор записи звгруженности преподавателя");

            builder.Property(p => p.Hours)
                .IsRequired()
                .HasColumnName("c_hours")
                .HasColumnType(ColumnType.Int).HasMaxLength(8)
                .HasComment("Количество часов");

            //связь нагруженность преподавателя
            builder.Property(p => p.LecturerId)
                .HasColumnName("lecturer_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.ToTable(TableName)
                .HasOne(p => p.Lecturer)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey<HourlyLoad>(p => p.LecturerId)
                .HasConstraintName("fk_f_lecturer_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.LecturerId, $"idx_{TableName}_fk_f_lecturer_id");

            builder.Navigation(p => p.Lecturer)
                .AutoInclude();


            //связь нагруженность дисциплин
            builder.Property(p => p.DisciplinId)
                .HasColumnName("disciplin_id")
                .HasComment("Идентификатор записи дисциплины");

            builder.ToTable(TableName)
                .HasOne(p => p.Disciplin)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey<HourlyLoad>(p => p.DisciplinId)
                .HasConstraintName("fk_f_disciplin_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DisciplinId, $"idx_{TableName}_fk_f_disciplin_id");

            builder.Navigation(p => p.Disciplin)
                .AutoInclude();


            //связь нагруженность кафедры
            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи кафедры");

            builder.ToTable(TableName)
                .HasOne(p => p.Department)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey<HourlyLoad>(p => p.DepartmentId)
                .HasConstraintName("fk_f_department_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_f_department_id");

            builder.Navigation(p => p.Department)
                .AutoInclude();

        }
    }
}
