using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TolstovIgorKt_31_21.Database.Helprers;
using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Database.Configurations
{
    public class DepartmentConfiguration: IEntityTypeConfiguration<Department>
    {
        public const string TableName = "cd_department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(p => p.DepartmentId)
                .HasName($"pk_{TableName}_department_id");

            builder.Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи кафедры");

            builder.Property(p => p.DepartmentName)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String).HasMaxLength(128)
                .HasComment("Название кафедры");

            builder.ToTable(TableName);

        }
    }
}
