using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TolstovIgorKt_31_21.Database.Helprers;
using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Database.Configurations
{
    public class DisciplineConfiguration: IEntityTypeConfiguration<Discipline>
    {
        public const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                .HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор записи предмета");

            builder.Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(128)
                .HasComment("Название предмета");


            //связь Преподаватели
            builder.Property(p => p.LecturerId)
                .HasColumnName("lecturer_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.ToTable(TableName)
                .HasOne(p => p.Lecturer)
                .WithMany()
                .HasForeignKey(p => p.LecturerId)
                .HasConstraintName("fk_f_lecturer_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.LecturerId, $"idx_{TableName}_fk_f_lecturer_id");

            builder.Navigation(p => p.Lecturer)
                .AutoInclude();

        }
    }
}
